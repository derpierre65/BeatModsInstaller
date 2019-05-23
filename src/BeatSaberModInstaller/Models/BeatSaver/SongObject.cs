using System;
using System.IO;
using System.Threading.Tasks;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;

namespace BeatSaberModInstaller.Models.BeatSaver
{
    public class SongObject
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uploader { get; set; }
        public int UploaderId { get; set; }
        public string SongName { get; set; }
        public string SongSubName { get; set; }
        public string AuthorName { get; set; }
        public int Bpm { get; set; }
        public int DownloadCount { get; set; }
        public int PlayedCount { get; set; }
        public int UpVotes { get; set; }
        public int UpVotesTotal { get; set; }
        public int DownVotes { get; set; }
        public int DownVotesTotal { get; set; }
        public float Rating { get; set; }
        public string Version { get; set; }
        public string LinkUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string CoverUrl { get; set; }
        public string HashMd5 { get; set; }
        public string HashSha1 { get; set; }
        public SongDifficultiesObject Difficulties { get; set; }

        private string GetSongDirectory()
        {
            return SettingsHandler.Instance.GetSettings().GamePath + "/CustomSongs/" + Key+"/";
        }

        public bool IsInstalled()
        {
            return Directory.Exists(GetSongDirectory());
        }

        public bool Delete()
        {
            if (!IsInstalled())
            {
                return true;
            }
            
            FileHelper.Instance.DeleteDirectory(GetSongDirectory());

            return false;
        }

        public async Task<bool> Install()
        {
            if (IsInstalled())
            {
                return true;
            }

            var tmpFileName = $"song-{Key}.zip";
            if (!await HttpHelper.Instance.DownloadFile(new Uri(DownloadUrl), tmpFileName))
            {
                return false;
            }

            FileHelper.Instance.Extract(tmpFileName, GetSongDirectory());
            File.Delete(tmpFileName);

            return true;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return SongName;
        }
    }
}