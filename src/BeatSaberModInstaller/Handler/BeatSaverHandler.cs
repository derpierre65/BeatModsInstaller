using System;
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

        public SongsObject SearchSong(string searchText)
        {
            return !string.IsNullOrWhiteSpace(searchText) ? GetSongsByEndpoint("songs/search/all/" + searchText) : null;
        }

        public SongsObject SearchSongsByUser(string username)
        {
            return !string.IsNullOrWhiteSpace(username) ? GetSongsByEndpoint("songs/byuser/" + username) : null;
        }

        public SongsObject GetTopDownloadedSongs()
        {
            return GetSongsByEndpoint("songs/top/");
        }

        public SongsObject GetTopPlayedSongs()
        {
            return GetSongsByEndpoint("songs/plays/");
        }

        public SongsObject GetNewestSongs()
        {
            return GetSongsByEndpoint("songs/new/");
        }

        public SongsObject GetTopRatedSongs()
        {
            return GetSongsByEndpoint("songs/rated/");
        }

        private SongsObject GetSongsByEndpoint(string endpoint)
        {
            var songResult = _httpHelper.Get(BeatSaverUrl + endpoint);
            Console.WriteLine(BeatSaverUrl + endpoint + " -> " + songResult);
            
            if (songResult == null) return null;

            var foundSongs = JsonConvert.DeserializeObject<SongsObject>(songResult);

            return foundSongs;
        }

        public void GetInstalled()
        {
            /*foreach (var dir in Directory.GetDirectories())
            {
            }*/
        }
    }
}