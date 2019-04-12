namespace Beatsaber.Mod.Installer
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
            this.tabControl = new Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl();
            this.tpMods = new System.Windows.Forms.TabPage();
            this.tpTools = new System.Windows.Forms.TabPage();
            this.tpHelp = new System.Windows.Forms.TabPage();
            this.tpCredits = new System.Windows.Forms.TabPage();
            this.btnInstall = new Cr1TiKa7_Framework.Controls.Button.FlatButton();
            this.lbMods = new System.Windows.Forms.CheckedListBox();
            this.tabControl.SuspendLayout();
            this.tpMods.SuspendLayout();
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
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpMods);
            this.tabControl.Controls.Add(this.tpTools);
            this.tabControl.Controls.Add(this.tpHelp);
            this.tabControl.Controls.Add(this.tpCredits);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(3, 110);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(825, 441);
            this.tabControl.TabIndex = 3;
            this.tabControl.TabPagesBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            // 
            // tpMods
            // 
            this.tpMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpMods.Controls.Add(this.lbMods);
            this.tpMods.Controls.Add(this.btnInstall);
            this.tpMods.Location = new System.Drawing.Point(4, 25);
            this.tpMods.Name = "tpMods";
            this.tpMods.Padding = new System.Windows.Forms.Padding(3);
            this.tpMods.Size = new System.Drawing.Size(817, 412);
            this.tpMods.TabIndex = 0;
            this.tpMods.Text = "Mods";
            // 
            // tpTools
            // 
            this.tpTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpTools.Location = new System.Drawing.Point(4, 25);
            this.tpTools.Name = "tpTools";
            this.tpTools.Padding = new System.Windows.Forms.Padding(3);
            this.tpTools.Size = new System.Drawing.Size(817, 434);
            this.tpTools.TabIndex = 1;
            this.tpTools.Text = "Tools";
            // 
            // tpHelp
            // 
            this.tpHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpHelp.Location = new System.Drawing.Point(4, 25);
            this.tpHelp.Name = "tpHelp";
            this.tpHelp.Size = new System.Drawing.Size(817, 422);
            this.tpHelp.TabIndex = 2;
            this.tpHelp.Text = "Help";
            // 
            // tpCredits
            // 
            this.tpCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tpCredits.Location = new System.Drawing.Point(4, 25);
            this.tpCredits.Name = "tpCredits";
            this.tpCredits.Size = new System.Drawing.Size(817, 422);
            this.tpCredits.TabIndex = 3;
            this.tpCredits.Text = "Credits";
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnInstall.Location = new System.Drawing.Point(712, 380);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(99, 28);
            this.btnInstall.TabIndex = 4;
            this.btnInstall.Text = "Install/Update";
            this.btnInstall.UseVisualStyleBackColor = false;
            // 
            // lbMods
            // 
            this.lbMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.lbMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbMods.ForeColor = System.Drawing.Color.White;
            this.lbMods.FormattingEnabled = true;
            this.lbMods.Location = new System.Drawing.Point(0, 0);
            this.lbMods.Name = "lbMods";
            this.lbMods.Size = new System.Drawing.Size(817, 374);
            this.lbMods.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 551);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtGameDirectory);
            this.FormIcon = ((System.Drawing.Image)(resources.GetObject("$this.FormIcon")));
            this.Name = "FrmMain";
            this.Text = "Beatsaber Mod Installer";
            this.Shown += new System.EventHandler(this.OnFrmShown);
            this.Controls.SetChildIndex(this.txtGameDirectory, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.tabControl.ResumeLayout(false);
            this.tpMods.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cr1TiKa7_Framework.Controls.TextBox.FlatTextBox txtGameDirectory;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnBrowse;
        private Cr1TiKa7_Framework.Controls.TabControl.CustomTabControl tabControl;
        private System.Windows.Forms.TabPage tpMods;
        private System.Windows.Forms.TabPage tpTools;
        private System.Windows.Forms.TabPage tpHelp;
        private System.Windows.Forms.TabPage tpCredits;
        private Cr1TiKa7_Framework.Controls.Button.FlatButton btnInstall;
        private System.Windows.Forms.CheckedListBox lbMods;
    }
}

