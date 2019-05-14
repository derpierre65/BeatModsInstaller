using System.Windows.Forms;

namespace BeatSaberModInstaller
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtGamePath = new Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox();
            this.btnBrowse = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.customTabControl1 = new Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl();
            this.tpMods = new System.Windows.Forms.TabPage();
            this.btnUpdateInstall = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.lbMods = new System.Windows.Forms.CheckedListBox();
            this.tpSongs = new System.Windows.Forms.TabPage();
            this.panelSongs = new System.Windows.Forms.Panel();
            this.txtSearchSongTitle = new Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox();
            this.btnSearchSong = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.lbSongs = new System.Windows.Forms.CheckedListBox();
            this.tpCredits = new System.Windows.Forms.TabPage();
            this.txtCredits = new Cr1TiKa7_Framework.Controls.RichtTextBox.FlatRichTextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.customTabControl1.SuspendLayout();
            this.tpMods.SuspendLayout();
            this.tpSongs.SuspendLayout();
            this.tpCredits.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGamePath
            // 
            this.txtGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGamePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.txtGamePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGamePath.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGamePath.ForeColor = System.Drawing.Color.White;
            this.txtGamePath.Location = new System.Drawing.Point(7, 76);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(740, 28);
            this.txtGamePath.TabIndex = 1;
            this.txtGamePath.TextChanged += new System.EventHandler(this.OnGameDirectoryChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnBrowse.Location = new System.Drawing.Point(753, 76);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.OnBrowseButtonClick);
            // 
            // customTabControl1
            // 
            this.customTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTabControl1.Controls.Add(this.tpMods);
            this.customTabControl1.Controls.Add(this.tpSongs);
            this.customTabControl1.Controls.Add(this.tpCredits);
            this.customTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.customTabControl1.Location = new System.Drawing.Point(7, 110);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(836, 368);
            this.customTabControl1.TabIndex = 3;
            this.customTabControl1.TabPagesBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            // 
            // tpMods
            // 
            this.tpMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpMods.Controls.Add(this.btnUpdateInstall);
            this.tpMods.Controls.Add(this.lbMods);
            this.tpMods.Location = new System.Drawing.Point(4, 25);
            this.tpMods.Name = "tpMods";
            this.tpMods.Padding = new System.Windows.Forms.Padding(3);
            this.tpMods.Size = new System.Drawing.Size(828, 339);
            this.tpMods.TabIndex = 0;
            this.tpMods.Text = "Mods";
            // 
            // btnUpdateInstall
            // 
            this.btnUpdateInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnUpdateInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnUpdateInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnUpdateInstall.Location = new System.Drawing.Point(725, 308);
            this.btnUpdateInstall.Name = "btnUpdateInstall";
            this.btnUpdateInstall.Size = new System.Drawing.Size(97, 23);
            this.btnUpdateInstall.TabIndex = 1;
            this.btnUpdateInstall.Text = "Install/Update";
            this.btnUpdateInstall.UseVisualStyleBackColor = false;
            this.btnUpdateInstall.Click += new System.EventHandler(this.OnInstallButtonClick);
            // 
            // lbMods
            // 
            this.lbMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.lbMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbMods.ForeColor = System.Drawing.Color.White;
            this.lbMods.FormattingEnabled = true;
            this.lbMods.Location = new System.Drawing.Point(1, 0);
            this.lbMods.Name = "lbMods";
            this.lbMods.Size = new System.Drawing.Size(827, 286);
            this.lbMods.TabIndex = 0;
            // 
            // tpSongs
            // 
            this.tpSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpSongs.Controls.Add(this.panelSongs);
            this.tpSongs.Controls.Add(this.txtSearchSongTitle);
            this.tpSongs.Controls.Add(this.btnSearchSong);
            this.tpSongs.Controls.Add(this.lbSongs);
            this.tpSongs.Location = new System.Drawing.Point(4, 25);
            this.tpSongs.Name = "tpSongs";
            this.tpSongs.Size = new System.Drawing.Size(828, 339);
            this.tpSongs.TabIndex = 2;
            this.tpSongs.Text = "Songs";
            // 
            // panelSongs
            // 
            this.panelSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSongs.AutoScroll = true;
            this.panelSongs.Location = new System.Drawing.Point(3, 66);
            this.panelSongs.Name = "panelSongs";
            this.panelSongs.Size = new System.Drawing.Size(825, 242);
            this.panelSongs.TabIndex = 6;
            // 
            // txtSearchSongTitle
            // 
            this.txtSearchSongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchSongTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.txtSearchSongTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchSongTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.txtSearchSongTitle.ForeColor = System.Drawing.Color.White;
            this.txtSearchSongTitle.Location = new System.Drawing.Point(2, 15);
            this.txtSearchSongTitle.Name = "txtSearchSongTitle";
            this.txtSearchSongTitle.Size = new System.Drawing.Size(734, 28);
            this.txtSearchSongTitle.TabIndex = 5;
            this.txtSearchSongTitle.KeyUp += new KeyEventHandler(this.OnSongSearch);
            
            // 
            // btnSearchSong
            // 
            this.btnSearchSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnSearchSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSong.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSearchSong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnSearchSong.Location = new System.Drawing.Point(747, 15);
            this.btnSearchSong.Name = "btnSearchSong";
            this.btnSearchSong.Size = new System.Drawing.Size(71, 28);
            this.btnSearchSong.TabIndex = 4;
            this.btnSearchSong.Text = "Search";
            this.btnSearchSong.UseVisualStyleBackColor = false;
            this.btnSearchSong.Click += new System.EventHandler(this.OnSongSearch);
            // 
            // lbSongs
            // 
            this.lbSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.lbSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSongs.ForeColor = System.Drawing.Color.White;
            this.lbSongs.FormattingEnabled = true;
            this.lbSongs.Location = new System.Drawing.Point(1, 66);
            this.lbSongs.Name = "lbSongs";
            this.lbSongs.Size = new System.Drawing.Size(827, 220);
            this.lbSongs.TabIndex = 1;
            this.lbSongs.Visible = false;
            // 
            // tpCredits
            // 
            this.tpCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpCredits.Controls.Add(this.txtCredits);
            this.tpCredits.Location = new System.Drawing.Point(4, 25);
            this.tpCredits.Name = "tpCredits";
            this.tpCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tpCredits.Size = new System.Drawing.Size(828, 339);
            this.tpCredits.TabIndex = 1;
            this.tpCredits.Text = "Credits";
            // 
            // txtCredits
            // 
            this.txtCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.txtCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCredits.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits.ForeColor = System.Drawing.Color.White;
            this.txtCredits.Location = new System.Drawing.Point(0, 0);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.ReadOnly = true;
            this.txtCredits.Size = new System.Drawing.Size(828, 302);
            this.txtCredits.TabIndex = 0;
            this.txtCredits.Text = "Tool created by:\n- Cr1TiKa7\n- derpierre65\n\nBeatMods Developer:\n- vanZeben";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(11, 446);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 20);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 485);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.customTabControl1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtGamePath);
            this.FormIcon = ((System.Drawing.Image)(resources.GetObject("$this.FormIcon")));
            this.Name = "FrmMain";
            this.Text = "Beatsaber Mod Installer";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.Controls.SetChildIndex(this.txtGamePath, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.customTabControl1, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.customTabControl1.ResumeLayout(false);
            this.tpMods.ResumeLayout(false);
            this.tpSongs.ResumeLayout(false);
            this.tpSongs.PerformLayout();
            this.tpCredits.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox txtGamePath;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnBrowse;
        private Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tpMods;
        private System.Windows.Forms.CheckedListBox lbMods;
        private System.Windows.Forms.TabPage tpCredits;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnUpdateInstall;
        private System.Windows.Forms.Label statusLabel;
        private Cr1TiKa7_Framework.Controls.RichtTextBox.FlatRichTextBox txtCredits;
        private System.Windows.Forms.TabPage tpSongs;
        private System.Windows.Forms.CheckedListBox lbSongs;
        private Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox txtSearchSongTitle;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnSearchSong;
        private System.Windows.Forms.Panel panelSongs;
    }
}

