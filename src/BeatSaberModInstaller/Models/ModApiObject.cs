using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Models
{
    public class ModApiObject
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
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

        public bool IsInstalled()
        {
            return File.Exists(FrmMain.GameDirectory + "/" + Downloads.First().HashMd5.First().File);
        }

        public override string ToString()
        {
            return Category + " | " + Name + " | " + Author.Username + " | " + Version;
        }
    }
}