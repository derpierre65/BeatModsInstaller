﻿namespace BeatSaberModInstaller
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
            this.txtGameDirectory = new Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox();
            this.btnBrowse = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.customTabControl1 = new Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl();
            this.tpMods = new System.Windows.Forms.TabPage();
            this.tpCredits = new System.Windows.Forms.TabPage();
            this.lbMods = new System.Windows.Forms.CheckedListBox();
            this.btnUpdateInstall = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtCredits = new Cr1TiKa7_Framework.Controls.RichtTextBox.FlatRichTextBox();
            this.customTabControl1.SuspendLayout();
            this.tpMods.SuspendLayout();
            this.tpCredits.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGameDirectory
            // 
            this.txtGameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.txtGameDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGameDirectory.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameDirectory.ForeColor = System.Drawing.Color.White;
            this.txtGameDirectory.Location = new System.Drawing.Point(7, 76);
            this.txtGameDirectory.Name = "txtGameDirectory";
            this.txtGameDirectory.Size = new System.Drawing.Size(721, 28);
            this.txtGameDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnBrowse.Location = new System.Drawing.Point(734, 76);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.OnBtnClick);
            // 
            // customTabControl1
            // 
            this.customTabControl1.Controls.Add(this.tpMods);
            this.customTabControl1.Controls.Add(this.tpCredits);
            this.customTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.customTabControl1.Location = new System.Drawing.Point(7, 110);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(809, 438);
            this.customTabControl1.TabIndex = 3;
            this.customTabControl1.TabPagesBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            // 
            // tpMods
            // 
            this.tpMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpMods.Controls.Add(this.lblStatus);
            this.tpMods.Controls.Add(this.btnUpdateInstall);
            this.tpMods.Controls.Add(this.lbMods);
            this.tpMods.Location = new System.Drawing.Point(4, 25);
            this.tpMods.Name = "tpMods";
            this.tpMods.Padding = new System.Windows.Forms.Padding(3);
            this.tpMods.Size = new System.Drawing.Size(801, 409);
            this.tpMods.TabIndex = 0;
            this.tpMods.Text = "Mods";
            // 
            // tpCredits
            // 
            this.tpCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.tpCredits.Controls.Add(this.txtCredits);
            this.tpCredits.Location = new System.Drawing.Point(4, 25);
            this.tpCredits.Name = "tpCredits";
            this.tpCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tpCredits.Size = new System.Drawing.Size(801, 409);
            this.tpCredits.TabIndex = 1;
            this.tpCredits.Text = "Credits";
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
            this.lbMods.Size = new System.Drawing.Size(800, 374);
            this.lbMods.TabIndex = 0;
            // 
            // btnUpdateInstall
            // 
            this.btnUpdateInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnUpdateInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnUpdateInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnUpdateInstall.Location = new System.Drawing.Point(698, 380);
            this.btnUpdateInstall.Name = "btnUpdateInstall";
            this.btnUpdateInstall.Size = new System.Drawing.Size(97, 23);
            this.btnUpdateInstall.TabIndex = 1;
            this.btnUpdateInstall.Text = "Install/Update";
            this.btnUpdateInstall.UseVisualStyleBackColor = false;
            this.btnUpdateInstall.Click += new System.EventHandler(this.OnBtnInstallClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(6, 380);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // txtCredits
            // 
            this.txtCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.txtCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCredits.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits.ForeColor = System.Drawing.Color.White;
            this.txtCredits.Location = new System.Drawing.Point(6, 6);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(789, 397);
            this.txtCredits.TabIndex = 0;
            this.txtCredits.Text = "Tool created by:\n- Cr1TiKa7\n- derpierre65\n\nOriginal Tool by:\n- vanZeben";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 551);
            this.Controls.Add(this.customTabControl1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtGameDirectory);
            this.FormIcon = ((System.Drawing.Image)(resources.GetObject("$this.FormIcon")));
            this.Name = "FrmMain";
            this.Text = "Beatsaber Mod Installer";
            this.Shown += new System.EventHandler(this.OnFrmShown);
            this.Controls.SetChildIndex(this.txtGameDirectory, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.customTabControl1, 0);
            this.customTabControl1.ResumeLayout(false);
            this.tpMods.ResumeLayout(false);
            this.tpMods.PerformLayout();
            this.tpCredits.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox txtGameDirectory;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnBrowse;
        private Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tpMods;
        private System.Windows.Forms.CheckedListBox lbMods;
        private System.Windows.Forms.TabPage tpCredits;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnUpdateInstall;
        private System.Windows.Forms.Label lblStatus;
        private Cr1TiKa7_Framework.Controls.RichtTextBox.FlatRichTextBox txtCredits;
    }
}
