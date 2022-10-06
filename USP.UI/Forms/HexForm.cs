using Be.Windows.Forms;
using System;
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

        public HexForm(IRAMEditor b)
        {
            InitializeComponent();

            InitControls();
            InitBot(b);
            InitRam();
        }

        private void InitBot(IRAMEditor b)
        {
            MyCoreBot = b;
            info = MyCoreBot.GetInfo();

            if (info.HeepBase == 0)
            {
                MessageBox.Show("Heap Zero!");
                Debug.Write("Heap Zero!");
            }

            InitTitle();
        }

        private void InitTitle()
        {
            var infoStr = $"[tid:{info.TitleId:X}, bid:{info.BuildId:X}]";
            Text = $"HexEdit - {infoStr}";
        }

        private void InitRam()
        {
            var addr = MyCoreBot.GetPointer(textBox1.Text);
            hexRltTextBox.Text = $"{addr:X8}";
        }

        private void InitControls()
        {
            radioButton1.CheckedChanged += (_, __) => { hexBox1.GroupSize = 2; };

            radioButton2.CheckedChanged += (_, __) => { hexBox1.GroupSize = 8; };
        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            try
            {
                InitRam();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            var provider = new Provider.RAMProvider { Editor = MyCoreBot, ByteLength = Convert.ToInt32(hexOfTextBox.Text) };
            provider.Address = hexRltTextBox.Text;

            hexBox1.LineInfoOffset = (long)(provider.Addr - info.HeepBase);
            hexBox1.ByteProvider = provider;
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            hexBox1.ByteProvider?.ApplyChanges();

            System.Media.SystemSounds.Asterisk.Play();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using var stream = new MemoryStream();

                for(var i = 0; i < hexBox1.ByteProvider?.Length; i++)
                {
                    stream.WriteByte(hexBox1.ByteProvider.ReadByte(i));
                }

                var bytes = stream.ToArray();
                File.WriteAllBytes(saveFileDialog1.FileName, bytes);
            }
        }

        private void CleanUpHexBox(HexBox b)
        {
            if (b.ByteProvider == null) return;

            var byteProvider = b.ByteProvider as IDisposable;
            byteProvider?.Dispose();
            b.ByteProvider = null;
        }
    }
}
