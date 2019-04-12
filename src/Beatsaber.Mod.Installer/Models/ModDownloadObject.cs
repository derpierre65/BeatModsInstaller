﻿using System.Collections.Generic;

namespace Beatsaber.Mod.Installer.Models
{
    public class ModDownloadObject
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public IEnumerable<ModDownloadHashMd5Object> HashMd5 { get; set; } = new List<ModDownloadHashMd5Object>();
    }
}