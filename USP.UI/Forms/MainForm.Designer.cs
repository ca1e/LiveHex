
namespace USP.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LV_view = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMS_listview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MS_main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BT_ramEdit = new System.Windows.Forms.Button();
            this.L_consoleInfo = new System.Windows.Forms.Label();
            this.BT_cleanTable = new System.Windows.Forms.Button();
            this.BT_addRecord = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Stas_main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_listview.SuspendLayout();
            this.MS_main.SuspendLayout();
            this.Stas_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_view
            // 
            this.LV_view.AllowDrop = true;
            this.LV_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_view.CheckBoxes = true;
            this.LV_view.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LV_view.FullRowSelect = true;
            this.LV_view.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_view.HideSelection = false;
            this.LV_view.LabelWrap = false;
            this.LV_view.Location = new System.Drawing.Point(0, 123);
            this.LV_view.MultiSelect = false;
            this.LV_view.Name = "LV_view";
            this.LV_view.Size = new System.Drawing.Size(599, 236);
            this.LV_view.TabIndex = 0;
            this.LV_view.UseCompatibleStateImageBehavior = false;
            this.LV_view.View = System.Windows.Forms.View.Details;
            this.LV_view.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.LV_view_ItemMouseHover);
            this.LV_view.DragDrop += new System.Windows.Forms.DragEventHandler(this.LV_view_DragDrop);
            this.LV_view.DragEnter += new System.Windows.Forms.DragEventHandler(this.LV_view_DragEnter);
            this.LV_view.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LV_view_MouseClick);
            this.LV_view.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LV_view_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Active";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value";
            this.columnHeader5.Width = 125;
            // 
            // cMS_listview
            // 
            this.cMS_listview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cMS_listview.Name = "cMS_listview";
            this.cMS_listview.Size = new System.Drawing.Size(113, 26);
            // 
            // MS_main
            // 
            this.MS_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MS_main.Location = new System.Drawing.Point(0, 0);
            this.MS_main.Name = "MS_main";
            this.MS_main.Size = new System.Drawing.Size(599, 25);
            this.MS_main.TabIndex = 20;
            this.MS_main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.connectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // BT_ramEdit
            // 
            this.BT_ramEdit.Location = new System.Drawing.Point(12, 85);
            this.BT_ramEdit.Name = "BT_ramEdit";
            this.BT_ramEdit.Size = new System.Drawing.Size(91, 32);
            this.BT_ramEdit.TabIndex = 21;
            this.BT_ramEdit.Text = " RAM";
            this.BT_ramEdit.UseVisualStyleBackColor = true;
            this.BT_ramEdit.Click += new System.EventHandler(this.BT_ramEdit_Click);
            // 
            // L_consoleInfo
            // 
            this.L_consoleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_consoleInfo.Location = new System.Drawing.Point(135, 24);
            this.L_consoleInfo.Name = "L_consoleInfo";
            this.L_consoleInfo.Size = new System.Drawing.Size(464, 19);
            this.L_consoleInfo.TabIndex = 22;
            this.L_consoleInfo.Text = "No Console Connected";
            this.L_consoleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_cleanTable
            // 
            this.BT_cleanTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BT_cleanTable.Location = new System.Drawing.Point(279, 85);
            this.BT_cleanTable.Name = "BT_cleanTable";
            this.BT_cleanTable.Size = new System.Drawing.Size(37, 32);
            this.BT_cleanTable.TabIndex = 23;
            this.BT_cleanTable.UseVisualStyleBackColor = true;
            // 
            // BT_addRecord
            // 
            this.BT_addRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_addRecord.Location = new System.Drawing.Point(496, 85);
            this.BT_addRecord.Name = "BT_addRecord";
            this.BT_addRecord.Size = new System.Drawing.Size(91, 32);
            this.BT_addRecord.TabIndex = 24;
            this.BT_addRecord.Text = "Add";
            this.BT_addRecord.UseVisualStyleBackColor = true;
            this.BT_addRecord.Click += new System.EventHandler(this.BT_addRecord_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Stas_main
            // 
            this.Stas_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.Stas_main.Location = new System.Drawing.Point(0, 359);
            this.Stas_main.Name = "Stas_main";
            this.Stas_main.Size = new System.Drawing.Size(599, 22);
            this.Stas_main.TabIndex = 25;
            this.Stas_main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "test status";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 381);
            this.Controls.Add(this.Stas_main);
            this.Controls.Add(this.BT_addRecord);
            this.Controls.Add(this.BT_cleanTable);
            this.Controls.Add(this.L_consoleInfo);
            this.Controls.Add(this.BT_ramEdit);
            this.Controls.Add(this.MS_main);
            this.Controls.Add(this.LV_view);
            this.MinimumSize = new System.Drawing.Size(615, 420);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSME LiveHex";
            this.cMS_listview.ResumeLayout(false);
            this.MS_main.ResumeLayout(false);
            this.MS_main.PerformLayout();
            this.Stas_main.ResumeLayout(false);
            this.Stas_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_view;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip MS_main;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button BT_ramEdit;
        private System.Windows.Forms.Label L_consoleInfo;
        private System.Windows.Forms.Button BT_cleanTable;
        private System.Windows.Forms.Button BT_addRecord;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip Stas_main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip cMS_listview;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}