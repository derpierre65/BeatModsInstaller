using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class StatusEvent : EventArgs
    {
        public string Message { get; set; }

        public StatusEvent(string msg)
        {
            Message = msg;
        }
    }

    public class BeatModsHandler
    {
        public event EventHandler<StatusEvent> StatusHandler;
        
        private const string ModApiBasicUrl = "https://beatmods.com";
        private const string ModApiUrl = "/api/v1/mod";

//        private readonly string _tmpFileName = ".\\mod.zip";
        private readonly List<string> _downloadedPackages = new List<string>();
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();

        public List<ModApiObject> GetModList()
        {
            var modResult = HttpHelper.Get(ModApiBasicUrl + ModApiUrl);
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

        public bool DownloadMod(ModApiObject mod, string destinationDirectory)
        {
            if (_downloadedPackages.Contains(mod.Name))
            {
                return true;
            }
            _downloadedPackages.Add(mod.Name);
            
            StatusHandler?.Invoke(null, new StatusEvent($"Downloading {mod.Name}..."));

            var tmpFileName = $"mod-{mod.Name}-{mod.Version}.zip";
            if (!HttpHelper.DownloadFile(new Uri(ModApiBasicUrl + mod.Downloads.First().Url), tmpFileName))
            {
                // update status
                return false;
            }
            FileHelper.Extract(tmpFileName, destinationDirectory);
            File.Delete(tmpFileName);

            if (mod is ModDependencyObject dependencyMod)
            {
                foreach (var dependency in dependencyMod.Dependencies)
                {
                    var depMod = _mods.FirstOrDefault(x => x.Id == dependency);
                    if (depMod != null)
                    {
                        DownloadMod(depMod, destinationDirectory);
                    }
                }
            }
            else
            {
                foreach (var dependency in mod.Dependencies)
                {
                    DownloadMod(dependency, destinationDirectory);
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