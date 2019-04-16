using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;
using BeatSaberModInstaller.Models;
using BeatSaberModInstaller.Models.BeatMods;
using Cr1TiKa7_Framework.Baseform;
using Ninject;

namespace BeatSaberModInstaller
{
    public partial class FrmMain : Baseform
    {
        private readonly BeatModsHandler _beatModsHandler;
        private readonly BeatSaverHandler _beatSaverHandler;
        private readonly FileHelper _fileHelper;
        private readonly SettingsHandler _settingsHandler;
        private readonly Settings _settings;
        private StandardKernel _kernel = new StandardKernel(new MainKernel());

        public FrmMain()
        {
            InitializeComponent();

            // Gets the needed classes
            _beatModsHandler = _kernel.Get<BeatModsHandler>();
            _beatSaverHandler = _kernel.Get<BeatSaverHandler>();
            _fileHelper = _kernel.Get<FileHelper>();
            _settingsHandler = _kernel.Get<SettingsHandler>();

            _beatModsHandler.StatusHandler += (sender, e) =>
            {
                UpdateStatus(e.Message);
            };

#if DEBUG
            AllocConsole();
#endif
            _settings = _settingsHandler.GetSettings();
            txtGamePath.Text = _settings.GamePath;
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
                    lbMods.Items.Add(mod, mod.IsInstalled(_settings.GamePath));
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
                    txtGamePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void OnGameDirectoryChanged(object sender, EventArgs e)
        {
            _settings.GamePath = txtGamePath.Text;
            _settingsHandler.SaveSettings(_settings);
        }

        private async void OnInstallButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                UpdateStatus("You need to select the Beat Saber directory.");

                return;
            }

            btnUpdateInstall.Enabled = false;

            var downloadsFinished = true;
            foreach (var item in lbMods.CheckedItems)
            {
                if (!(item is ModApiObject modObject)) continue;

                if (!await _beatModsHandler.DownloadMod(modObject, txtGamePath.Text))
                {
                    downloadsFinished = false;
                }
            }

            _beatModsHandler.ResetDownloadedMods();
            _fileHelper.DeleteDirectory(FileHelper.TempDirectory);

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