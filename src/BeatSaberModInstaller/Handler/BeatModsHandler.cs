using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models;
using BeatSaberModInstaller.Models.BeatMods;
using BeatSaberModInstaller.Models.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class BeatModsHandler
    {
        public event EventHandler<StatusEvent> StatusHandler;
        
        private const string ModApiBasicUrl = "https://beatmods.com";
        private const string ModApiUrl = "/api/v1/mod";

        private readonly HttpHelper _httpHelper;
        private readonly FileHelper _fileHelper;
        private readonly ILogger _logger;
        private readonly List<string> _downloadedPackages = new List<string>();
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();

        public BeatModsHandler(HttpHelper httpHelper, FileHelper fileHelper, ILogger logger)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
            _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<ModApiObject> GetModList()
        {
            _logger.LogInformation("Getting mods list...");
            var modResult = _httpHelper.Get(ModApiBasicUrl + ModApiUrl);
            if (modResult == null)
            {
                _logger.LogInformation("No mods were found.");
                return null;
            }

            _mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult);

            _logger.LogInformation("Found '{0}' mods.",_mods.Count());
            var ret = new List<ModApiObject>();
            ret.AddRange(_mods
                .Where(mod => !mod.Status.Equals("inactive", StringComparison.OrdinalIgnoreCase) && mod.Status.Equals("approved", StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Category)
            );

            return ret;
        }

        public async Task<bool> DownloadMod(ModApiObject mod, string destinationDirectory)
        {
            _logger.LogInformation("Downloading the mod '{0}'...", mod.Name);
            if (_downloadedPackages.Contains(mod.Name))
            {
                return true;
            }

            _downloadedPackages.Add(mod.Name);

            StatusHandler?.Invoke(null, new StatusEvent($"Downloading {mod.Name}..."));

            var tmpFileName = $"mod-{mod.Name}-{mod.Version}.zip";
            if (!await _httpHelper.DownloadFile(new Uri(ModApiBasicUrl + mod.Downloads.First().Url), tmpFileName))
            {
                return false;
            }

            _logger.LogInformation("Downloading finished. Extracting now...");
            _fileHelper.Extract(tmpFileName, destinationDirectory);
            _logger.LogInformation("Deleting temporary download file...");
            File.Delete(tmpFileName);

            _logger.LogInformation("Checking for dependencies...");
            if (mod is ModDependencyObject dependencyMod)
            {
                foreach (var dependency in dependencyMod.Dependencies)
                {
                    var depMod = _mods.FirstOrDefault(x => x.Id == dependency);
                    if (depMod != null)
                    {
                        _logger.LogInformation("Found the dependency '{0}'.",depMod.Name);
                        await DownloadMod(depMod, destinationDirectory);
                    }
                }
            }
            else
            {
                foreach (var dependency in mod.Dependencies)
                {
                    _logger.LogInformation("Found the dependency '{0}'.", dependency.Name);
                    await DownloadMod(dependency, destinationDirectory);
                }
            }

            _logger.LogInformation("Mod '{0}' was installed in the version '{1}'", mod.Name, mod.Version);
            Console.WriteLine(@"[mod] installed " + mod.Name + @" v" + mod.Version);
            return true;
        }

        public void ResetDownloadedMods()
        {
            _downloadedPackages.Clear();
        }
    }
}