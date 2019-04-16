using System;
using System.Linq;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models.BeatSaver;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class BeatSaverHandler
    {
        private const string BeatSaverUrl = "https://beatsaver.com/api/";
        private readonly HttpHelper _httpHelper;

        public BeatSaverHandler(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
        }

        public SongObject SearchSong(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                Console.WriteLine(@"empty string ;)");
                return null;
            }

            return GetSongsByEndpoint( "songs/search/all/" + searchText);
        }

        public SongObject SearchSongsByUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine(@"empty string ;)");
                return null;
            }

            return GetSongsByEndpoint("songs/byuser/" + username);
        }

        public SongObject GetTopDownloadedSongs()
        {
            return GetSongsByEndpoint("songs/top/");
        }

        public SongObject GetTopPlayedSongs()
        {
            return GetSongsByEndpoint("songs/plays/");
        }

        public SongObject GetNewestSongs()
        {
            return GetSongsByEndpoint("songs/new/");
        }

        public SongObject GetTopRatedSongs()
        {
            return GetSongsByEndpoint("songs/rated/");
        }

        private SongObject GetSongsByEndpoint(string endpoint)
        {
            var songResult = _httpHelper.Get(BeatSaverUrl + endpoint);
            if (songResult == null)
                return null;

            var foundSongs = JsonConvert.DeserializeObject<SongsObject>(songResult);

#if Debug
            Console.WriteLine(foundSongs.Songs.First().Difficulties);
            Console.WriteLine(foundSongs.Songs.First().CoverUrl);
#endif 

            return new SongObject();
        }
    }
}