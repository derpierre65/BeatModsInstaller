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
        /**
         * settings json directory path
         */
        private const string SettingsPath = "./settings.json";

        /**
         * SettingsHandler instance
         */
        private static SettingsHandler _instance;

        /**
         * loaded settings
         */
        private Settings _settings;

        /**
         * public SettingsHandler instance
         */
        public static SettingsHandler Instance => _instance ?? (_instance = new SettingsHandler());

        public Settings GetSettings()
        {
            return _settings ?? (_settings = GetFileSettings());
        }

        public Settings GetFileSettings()
        {
            var ret = new Settings();

            if (!File.Exists(SettingsPath))
            {
                return ret;
            }

            using (var streamReader = new StreamReader(SettingsPath))
            {
                ret = JsonConvert.DeserializeObject<Settings>(streamReader.ReadToEnd());
            }

            return ret;
        }

        public void SaveSettings(Settings settings)
        {
            using (var streamWriter = new StreamWriter(SettingsPath))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(settings));
            }
        }
    }
}