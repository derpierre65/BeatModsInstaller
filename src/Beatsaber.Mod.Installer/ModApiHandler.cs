using System.Collections.Generic;
using System.Linq;
using System.Net;
using Beatsaber.Mod.Installer.Models;
using Newtonsoft.Json;

namespace Beatsaber.Mod.Installer
{
    public class ModApiHandler
    {
        public List<ModApiObject> GetMods()
        {
            var ret = new List<ModApiObject>();
            using (var webClient = new WebClient())
            {
                var modResult = webClient.DownloadString("https://beatmods.com/api/v1/mod");
                var mods = JsonConvert.DeserializeObject<IEnumerable<ModApiObject>>(modResult);
                ret.AddRange(mods.Where(x=>!x.Status.Equals("inactive",System.StringComparison.OrdinalIgnoreCase)).OrderBy(x=>x.Category));
            }
            return ret;
        }

    }
}
