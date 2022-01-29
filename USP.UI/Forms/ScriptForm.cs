using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USP.Core;
using USP.UI.Script;

namespace USP.UI
{
    public partial class ScriptForm : Form
    {
        private readonly IRAMEditor MyCoreBot;
        private readonly ScriptRecord ScriptData;
        private ulong CurAddr;

        public ScriptForm(IRAMEditor b, ScriptRecord record)
        {
            MyCoreBot = b;
            ScriptData = record;

            InitializeComponent();

            BindingData();
            InitTitle();
        }

        private void BindingData()
        {
            this.typeCB.DataSource = new List<string>();
            this.typeCB.SelectedIndex = -1;
            this.pointerBox.DataBindings.Add("Text", ScriptData, "Address");
            this.hexacimalCheckBox.DataBindings.Add("Checked", ScriptData, "Hexadecimal");

            this.hexacimalCheckBox.CheckedChanged += (_, _) =>
            {
                // TODO
            };
        }

        private void InitTitle()
        {
            Text = $"- {ScriptData.Description} -";

            CurAddr = MyCoreBot.GetPointer(ScriptData.Address);
            AddrLabel.Text = $"Addr: {CurAddr:X8}";
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            var bytes = MyCoreBot.ReadAbsolute(CurAddr, ScriptData.DataLength);
            resultBox.Text = ScriptData.ParseData(bytes);
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            var rawBytes = ScriptData.GetData(resultBox.Text);
            MyCoreBot.WriteAbsolute(rawBytes, CurAddr);
        }
    }
}
