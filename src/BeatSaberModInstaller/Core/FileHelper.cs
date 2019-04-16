using System.IO;
using System.IO.Compression;

namespace BeatSaberModInstaller.Core
{
    public class FileHelper
    {
        public const string TempDirectory = "./downloads";
        
        /// <summary>
        /// Deletes a directory which is not empty.
        /// </summary>
        /// <param name="directory">Path of the directory</param>
        public void DeleteDirectory(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) return;

            // delete directory recursive
            foreach (var dir in Directory.GetDirectories(directory))
            {
                DeleteDirectory(dir);
            }

            // delete all files in directory
            foreach (var file in Directory.GetFiles(directory))
            {
                File.Delete(file);
            }

            // delete directory complete
            Directory.Delete(directory);
        }

        /// <summary>
        /// Extracts a zipfile into the desitination directory.
        /// </summary>
        /// <param name="zipFile">Path of the zipfile.</param>
        /// <param name="destinationDirectory">Path to the destination directory.</param>
        public void Extract(string zipFile, string destinationDirectory)
        {
            ZipFile.ExtractToDirectory(zipFile, TempDirectory);
            CopyFiles(TempDirectory, destinationDirectory);
        }

        /// <summary>
        /// Moves files recursive to the destination directory.
        /// </summary>
        /// <param name="source">The source directory</param>
        /// <param name="destination">The destination directory</param>
        public void CopyFiles(string source, string destination)
        {
            // create directory if not exists
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            // copy files from dir to newDestination
            foreach (var dir in Directory.GetDirectories(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(dir));
                CopyFiles(dir, newDestination);
            }

            foreach (var file in Directory.GetFiles(source))
            {
                var newDestination = Path.Combine(destination, Path.GetFileName(file));
                // delete file if exists (prevent error)
                if (File.Exists(newDestination))
                {
                    File.Delete(newDestination);
                }

                File.Move(file, newDestination);
            }
        }
    }
}