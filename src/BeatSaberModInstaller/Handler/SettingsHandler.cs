using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaberModInstaller.Models;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class SettingsHandler
    {
        private string _settingsPath = "./settings.json";

        public Settings GetSettings()
        {
            var ret = new Settings();

            if (!File.Exists(_settingsPath))
                return ret;

            using (var streamReader = new StreamReader(_settingsPath))
            {
                ret = JsonConvert.DeserializeObject<Settings>(streamReader.ReadToEnd());
            }

            return ret;
        }

        public void SaveSettings(Settings settings)
        {
            using (var streamWriter = new StreamWriter(_settingsPath))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(settings));
            }
        }
    }
}