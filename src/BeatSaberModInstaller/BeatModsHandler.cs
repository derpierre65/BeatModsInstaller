using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using BeatSaberModInstaller.Models;
using Newtonsoft.Json;

namespace BeatSaberModInstaller
{
    public class BeatModsHandler
    {
        private const string ModApiBasicUrl = "https://beatmods.com";
        private const string ModApiUrl = "/api/v1/mod";

        public string DownloadDirectory = "downloads";

//        private readonly string _tmpFileName = ".\\mod.zip";
        private readonly List<string> _downloadedPackages = new List<string>();
        private IEnumerable<ModApiObject> _mods = new List<ModApiObject>();

        public List<ModApiObject> GetModList()
        {
            var ret = new List<ModApiObject>();
            using (var webClient = new WebClient())
            {
                var modResult = webClient.DownloadString(ModApiBasicUrl + ModApiUrl);
                _mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult);
                ret.AddRange(_mods
                    .Where(mod => !mod.Status.Equals("inactive", StringComparison.OrdinalIgnoreCase) && mod.Status.Equals("approved", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.Category)
                );
            }

            return ret;
        }

        public bool DownloadMod(ModApiObject mod, string destinationDirectory)
        {
            if (_downloadedPackages.Contains(mod.Name))
            {
                return true;
            }

            _downloadedPackages.Add(mod.Name);

            if (!Directory.Exists(DownloadDirectory))
            {
                Directory.CreateDirectory(DownloadDirectory);
            }

            using (var webClient = new WebClient())
            {
                var tmpFileName = $"download-{mod.Name}-{mod.Version}.zip";
                if (File.Exists(tmpFileName))
                {
                    File.Delete(tmpFileName);
                }

                webClient.DownloadFile(new Uri(ModApiBasicUrl + mod.Downloads.First().Url), tmpFileName);
                ExtractMod(tmpFileName, destinationDirectory);
                File.Delete(tmpFileName);
            }

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

            Debug.WriteLine("installed " + mod.Name + " v" + mod.Version);
            return true;
        }

        private void ExtractMod(string zipFile, string destinationDirectory)
        {
            ZipFile.ExtractToDirectory(zipFile, DownloadDirectory);
            CopyFiles(DownloadDirectory, destinationDirectory);
        }

        /// <summary>
        /// Moves files recursive to the destination directory.
        /// </summary>
        /// <param name="source">The source directory</param>
        /// <param name="destination">The destination directory</param>
        private static void CopyFiles(string source, string destination)
        {
            // create directory if not exists
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            // copy files from dir to newDestination
            foreach (var dir in Directory.GetDirectories(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(dir));
                CopyFiles(dir, newDestination);
            }

            foreach (var file in Directory.GetFiles(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(file));
                // delete file if exists (prevent error)
                if (File.Exists(newDestination))
                {
                    File.Delete(newDestination);
                }

                File.Move(file, newDestination);
            }
        }

        public void ResetDownloadedMods()
        {
            _downloadedPackages.Clear();
        }

        /**
         * delete a complete directory
         */
        public void DeleteDirectory(string directory = null)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = DownloadDirectory;
            }

            // delete directory recursive
            foreach (var dir in Directory.GetDirectories(directory))
            {
                DeleteDirectory(dir);
            }

            // delete all files in directory
            foreach (var file in Directory.GetFiles(directory))
            {
                File.Delete(file);
            }

            // delete directory complete
            Directory.Delete(directory);
        }
    }
}