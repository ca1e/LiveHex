using System.Windows.Forms;
using USP.Core;
using USP.Plugins;
using USP.UI.Script;

namespace USP.UI
{
    public partial class ScriptForm : Form
    {
        private readonly IRAMEditor MyCoreBot;
        private readonly ScriptRecord ScriptData;
        private readonly ulong CurAddr;
        private DataUserControl dc;

        public ScriptForm(IRAMEditor b, ScriptRecord record)
        {
            MyCoreBot = b;
            ScriptData = record;

            InitializeComponent();

            // data binding
            this.typeCB.Text = record.DataType;
            this.pointerBox.DataBindings.Add("Text", ScriptData, "Address");

            // init title
            Text = $"- {ScriptData.Description} -";

            CurAddr = MyCoreBot.GetPointer(ScriptData.Address);
            AddrLabel.Text = $"Addr: {CurAddr:X8}";
        }

        private void InitControls()
        {
            var bytes = ScriptData.GetData(MyCoreBot);
            this.DataPanel.Controls.Clear();
            try
            {
                dc = ScriptData.ShowControl(bytes);
                this.DataPanel.Controls.Add(dc);
            }
            catch (System.NotImplementedException)
            {
                MessageBox.Show("No any view to show.");
                Close();
            }
        }

        private void ScriptForm_Load(object sender, System.EventArgs e)
        {
            InitControls();
        }

        private void readButton_Click(object sender, System.EventArgs e)
        {
            var bytes = ScriptData.GetData(MyCoreBot);
            dc.Data = bytes;
        }

        private void writeButton_Click(object sender, System.EventArgs e)
        {
            MyCoreBot.WriteAbsolute(dc.Data, CurAddr);
        }
    }
}
