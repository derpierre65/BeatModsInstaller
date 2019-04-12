using System.Windows.Forms;
using Cr1TiKa7_Framework.Baseform;

namespace Beatsaber.Mod.Installer
{
    public partial class FrmMain : Baseform
    {
        private readonly ModApiHandler _modApiHandler = new ModApiHandler();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void OnFrmShown(object sender, System.EventArgs e)
        {
            lbMods.Items.AddRange(_modApiHandler.GetMods().ToArray());
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
    }
}
