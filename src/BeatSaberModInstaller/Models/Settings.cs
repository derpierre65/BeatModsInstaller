using System.Collections.Generic;

namespace BeatSaberModInstaller.Models
{
    public class Settings
    {
        public string GamePath { get; set; }
        public string GameVersion { get; set; }

        public IEnumerable<SettingsModObject> InstalledMods { get; set; } = new List<SettingsModObject>();
    }
}