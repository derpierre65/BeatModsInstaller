using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;
using BeatSaberModInstaller.Models;
using Cr1TiKa7_Framework.Baseform;

namespace BeatSaberModInstaller
{
    public partial class FrmMain : Baseform
    {
        private readonly BeatModsHandler _beatModsHandler = new BeatModsHandler();
        private readonly BeatSaverHandler _beatSaverHandler = new BeatSaverHandler();
        public static string GameDirectory = "";

        public FrmMain()
        {
            InitializeComponent();

            _beatModsHandler.StatusHandler += (sender, e) =>
            {
                UpdateStatus(e.Message);
            };

#if DEBUG
            AllocConsole();
#endif
            if (File.Exists("path.txt"))
            {
                txtGameDirectory.Text = File.ReadAllText("path.txt");
            }
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            UpdateStatus("Loading mod list...");

            try
            {
                var modList = _beatModsHandler.GetModList();
                if (modList == null)
                {
                    UpdateStatus("Loading mod list failed.");
                    return;
                }

                foreach (var mod in modList.ToArray())
                {
                    lbMods.Items.Add(mod, mod.IsInstalled());
                }

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
            GameDirectory = txtGameDirectory.Text;
        }

        private async void OnInstallButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameDirectory.Text))
            {
                UpdateStatus("You need to select the Beat Saber directory.");

                return;
            }

            btnUpdateInstall.Enabled = false;

            var downloadsFinished = true;
            foreach (var item in lbMods.CheckedItems)
            {
                if (!(item is ModApiObject modObject)) continue;

                if (!await _beatModsHandler.DownloadMod(modObject, txtGameDirectory.Text))
                {
                    downloadsFinished = false;
                }
            }

            _beatModsHandler.ResetDownloadedMods();
            FileHelper.DeleteDirectory(FileHelper.TempDirectory);

            UpdateStatus(downloadsFinished ? "Download was successful." : "Download failed.");
            btnUpdateInstall.Enabled = true;
        }

        private void OnOpenLinkButtonClick(object sender, EventArgs e)
        {
            lbMods.SelectionMode = SelectionMode.MultiSimple;
            if (lbMods.SelectedItem is ModApiObject modObject && !string.IsNullOrWhiteSpace(modObject.Link))
            {
                System.Diagnostics.Process.Start(modObject.Link);
            }
        }

        private void UpdateStatus(string status)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker) delegate { UpdateStatus(status); });
            statusLabel.Text = $@"Status: {status}";
        }

        #region debug

#if DEBUG
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
#endif

        #endregion
    }
}