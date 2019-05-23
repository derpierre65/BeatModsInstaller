using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BeatSaberModInstaller.Handler;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Models.BeatMods
{
    public class ModApiObject
    {
        [JsonProperty(PropertyName = "_id")] public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string GameVersion { get; set; }
        public string AuthorId { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ModAuthorObject Author { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
        public IEnumerable<ModDownloadObject> Downloads { get; set; } = new List<ModDownloadObject>();
        public bool Required { get; set; }
        public IEnumerable<ModDependencyObject> Dependencies { get; set; } = new List<ModDependencyObject>();

        private string _installedVersion;

        public string InstalledVersion
        {
            get
            {
                if (_installedVersion != null)
                {
                    return _installedVersion;
                }

                _installedVersion = "";

                var installedMod = SettingsHandler.Instance.GetSettings().InstalledMods.FirstOrDefault(mod => mod.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
                if (installedMod != null)
                {
                    _installedVersion = installedMod.Version;
                }

                return _installedVersion;
            }
        }

        private int? _versionInfo;

        public int? VersionInfo
        {
            get
            {
                if (_versionInfo != null) return _versionInfo;

                // InstalledVersion is empty -> return -1 for new version available
                if (string.IsNullOrEmpty(InstalledVersion))
                {
                    return -1;
                }

                // compare version
                _versionInfo = new Version(InstalledVersion).CompareTo(new Version(Version));

                return _versionInfo;
            }
        }

        /// <summary>
        /// check if this mod is installed
        /// </summary>
        public bool IsInstalled()
        {
            var completeInstalled = Downloads.First().HashMd5.Aggregate(true, (current, hash) => current & File.Exists(SettingsHandler.Instance.GetSettings().GamePath + "/" + hash.File));

            return completeInstalled; //File.Exists(SettingsHandler.Instance.GetSettings().GamePath + "/" + Downloads.First().HashMd5.First().File);
        }

        /// <summary>
        /// check if for this mod is a new version available
        /// </summary>
        /// <returns></returns>
        public bool IsNew()
        {
            if (!IsInstalled() || string.IsNullOrEmpty(InstalledVersion))
            {
                return false;
            }

            // -1 = new version available
            return VersionInfo == -1;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Category + " | "
                            + Name + " | "
                            + Author.Username + " | "
                            + Version + " | "
                            + UploadDate
                            + (!string.IsNullOrEmpty(InstalledVersion) ? " | installed: " + InstalledVersion : "")
                            + (IsNew() ? " | NEW VERSION" : "");
        }
    }
}