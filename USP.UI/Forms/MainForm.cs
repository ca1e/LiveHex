using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class MainForm : Form
    {
        #region Path Variables

        public static readonly string WorkingDirectory = Application.StartupPath;
        private static readonly string PluginPath = Path.Combine(WorkingDirectory, "plugins");

        #endregion

        #region Important Variables

        private IRAMEditor MyCoreBot = new FakeEditor();
        private static readonly List<IPlugin> Plugins = new();

        #endregion

        public MainForm()
        {
            InitializeComponent();

            //FormLoadPlugins();
        }


        private void FormLoadPlugins()
        {
#if !MERGED // merged should load dlls from within too, folder is no longer required
            if (!Directory.Exists(PluginPath))
                return;
#endif
            Plugins.AddRange(PluginLoader.LoadPlugins<IPlugin>(PluginPath));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MyCoreBot = form.Editor;
                var info = MyCoreBot.GetInfo();
                L_consoleInfo.Text = $"Console: tid:{info.TitleId:X}, bid:{info.BuildId:X}";
            }
        }

        private void BT_ramEdit_Click(object sender, EventArgs e)
        {
            var form = new HexForm(MyCoreBot);
            form.Show();
        }
    }
}
