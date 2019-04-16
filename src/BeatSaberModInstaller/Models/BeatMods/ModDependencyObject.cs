using System.Collections.Generic;

namespace BeatSaberModInstaller.Models.BeatMods
{
    public class ModDependencyObject : ModApiObject
    {
        public new IEnumerable<string> Dependencies { get; set; } = new List<string>();
    }
}
