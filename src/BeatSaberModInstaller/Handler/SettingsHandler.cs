﻿using System.IO;
using System.Linq;
using BeatSaberModInstaller.Models;
using BeatSaberModInstaller.Models.BeatMods;
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

        public void SaveSettings(Settings settings = null)
        {
            if (settings == null)
            {
                settings = _settings;
            }

            using (var streamWriter = new StreamWriter(SettingsPath))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(settings));
            }

            // set current settings
            _settings = settings;
        }

        public void AddInstalledMod(ModApiObject mod, bool forceSave = false)
        {
            // search mod and update
            var installedMod = _settings.InstalledMods.FirstOrDefault(x =>
            {
                if (x.Name != mod.Name) return false;

                x.SetMod(mod);
                return true;
            });

            // mod not found -> new
            if (installedMod == null)
            {
                installedMod = new SettingsModObject();
                installedMod.SetMod(mod);

                var installedMods = _settings.InstalledMods.ToList();
                installedMods.Add(installedMod);

                _settings.InstalledMods = installedMods.AsEnumerable();
            }

            if (forceSave)
            {
                SaveSettings();
            }
        }
    }
}