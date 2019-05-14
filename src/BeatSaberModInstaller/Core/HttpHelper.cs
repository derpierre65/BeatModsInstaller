using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BeatSaberModInstaller.Core
{
    public class HttpHelper : IDisposable
    {
        private readonly WebClient _webClient = new WebClient();
        private static HttpHelper _instance;
        public static HttpHelper Instance => _instance ?? (_instance = new HttpHelper());

        public string Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;

            try
            {
                return _webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> DownloadFile(Uri uri, string filename, bool overwrite = true)
        {
            return await Task.Run(() =>
            {
                if (!Directory.Exists(FileHelper.TempDirectory))
                    Directory.CreateDirectory(FileHelper.TempDirectory);

                if (File.Exists(filename))
                {
                    if (overwrite)
                        File.Delete(filename);
                    // return false -> file exists and should not be overwritten
                    else
                        return false;
                }

                _webClient.DownloadFile(uri, filename);

                return File.Exists(filename);
            });
        }

        public void Dispose()
        {
            _webClient?.Dispose();
        }
    }
}