using System;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Models.BeatSaver;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BeatSaberModInstaller.Handler
{
    public class BeatSaverHandler
    {
        private const string BeatSaverUrl = "https://beatsaver.com/api/songs/";
        private readonly HttpHelper _httpHelper;
        private readonly ILogger _logger;

        public BeatSaverHandler(HttpHelper httpHelper, ILogger logger)
        {
            _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public SongsObject SearchSong(string searchText)
        {
            _logger.LogInformation("Searching for songs by '{0}'...", searchText);
            return !string.IsNullOrWhiteSpace(searchText) ? GetSongsByEndpoint("search/all/" + searchText) : null;
        }

        public SongsObject SearchSongsByUser(string username)
        {
            _logger.LogInformation("Searching for songs by the user '{0}'...", username);
            return !string.IsNullOrWhiteSpace(username) ? GetSongsByEndpoint("byuser/" + username) : null;
        }

        public SongsObject GetTopDownloadedSongs()
        {
            _logger.LogInformation("Getting the top downloaded songs...");
            return GetSongsByEndpoint("top/");
        }

        public SongsObject GetTopPlayedSongs()
        {
            _logger.LogInformation("Getting the top played songs...");
            return GetSongsByEndpoint("plays/");
        }

        public SongsObject GetNewestSongs()
        {
            _logger.LogInformation("Getting the newest songs...");
            return GetSongsByEndpoint("new/");
        }

        public SongsObject GetTopRatedSongs()
        {
            _logger.LogInformation("Getting the top rated songs...");
            return GetSongsByEndpoint("rated/");
        }

        private SongsObject GetSongsByEndpoint(string endpoint)
        {
            var songResult = _httpHelper.Get(BeatSaverUrl + endpoint);
            Console.WriteLine(BeatSaverUrl + endpoint + " -> " + songResult);

            if (songResult == null)
            {
                _logger.LogInformation("Couldn't find any songs.");
                return null;
            }

            var foundSongs = JsonConvert.DeserializeObject<SongsObject>(songResult);

            _logger.LogInformation("Found '{0}' songs.", foundSongs?.Total);
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