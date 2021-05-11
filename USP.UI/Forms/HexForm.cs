using Be.Windows.Forms;
using System;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class HexForm : Form
    {
        private readonly IRAMEditor MyCoreBot;
        private readonly ProcessInfo info;

        public HexForm(IRAMEditor b)
        {
            InitializeComponent();

            MyCoreBot = b;
            info = b.GetInfo();

            if (info.HeepBase == 0)
            {
                throw new Exception("Heap Zero!");
            }
        }

        private void HexEditor_Load(object sender, EventArgs e)
        {
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
    }
}
