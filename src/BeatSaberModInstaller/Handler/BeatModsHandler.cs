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

        private string _gameVersion;
        private readonly HttpHelper _httpHelper;
        private readonly FileHelper _fileHelper;
        private readonly ILogger _logger;
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();

        public BeatModsHandler(HttpHelper httpHelper, FileHelper fileHelper, ILogger logger)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
            _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<ModApiObject> GetModList()
        {
            _logger.LogInformation("Getting mod list...");
            Console.WriteLine(ModApiBasicUrl + ModApiUrl + "?status=approved&gameversion=" + _gameVersion);
            var modResult = _httpHelper.Get(ModApiBasicUrl + ModApiUrl + "?status=approved&gameversion=" + _gameVersion);
            if (modResult == null)
            {
                _logger.LogInformation("No mods were found.");
                return null;
            }

            _mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult).ToArray();

            _logger.LogInformation("Found {0} mods.", _mods.Count());
            var ret = new List<ModApiObject>();
            ret.AddRange(_mods.OrderBy(x => x.Category));
            _mods = ret;

            return ret;
        }

        public void SearchMods(ModApiObject mod, List<ModApiObject> modList)
        {
            if (!modList.Contains(mod))
            {
                modList.Add(mod);
            }

            Console.WriteLine(mod.Name);

            foreach (var depMod in mod.Dependencies)
            {
                var latestMod = GetLatestVersion(depMod.Name, depMod.Version);
                if (latestMod != null)
                {
                    if (modList.Contains(latestMod))
                    {
                        continue;
                    }

                    modList.Add(latestMod);

                    // search the dependencies
                    SearchMods(latestMod, modList);
                }
                else
                {
                    _logger.LogError("mod " + depMod.Name + " not found o.o");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public async Task<bool> DownloadMod(ModApiObject mod)
        {
            // check if mod need to download
            if (mod.IsInstalled() && !string.IsNullOrEmpty(mod.InstalledVersion) && !mod.IsNew())
            {
                _logger.LogInformation("{0} v{1} ({2}) already installed.", mod.Name, mod.Version, mod.GameVersion);

                return true;
            }

            _logger.LogInformation("downloading {0} v{1}...", mod.Name, mod.Version);
            Console.WriteLine(mod.Name);
            StatusHandler?.Invoke(null, new StatusEvent($"Downloading {mod.Name}..."));

            var tmpFileName = $"mod-{mod.Name}-{mod.Version}.zip";
            if (!await _httpHelper.DownloadFile(new Uri(ModApiBasicUrl + mod.Downloads.First().Url), tmpFileName))
            {
                _logger.LogError("Download failed");
                return false;
            }

            // extract
            _logger.LogInformation("Downloading finished. Extracting...");
            _fileHelper.Extract(tmpFileName, SettingsHandler.Instance.GetSettings().GamePath);

            // delete tmp file
            _logger.LogInformation("Deleting temporary download file...");
            File.Delete(tmpFileName);

            SettingsHandler.Instance.AddInstalledMod(mod);

            _logger.LogInformation("{0} v{1} installed", mod.Name, mod.Version);

            return true;
        }

        /// todo implement minVersion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modName"></param>
        /// <param name="minVersion"></param>
        /// <returns></returns>
        public ModApiObject GetLatestVersion(string modName, string minVersion)
        {
            var test = _mods.Where(mod => mod.Name.Equals(modName, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x.Version);

            return test.FirstOrDefault();
        }

        public bool UpdateGameVersion(string gameVersion)
        {
            if (_gameVersion == gameVersion)
            {
                return false;
            }

            _gameVersion = gameVersion;
            // add another actions?

            return true;
        }
    }
}