using USP.UI.Properties;
using System;
using System.Linq;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class LoginForm : Form
    {
        private readonly Settings Settings = Settings.Default;

        public LoginForm()
        {
            InitializeComponent();

            LoadControls();
        }

        private void LoadControls()
        {
            ipTextBox.Text = Settings.SwitchIP;

            usbComboBox.Items.Clear();
            usbComboBox.Items.AddRange(CoreUtil.USBPort.ToArray());
            usbComboBox.SelectedIndexChanged += (_, __) =>
            {
                portTextBox.Text = usbComboBox.SelectedItem.ToString();
            };

            var protocols = (ProtocolType[])Enum.GetValues(typeof(ProtocolType));
            // conn protocol
            CB_Protocol.DisplayMember = nameof(ComboItem.Text);
            CB_Protocol.ValueMember = nameof(ComboItem.Value);
            CB_Protocol.DataSource = protocols.Select(z => new ComboItem(z.ToString(), (int)z)).ToArray(); ;
            CB_Protocol.SelectedIndex = 0; // default option
            CB_Protocol.SelectedIndexChanged += (_, __) =>
            {
                ipTextBox.Visible = CB_Protocol.SelectedIndex == 0;
                portTextBox.Visible = ipTextBox.Visible;
                usbComboBox.Visible = !ipTextBox.Visible;
                if(usbComboBox.Visible)
                {
                    usbComboBox.Items.Clear();
                    usbComboBox.Items.AddRange(CoreUtil.USBPort.ToArray());
                }
            };
        }

        public IRAMEditor Editor = new FakeEditor();

        private void connButton_Click(object sender, EventArgs e)
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);
            var idx = WinFormsUtil.GetIndex(CB_Protocol);

            try
            {
                Editor = CoreUtil.GetSysBot(ip, port, (ProtocolType)idx);

                DialogResult = DialogResult.OK;

                Settings.SwitchIP = ipTextBox.Text;
                Settings.Save();

                Close();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
