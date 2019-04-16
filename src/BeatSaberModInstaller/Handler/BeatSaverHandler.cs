using System;
using System.Linq;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models.BeatSaver;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class BeatSaverHandler
    {
        private const string BeatSaverUrl = "https://beatsaver.com/";
        private readonly HttpHelper _httpHelper;

        public BeatSaverHandler(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
        }

        public SongObject Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Console.WriteLine(@"empty string ;)");
                return null;
            }

            var songResult = _httpHelper.Get(BeatSaverUrl + "api/songs/search/all/" + searchText);
            if (songResult == null)
            {
                return null;
            }

            var foundSongs = JsonConvert.DeserializeObject<SongsObject>(songResult);

            Console.WriteLine(foundSongs.Songs.First().Difficulties);
            Console.WriteLine(foundSongs.Songs.First().CoverUrl);
            
            return new SongObject();
        }
    }
}