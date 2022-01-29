using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using USP.Core;
using USP.UI.Exts;
using USP.UI.Script;

namespace USP.UI
{
    public partial class MainForm : Form
    {
        private static readonly Version CurrentProgramVersion = Assembly.GetExecutingAssembly().GetName().Version!;

        private static readonly List<ScriptRecord> scripts = new();

        private string ScriptPath = "";

        public MainForm()
        {
            _ = Environment.GetCommandLineArgs();

            InitializeComponent();

            FormLoadCheck();
            FormLoadPlugins();

            InitControls();
        }

        private void InitControls()
        {
            timer1.Enabled = false;
            CKB_Update.CheckedChanged += (_, __) =>
            {
                timer1.Enabled = CKB_Update.Checked;
            };
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.DefaultExt = ".json";
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

        private static void FormLoadPlugins()
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
                UpdateListView(MyCoreBot);
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
            try
            {
                var path = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (Path.GetExtension(path[0]) != ".json") return;
                ScriptPath = path[0];

                LoadScriptFile(File.ReadAllText(ScriptPath));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"!=!{ex.Message}", "error");
            }
        }

        private void BT_ramEdit_Click(object sender, EventArgs e)
        {
            var form = new HexForm(MyCoreBot);
            form.Show();
        }

        private void BT_addRecord_Click(object sender, EventArgs e)
        {
            var form = new AddFunctionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                scripts.Add(form.ScriptResult);
            }

            UpdateListView(MyCoreBot);
        }

        #region Module Functions
        private void LoadScriptFile(string _script)
        {
            scripts.Clear();
            scripts.AddRange(ParseRecord(_script));
            UpdateListView(MyCoreBot);
        }

        private static void SaveScriptFile(string path)
        {
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new EmptyStringConverter());
            File.WriteAllText(path, JsonSerializer.Serialize(scripts, jsonSerializerOptions));
        }

        private void UpdateListView(IRAMEditor bot)
        {
            LV_view.BeginUpdate();
            LV_view.Items.Clear();
            LV_view.Items.AddRange(scripts.Select(x => GenListItem(x, bot)).ToArray());
            LV_view.EndUpdate();
        }

        private static IEnumerable<ScriptRecord> ParseRecord(string json)
        {
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new EmptyStringConverter());
            var sf = JsonSerializer.Deserialize<List<ScriptRecord>>(json, jsonSerializerOptions);
            if (sf != null)
            {
                foreach (var f in sf)
                {
                    yield return f;
                }
            }
        }

        private static ListViewItem GenListItem(ScriptRecord data, IRAMEditor editor)
        {
            var lvi = new ListViewItem{ Tag = data };
            lvi.SubItems.Add(data.Description);
            lvi.SubItems.Add(data.Address);
            lvi.SubItems.Add(data.DataType.ToString());
            lvi.SubItems.Add(data.UpdateData(editor));
            return lvi;
        }
        #endregion

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
            toolStripStatusLabel1.Text = "hahah!";
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scripts.Count == 0)
            {
                toolStripStatusLabel1.Text = "no scripts to save";
                return;
            }
            if (ScriptPath != "") saveFileDialog1.FileName = ScriptPath;
            if (saveFileDialog1.ShowDialog()== DialogResult.OK)
                SaveScriptFile(saveFileDialog1.FileName);
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Hand.Play();
                MyCoreBot = form.Editor;
                var info = MyCoreBot.GetInfo();
                InitConnectedConsole(info);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
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

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LV_view.SelectedItems.Count <= 0)
            {
                return;
            }
            var idx = LV_view.Items.IndexOf(LV_view.SelectedItems[0]);
            if (idx < 0 && idx >= scripts.Count)
            {
                return;
            }
            var sc = scripts[idx];
            sc.UpdateData(MyCoreBot);
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = LV_view.SelectedItems[0];
            var data = item.SubItems[4].Text;
            Clipboard.SetDataObject(data);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LV_view.SelectedItems.Count <= 0)
            {
                return;
            }
            var idx = LV_view.Items.IndexOf(LV_view.SelectedItems[0]);
            if (idx < 0 && idx >= scripts.Count)
            {
                return;
            }
            scripts.RemoveAt(idx);
            LV_view.Items.RemoveAt(idx);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateListView(MyCoreBot);
        }
    }
}
