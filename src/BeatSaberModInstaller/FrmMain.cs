using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BeatSaberModInstaller.Core;
using BeatSaberModInstaller.Handler;
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

//        private readonly SettingsHandler _settingsHandler;
        private readonly StandardKernel _kernel = new StandardKernel(new MainKernel());

        public FrmMain()
        {
            InitializeComponent();

#if DEBUG
            AllocConsole();
#endif

            // Gets the needed classes
            _beatSaverHandler = _kernel.Get<BeatSaverHandler>();
            _fileHelper = _kernel.Get<FileHelper>();
//            _settingsHandler = _kernel.Get<SettingsHandler>();
            _beatModsHandler = _kernel.Get<BeatModsHandler>();
            _beatModsHandler.StatusHandler += (sender, e) => { UpdateStatus(e.Message); };
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            var index = 0;
            if (SettingsHandler.Instance.GetSettings().GameVersion != null)
            {
                index = comboBoxGameVersion.Items.IndexOf(SettingsHandler.Instance.GetSettings().GameVersion);
                if (index == -1)
                {
                    index = 0;
                }
            }

            // select last selected game version
            _beatModsHandler.UpdateGameVersion(comboBoxGameVersion.Items[index].ToString());
//            comboBoxGameVersion.Select(index,1);
            comboBoxGameVersion.SelectedIndex = index;

            var gamePath = SettingsHandler.Instance.GetSettings().GamePath;
            txtGamePath.Text = gamePath; // this call UpdateModList(); - fix and call it manually
//            _beatSaverHandler.GetInstalled(gamePath);
        }

        private void UpdateModList()
        {
            UpdateStatus("Loading mod list for Beat Saber v" + SettingsHandler.Instance.GetSettings().GameVersion + "...");

            try
            {
                var modList = _beatModsHandler.GetModList();
                if (modList == null)
                {
                    throw new Exception();
                }

                lbMods.Items.Clear();

                foreach (var mod in modList.ToArray())
                {
                    // todo remove mods from installedmods list if this mod file is not installed and remove second if
                    lbMods.Items.Add(mod, mod.IsInstalled() || !string.IsNullOrEmpty(mod.InstalledVersion));
                }

                UpdateStatus("Mod list loaded for Beat Saber v" + SettingsHandler.Instance.GetSettings().GameVersion + ".");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            var settings = SettingsHandler.Instance.GetSettings();
            settings.GamePath = txtGamePath.Text;
            SettingsHandler.Instance.SaveSettings(settings);
            UpdateModList();
        }

        private async void OnInstallButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                UpdateStatus("You need to select the Beat Saber directory.");

                return;
            }

            btnUpdateInstall.Enabled = false;

            var downloadList = new List<ModApiObject>();
            foreach (var item in lbMods.CheckedItems)
            {
                if (!(item is ModApiObject modObject)) continue;

                _beatModsHandler.SearchMods(modObject, downloadList);
            }

            foreach (var mod in downloadList)
            {
                await _beatModsHandler.DownloadMod(mod);
            }

            SettingsHandler.Instance.SaveSettings();

            // delete directory and reset download mod list
            _fileHelper.DeleteDirectory(FileHelper.TempDirectory);

            // enable install button
            btnUpdateInstall.Enabled = true;

            UpdateModList();
            UpdateStatus("Download finished");
        }

        private void OnOpenLinkButtonClick(object sender, EventArgs e)
        {
            if (lbMods.SelectedItem is ModApiObject modObject && !string.IsNullOrWhiteSpace(modObject.Link))
            {
                Console.WriteLine(modObject.Link);
                System.Diagnostics.Process.Start(modObject.Link);
            }
        }

        private void UpdateStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) delegate { UpdateStatus(status); });
            }

            statusLabel.Text = $@"Status: {status}";
        }

        #region debug

#if DEBUG
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
#endif

        #endregion

        private void OnSongSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OnSongSearch();
            }
        }

        private void OnSongSearch(object sender, EventArgs e)
        {
            OnSongSearch();
        }

        private void OnGameVersionChange(object sender, EventArgs e)
        {
            var selectedGameVersion = comboBoxGameVersion.SelectedItem.ToString();
            if (!_beatModsHandler.UpdateGameVersion(selectedGameVersion))
            {
                return;
            }

            UpdateModList();
            var settings = SettingsHandler.Instance.GetSettings();
            settings.GameVersion = selectedGameVersion;
            SettingsHandler.Instance.SaveSettings(settings);
        }

        private void OnSongSearch()
        {
            btnSearchSong.Enabled = false;
            txtSearchSongTitle.Enabled = false;

            var foundSongs = _beatSaverHandler.SearchSong(txtSearchSongTitle.Text);
            //In case that the songs list is null return.
            if (foundSongs?.Songs == null)
            {
                btnSearchSong.Enabled = true;
                txtSearchSongTitle.Enabled = true;

                return;
            }

            panelSongs.Controls.Clear();

            var item = 0;
            foreach (var song in foundSongs.Songs)
            {
                var picture = new PictureBox
                {
                    Location = new Point(5, (96 + 10) * item),
                    Width = 96,
                    Height = 96,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                var label = new Label
                {
                    AutoSize = true,
                    Location = new Point(5 + 96, (96 + 10) * item + 28),
                    ForeColor = Color.White,
                    Text = $"{song.SongName} - " + $"{song.AuthorName}\n" +
                           $"Downloads: {song.DownloadCount}\n" +
                           $"Played: {song.PlayedCount}"
                };
                var label1 = new Label
                {
                    AutoSize = true,
                    Location = new Point(5 + 96 + 100, (96 + 10) * item + 28),
                    ForeColor = Color.White,
                    Text = @"\uf000"
                };
                var installButton = new Cr1TiKa7_Framework.Controls.Button.FlatButton
                {
                    // 5 padding from pictureBox, 96 picture size, + 5 padding
                    Location = new Point(5 + 96 + 5, (96 + 10) * item),
                    Text = "Install",
                    Width = 100,
                    Height = 28,
                    Enabled = !song.IsInstalled()
                };
                installButton.Click += async (sender, e) =>
                {
                    var success = true;
                    if (!song.IsInstalled())
                    {
                        success = await song.Install();
                    }

                    installButton.Enabled = !success;
                };

                picture.LoadAsync(song.CoverUrl);
                panelSongs.Controls.Add(label);
                panelSongs.Controls.Add(label1);
                panelSongs.Controls.Add(picture);
                panelSongs.Controls.Add(installButton);
                item++;
            }

            lbSongs.Visible = false;
            btnSearchSong.Enabled = true;
            txtSearchSongTitle.Enabled = true;
        }
    }
}