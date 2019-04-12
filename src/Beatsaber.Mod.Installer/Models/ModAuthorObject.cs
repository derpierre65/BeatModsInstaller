using System;
using Newtonsoft.Json;

namespace Beatsaber.Mod.Installer.Models
{
    public class ModAuthorObject
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime LastLogin { get; set; }
    }
}