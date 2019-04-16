using System.Collections.Generic;

namespace BeatSaberModInstaller.Models.BeatSaver
{
    public class SongsObject
    {
        public IEnumerable<SongObject> Songs { get; set; } = new List<SongObject>();
        public int Total { get; set; }
    }
}