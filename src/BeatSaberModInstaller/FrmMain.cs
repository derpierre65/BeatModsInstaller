using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BeatSaberModInstaller.Models;
using Cr1TiKa7_Framework.Baseform;

namespace BeatSaberModInstaller
{
    public partial class FrmMain : Baseform
    {
        private readonly BeatModsHandler _beatModsHandler = new BeatModsHandler();

        public FrmMain()
        {
            InitializeComponent();

#if DEBUG
            AllocConsole();

            if (File.Exists("path.txt"))
            {
                txtGameDirectory.Text = File.ReadAllText("path.txt");
            }
#endif
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            try
            {
                lbMods.Items.AddRange(_beatModsHandler.GetModList().ToArray());
                UpdateStatus("Mod list loaded.");
            }
            catch (Exception ex)
            {
                UpdateStatus("Loading mod list failed.");
            }
        }

        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGameDirectory.Text = fbd.SelectedPath;
                }
            }
        }

        private void OnGameDirectoryChanged(object sender, EventArgs e)
        {
            File.WriteAllText("path.txt", txtGameDirectory.Text);
        }

        private void OnInstallButtonClick(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameDirectory.Text))
            {
                UpdateStatus("You need to select the Beat Saber directory.");

                return;
            }

            _beatModsHandler.DownloadDirectory = Path.Combine(txtGameDirectory.Text, "downloads");
            var downloadsFinished = true;
            foreach (var item in lbMods.CheckedItems)
            {
                if (!(item is ModApiObject modObject)) continue;

                UpdateStatus($"Downloading {modObject.Name}...");
                if (!_beatModsHandler.DownloadMod(modObject, txtGameDirectory.Text))
                    downloadsFinished = false;
            }

            _beatModsHandler.ResetDownloadedMods();
            _beatModsHandler.DeleteDirectory();

            UpdateStatus(downloadsFinished ? "Download was successful." : "Download failed.");
        }

        private void UpdateStatus(string status)
        {
            statusLabel.Text = @"Status: " + status;
        }

#if DEBUG
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
#endif
    }
}