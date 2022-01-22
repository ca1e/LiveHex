using System.Windows.Forms;
using USP.UI.Script;

namespace USP.UI
{
    public partial class AddFunctionForm : Form
    {
        public ScriptRecord ScriptResult = new();
        public AddFunctionForm()
        {
            InitializeComponent();

            InitData();
            BindingData();
        }

        private void InitData()
        {
            ScriptResult.Address = "main";
            ScriptResult.Description = "No description";
        }
        private void BindingData()
        {
            this.typeCB.BindToEnumName(typeof(DataType));
            this.typeCB.SelectedIndexChanged += (_, __) =>
            {
                ScriptResult.DType = this.typeCB.GetSelectedItemToEnum<DataType>();
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
