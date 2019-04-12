using System.Collections.Generic;

namespace Beatsaber.Mod.Installer.Models
{
    public class ModDependencyObject : ModApiObject
    {
        public new IEnumerable<string> Dependencies { get; set; } = new List<string>();
    }
}
