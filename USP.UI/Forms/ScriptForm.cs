using System;
using System.Windows.Forms;
using USP.Core;
using USP.UI.Script;

namespace USP.UI
{
    public partial class ScriptForm : Form
    {
        private IRAMEditor MyCoreBot;
        private ScriptRecord ScriptData;
        private ulong CurAddr;

        public ScriptForm(IRAMEditor b, ScriptRecord record)
        {
            InitializeComponent();

            InitControls(b, record);
            InitTitle();
        }

        private void InitControls(IRAMEditor b, ScriptRecord data)
        {
            MyCoreBot = b;
            ScriptData = data;
            BindingData();
        }

        private void BindingData()
        {
            this.typeCB.BindToEnumName(typeof(DataType));
            this.typeCB.SetSelectedItemToEnum(ScriptData.type);
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

        private void readButton_Click(object sender, EventArgs e)
        {
            var len = ScriptData.type switch
            {
                DataType.BYTE => 2,
                DataType.TWO_BYTE => 4,
                DataType.FOUR_BYTE => 8,
                _ => throw new Exception("impossible"),
            };
            var valueType = ScriptData.type switch
            {
                DataType.BYTE => Core.ValueType.SHORT,
                DataType.TWO_BYTE => Core.ValueType.INT,
                DataType.FOUR_BYTE => Core.ValueType.LONG,
                _ => throw new Exception("impossible"),
            };
            var bytes = MyCoreBot.ReadAbsolute(CurAddr, len);

            var val = new ValueData(bytes, valueType);
            resultBox.Text = GetValueFormat(val.HumanValue);
        }

        private string GetValueFormat(ulong val)
        {
            if (hexacimalCheckBox.Checked)
            {
                return $"{val:x}";
            }
            else
            {
                return val.ToString();
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            var valueType = ScriptData.type switch
            {
                DataType.BYTE => Core.ValueType.SHORT,
                DataType.TWO_BYTE => Core.ValueType.INT,
                DataType.FOUR_BYTE => Core.ValueType.LONG,
                _ => throw new Exception("impossible"),
            };
            var val = new ValueData(null, valueType);
            val.HumanValue = ulong.Parse(resultBox.Text);

            MyCoreBot.WriteAbsolute(val.Bytes, CurAddr);
        }
    }
}
