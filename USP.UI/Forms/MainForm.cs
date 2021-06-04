using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class MainForm : Form
    {
        private static readonly Version CurrentProgramVersion = Assembly.GetExecutingAssembly().GetName().Version!;

        public MainForm()
        {
            var args = Environment.GetCommandLineArgs();

            InitializeComponent();

            FormLoadCheck();
            FormLoadPlugins();
        }


        #region Path Variables

        public static readonly string WorkingDirectory = Application.StartupPath;
        private static readonly string PluginPath = Path.Combine(WorkingDirectory, "plugins");

        #endregion

        #region Important Variables

        private IRAMEditor MyCoreBot = new FakeEditor();
        private static readonly List<IPlugin> Plugins = new();

        #endregion

        private void FormLoadCheck()
        {
            this.Text += CurrentProgramVersion;
            L_consoleInfo.Text = "No Console Connected";
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
                if(info.HeepBase != 0)
                {
                    L_consoleInfo.Text += "-H1";
                }
            }
        }

        private void BT_ramEdit_Click(object sender, EventArgs e)
        {
            var form = new HexForm(MyCoreBot);
            form.Show();
        }
    }
}
