using System;
using System.IO;
using System.Net;

namespace BeatSaberModInstaller.Core
{
    public static class HttpHelper
    {
        public static readonly WebClient WebClient = new WebClient();

        public static string Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            try
            {
                return WebClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static bool DownloadFile(Uri uri, string filename, bool overwrite = true)
        {
            if (!Directory.Exists(FileHelper.TempDirectory))
            {
                Directory.CreateDirectory(FileHelper.TempDirectory);
            }

            if (File.Exists(filename))
            {
                if (overwrite)
                {
                    File.Delete(filename);
                }
                // return false -> file exists and should not overwrite
                else
                {
                    return false;
                }
            }

            WebClient.DownloadFile(uri, filename);

            return File.Exists(filename);
        }
    }
}