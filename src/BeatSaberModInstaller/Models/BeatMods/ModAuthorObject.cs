using System;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Models.BeatMods
{
    public class ModAuthorObject
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime LastLogin { get; set; }
    }
}