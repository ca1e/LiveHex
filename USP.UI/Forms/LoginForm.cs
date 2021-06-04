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

            LoadSettings();
        }

        private void LoadSettings()
        {
            ipTextBox.Text = Settings.SwitchIP;
            portTextBox.Text = Settings.SwitchPort.ToString();
            CB_Protocol.SelectedIndex = Settings.SwitchType;
        }

        private void SaveSettings()
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);

            Settings.SwitchIP = ip;
            Settings.SwitchPort = port;
            Settings.SwitchType = WinFormsUtil.GetIndex(CB_Protocol);
            Settings.Save();
        }

        private void LoadControls()
        {
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
            CB_Protocol.DataSource = protocols.Select(z => new ComboItem(z.ToString(), (int)z)).ToArray();
            CB_Protocol.SelectedIndexChanged += (_, __) =>
            {
                ipTextBox.Visible = CB_Protocol.SelectedIndex != 1;
                portTextBox.Text = CB_Protocol.SelectedIndex switch
                {
                    0 => "6000",
                    2 => "7331",
                    _ => "0", // for usb address
                };
                portTextBox.Visible = ipTextBox.Visible;
                usbComboBox.Visible = !ipTextBox.Visible;
                if(usbComboBox.Visible)
                {
                    usbComboBox.Items.Clear();
                    usbComboBox.Items.AddRange(CoreUtil.USBPort.ToArray());
                    usbComboBox.SelectedIndex = usbComboBox.Items.Count != 0 ? 0 : -1;
                }
            };
            CB_Protocol.SelectedIndex = 0; // default option
        }

        public IRAMEditor Editor = new FakeEditor();

        private void ConnButton_Click(object sender, EventArgs e)
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);
            var idx = WinFormsUtil.GetIndex(CB_Protocol);

            try
            {
                Editor = CoreUtil.GetControlBot(ip, port, (ProtocolType)idx);

                DialogResult = DialogResult.OK;
                SaveSettings();
                Close();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
        }
    }
}
