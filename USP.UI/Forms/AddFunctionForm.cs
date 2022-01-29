using System.Windows.Forms;
using USP.Plugins;
using USP.UI.Script;

namespace USP.UI
{
    public partial class AddFunctionForm : Form
    {
        public ScriptRecord ScriptResult;
        public AddFunctionForm()
        {
            ScriptResult = new ScriptRecord { Address = "main", DataType = "BYTE", Description = "No description" };

            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            BindingData();
        }

        private void BindingData()
        {
            this.typeCB.DataSource = ByteData.GetDefaultTypes();
            this.typeCB.SelectedIndexChanged += (_, __) =>
            {
                ScriptResult.DataType = (this.typeCB.SelectedItem as string)?? "BYTE";
            };
            this.textBox1.DataBindings.Add("Text", ScriptResult, "Address");
            this.textBox2.DataBindings.Add("Text", ScriptResult, "Description");
            this.hexacimalCheckBox.DataBindings.Add("Checked", ScriptResult, "Hexadecimal");
        }

        private void okayBtn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
