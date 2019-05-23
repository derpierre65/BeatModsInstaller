using BeatSaberModInstaller.Models.BeatMods;

namespace BeatSaberModInstaller.Models
{
    public class SettingsModObject
    {
        public string Name { get; set; }
        public string Version { get; set; }
        
        public void SetMod(ModApiObject mod)
        {
            Name = mod.Name;
            Version = mod.Version;
        }
    }
}