using USP.UI.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using USP.Core;

namespace USP.UI
{
    public partial class LoginForm : Form
    {
        #region Path Variables

        public static readonly string WorkingDirectory = Application.StartupPath;
        private static readonly string PluginPath = Path.Combine(WorkingDirectory, "plugins");

        #endregion

        #region Important Variables

        private readonly Settings Settings = Settings.Default;
        private static readonly List<IPlugin> Plugins = new();

        #endregion

        public LoginForm()
        {
            InitializeComponent();

            FormLoadPlugins();
            LoadControls();
        }

        private void FormLoadPlugins()
        {
#if !MERGED // merged should load dlls from within too, folder is no longer required
            if (!Directory.Exists(PluginPath))
                return;
#endif
            Plugins.AddRange(PluginLoader.LoadPlugins<IPlugin>(PluginPath));
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

        private void connButton_Click(object sender, EventArgs e)
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);
            var idx = WinFormsUtil.GetIndex(CB_Protocol);

            try
            {
                var bot = CoreUtil.GetBot(ip, port, (ProtocolType)idx);

                var form = new HexForm(bot);

                Settings.SwitchIP = ipTextBox.Text;
                this.Visible = false;
                Settings.Save();

                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Visible = true;
            }
        }
    }
}
