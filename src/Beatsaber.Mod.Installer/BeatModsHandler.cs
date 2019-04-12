using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using Beatsaber.Mod.Installer.Models;
using Newtonsoft.Json;

namespace Beatsaber.Mod.Installer
{
    public class BeatModsHandler
    {
        public string DownloadDirectory = "downloads";
        private string _tmpFileName = ".\\download.zip";
        private List<string> _downloadedPackages = new List<string>();
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();
        
        public List<ModApiObject> GetModList()
        {
            var ret = new List<ModApiObject>();
            using (var webClient = new WebClient())
            {
                var modResult = webClient.DownloadString("https://beatmods.com/api/v1/mod");
                _mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult);
                ret.AddRange(_mods.Where(x=>!x.Status.Equals("inactive",System.StringComparison.OrdinalIgnoreCase)).OrderBy(x=>x.Category));
            }
            return ret;
        }

        public bool DownloadMod(ModApiObject mod, string destinationDirectory)
        {
            if (_downloadedPackages.Contains(mod.Name))
                return true;
            _downloadedPackages.Add(mod.Name);
            var ret = false;

            if (!Directory.Exists(DownloadDirectory))
                Directory.CreateDirectory(DownloadDirectory);

            using (var webClient = new WebClient())
            {
                if (File.Exists(_tmpFileName))
                    File.Delete(_tmpFileName);
                webClient.DownloadFile(new Uri("https://beatmods.com" + mod.Downloads.First().Url), _tmpFileName);
                ExtractMod(_tmpFileName, destinationDirectory);
            }

            if (mod is ModDependencyObject dependencyMod)
            {
                foreach (var dependency in dependencyMod.Dependencies)
                {
                    var depMod = _mods.FirstOrDefault(x => x.Id == dependency);
                    if (depMod != null)
                        DownloadMod(depMod, destinationDirectory);
                }
            }
            else
            {
                foreach (var dependency in mod.Dependencies)
                {
                    DownloadMod(dependency, destinationDirectory);
                }
            }
            ret = true;
            Debug.WriteLine(mod.Name);
            return ret;
        }

        private void ExtractMod(string zipFile, string destinationDirectory)
        {
            DeleteDirectory(DownloadDirectory);
            ZipFile.ExtractToDirectory(zipFile, DownloadDirectory);
            CopyFiles(DownloadDirectory, destinationDirectory);
        }

        /// <summary>
        /// Moves files recursive to the destination directory.
        /// </summary>
        /// <param name="source">The source directory</param>
        /// <param name="destination">The destination directory</param>
        private void CopyFiles(string source, string destination)
        {
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            foreach (var dir in Directory.GetDirectories(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(dir));
                CopyFiles(dir, newDestination);
            }

            foreach (var file in Directory.GetFiles(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(file));
                if (File.Exists(newDestination))
                    File.Delete(newDestination);
                File.Move(file, newDestination);
            }
        }

        public void ResetDownloadedMods()
        {
            _downloadedPackages.Clear();
        }

        public void DeleteDirectory(string directory = "")
        {
            if (string.IsNullOrWhiteSpace(directory))
                directory = DownloadDirectory;

            foreach (var dir in Directory.GetDirectories(directory))
            {
                DeleteDirectory(dir);
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                File.Delete(file);
            }

            Directory.Delete(directory);
        }
    }
}
