using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using USP.Core;
using USP.UI.Script;

namespace USP.UI
{
    public partial class MainForm : Form
    {
        private static readonly Version CurrentProgramVersion = Assembly.GetExecutingAssembly().GetName().Version!;

        public MainForm()
        {
            var args = Environment.GetCommandLineArgs();

            InitializeComponent();

            FormLoadCheck();
            FormLoadPlugins();
        }


        #region Path Variables

        public static readonly string WorkingDirectory = Application.StartupPath;
        private static readonly string PluginPath = Path.Combine(WorkingDirectory, "plugins");

        #endregion

        #region Important Variables

        private IRAMEditor MyCoreBot = new Editor.FakeEditor();
        private static readonly List<IPlugin> Plugins = new();

        #endregion

        private void FormLoadCheck()
        {
            this.Text = $"NSME LiveHex - v{CurrentProgramVersion}";
            L_consoleInfo.Text = "No Console Connected";
        }

        private void FormLoadPlugins()
        {
#if !MERGED // merged should load dlls from within too, folder is no longer required
            if (!Directory.Exists(PluginPath))
                return;
#endif
            Plugins.AddRange(PluginLoader.LoadPlugins<IPlugin>(PluginPath));
        }

        private void InitConnectedConsole(ProcessInfo info)
        {
            L_consoleInfo.Text = $"Console: tid:{info.TitleId:X}, bid:{info.BuildId:X}";
            if (info.HeepBase != 0)
            {
                L_consoleInfo.Text += "-H1";
                BT_cleanTable.BackColor = Color.Green;
            }
        }

        private void LV_view_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LV_view_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void BT_ramEdit_Click(object sender, EventArgs e)
        {
            var form = new HexForm(MyCoreBot);
            form.Show();
        }

        private void BT_addRecord_Click(object sender, EventArgs e)
        {
            LV_view.BeginUpdate();

            var form = new AddFunctionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var data = form.ScriptResult;
                var li = GenListItem(data);
                LV_view.Items.Add(li);
            }

            LV_view.EndUpdate();
        }

        private ListViewItem GenListItem(ScriptRecord data)
        {
            ListViewItem lvi = new();
            lvi.SubItems.Add(data.Description);
            lvi.SubItems.Add(data.Address);
            lvi.SubItems.Add(data.type.ToString());
            lvi.Tag = data;
            
            var pointer = MyCoreBot.GetPointer(data.Address);
            if (pointer == ulong.MaxValue)
            {
                lvi.SubItems.Add("??");
            }
            else
            {
                var len = data.type switch
                {
                    DataType.BYTE => 2,
                    DataType.TWO_BYTE => 4,
                    DataType.FOUR_BYTE => 8,
                    _ => throw new Exception("impossible"),
                };
                var rawMemdata = MyCoreBot.ReadAbsolute(pointer, len);
                var valueType = data.type switch
                {
                    DataType.BYTE => Core.ValueType.SHORT,
                    DataType.TWO_BYTE => Core.ValueType.INT,
                    DataType.FOUR_BYTE => Core.ValueType.LONG,
                    _ => throw new Exception("impossible"),
                };
                var valueData = new ValueData(rawMemdata, valueType);
                lvi.SubItems.Add(valueData.HumanValue.ToString());
            }
            return lvi;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MyCoreBot = form.Editor;
                var info = MyCoreBot.GetInfo();
                InitConnectedConsole(info);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void LV_view_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {

        }

        private void LV_view_MouseClick(object sender, MouseEventArgs e)
        {
            var item = LV_view.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.cMS_listview.Show(LV_view, e.X, e.Y);
            }
        }

        private void LV_view_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = LV_view.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                var record = (ScriptRecord)item.Tag;
                var form = new ScriptForm(MyCoreBot, record);
                form.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = LV_view.SelectedItems[0];
            LV_view.Items.Remove(item);
        }
    }
}
