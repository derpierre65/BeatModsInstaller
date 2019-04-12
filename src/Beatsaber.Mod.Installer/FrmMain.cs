using System;
using System.IO;
using System.Windows.Forms;
using Beatsaber.Mod.Installer.Models;
using Cr1TiKa7_Framework.Baseform;

namespace Beatsaber.Mod.Installer
{
    public partial class FrmMain : Baseform
    {
        private readonly BeatModsHandler _beatModsHandler = new BeatModsHandler();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void OnFrmShown(object sender, System.EventArgs e)
        {
            try
            {
                lbMods.Items.AddRange(_beatModsHandler.GetModList().ToArray());
                lblStatus.Text = "Status: Mod list loaded.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: Loading mod list failed.";
            }
        }

        private void OnBtnClick(object sender, System.EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGameDirectory.Text = fbd.SelectedPath;
                }
            }
        }

        private void OnBtnInstallClick(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameDirectory.Text))
            {
                MessageBox.Show(this, "You need to select the plugins directory.", "No directory selected.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _beatModsHandler.DownloadDirectory = Path.Combine(txtGameDirectory.Text, "downloads");
            var downloadsFinished = true;
            lblStatus.Text = "Status: Download started...";
            foreach (var item in lbMods.CheckedItems)
            {
                if (item is ModApiObject modObject)
                {
                    lblStatus.Text = $"Status: Downloading '{modObject.Name}'...";
                    if (!_beatModsHandler.DownloadMod(modObject, txtGameDirectory.Text))
                        downloadsFinished = false;
                }
            }

            _beatModsHandler.ResetDownloadedMods();
            _beatModsHandler.DeleteDirectory();
            if (downloadsFinished)
                lblStatus.Text = "Status: Download was successful.";
            else
                lblStatus.Text = "Status: Download failed!";
        }
    }
}
