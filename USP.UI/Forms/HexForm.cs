using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class HexForm : Form
    {
        private IRAMEditor MyCoreBot;
        private ProcessInfo info;

        #region Path Variables

        public static readonly string WorkingDirectory = Application.StartupPath;
        private static readonly string PluginPath = Path.Combine(WorkingDirectory, "plugins");

        #endregion

        #region Important Variables

        private static readonly List<IPlugin> Plugins = new();

        #endregion

        public HexForm()
        {
            InitializeComponent();

            FormLoadPlugins();
            InitBot(new FakeEditor());
        }

        private void FormLoadPlugins()
        {
#if !MERGED // merged should load dlls from within too, folder is no longer required
            if (!Directory.Exists(PluginPath))
                return;
#endif
            Plugins.AddRange(PluginLoader.LoadPlugins<IPlugin>(PluginPath));
        }

        private void InitBot(IRAMEditor b)
        {
            MyCoreBot = b;
            info = MyCoreBot.GetInfo();

            if (info.HeepBase == 0)
            {
                // throw new Exception("Heap Zero!");
                Debug.Write("Heap Zero!");
            }

            Text = $"HexEdit tid:{info.TitleId:X}, bid:{info.BuildId:X}";
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            var addr = MyCoreBot.GetPointer(textBox1.Text);
            hexRltTextBox.Text = $"{addr:X8}";
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var provider = new RAMProvider{ CoreBot = MyCoreBot, ByteLength = Convert.ToInt32(hexOfTextBox.Text) };
            provider.Address = hexRltTextBox.Text;

            hexBox1.LineInfoOffset = (long)(provider.Addr - info.HeepBase);
            hexBox1.ByteProvider = provider;
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            hexBox1.ByteProvider?.ApplyChanges();

            System.Media.SystemSounds.Asterisk.Play();
        }

        private void CleanUpHexBox(HexBox b)
        {
            if (b.ByteProvider == null) return;

            var byteProvider = b.ByteProvider as IDisposable;
            byteProvider?.Dispose();
            b.ByteProvider = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hexBox1.GroupSize = 2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hexBox1.GroupSize = 8;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                InitBot(form.Editor);
            }
        }
    }
}
