using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models;
using BeatSaberModInstaller.Models.BeatMods;
using BeatSaberModInstaller.Models.Events;
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
        private readonly List<string> _downloadedPackages = new List<string>();
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();

        public BeatModsHandler(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
            _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
        }

        public List<ModApiObject> GetModList()
        {
            var modResult = _httpHelper.Get(ModApiBasicUrl + ModApiUrl);
            if (modResult == null)
            {
                return null;
            }

            _mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult);

            var ret = new List<ModApiObject>();
            ret.AddRange(_mods
                .Where(mod => !mod.Status.Equals("inactive", StringComparison.OrdinalIgnoreCase) && mod.Status.Equals("approved", StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Category)
            );

            return ret;
        }

        public async Task<bool> DownloadMod(ModApiObject mod, string destinationDirectory)
        {
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

            _fileHelper.Extract(tmpFileName, destinationDirectory);
            File.Delete(tmpFileName);

            if (mod is ModDependencyObject dependencyMod)
            {
                foreach (var dependency in dependencyMod.Dependencies)
                {
                    var depMod = _mods.FirstOrDefault(x => x.Id == dependency);
                    if (depMod != null)
                    {
                        await DownloadMod(depMod, destinationDirectory);
                    }
                }
            }
            else
            {
                foreach (var dependency in mod.Dependencies)
                {
                   await DownloadMod(dependency, destinationDirectory);
                }
            }

            Console.WriteLine(@"[mod] installed " + mod.Name + @" v" + mod.Version);
            return true;
        }

        public void ResetDownloadedMods()
        {
            _downloadedPackages.Clear();
        }
    }
}