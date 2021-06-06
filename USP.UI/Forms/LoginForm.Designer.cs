
namespace USP.UI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.CB_Protocol = new System.Windows.Forms.ComboBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.BT_conn = new System.Windows.Forms.Button();
            this.usbComboBox = new System.Windows.Forms.ComboBox();
            this.LB_pids = new System.Windows.Forms.ListBox();
            this.BT_attach = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_detach = new System.Windows.Forms.Button();
            this.P_pids = new System.Windows.Forms.Panel();
            this.P_pids.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipTextBox
            // 
            this.ipTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ipTextBox.Location = new System.Drawing.Point(12, 12);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(150, 26);
            this.ipTextBox.TabIndex = 8;
            this.ipTextBox.Text = "999.999.999.999";
            // 
            // CB_Protocol
            // 
            this.CB_Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Protocol.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_Protocol.FormattingEnabled = true;
            this.CB_Protocol.Location = new System.Drawing.Point(12, 100);
            this.CB_Protocol.Name = "CB_Protocol";
            this.CB_Protocol.Size = new System.Drawing.Size(150, 24);
            this.CB_Protocol.TabIndex = 7;
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portTextBox.Location = new System.Drawing.Point(12, 44);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(150, 26);
            this.portTextBox.TabIndex = 6;
            this.portTextBox.Text = "6000";
            // 
            // BT_conn
            // 
            this.BT_conn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_conn.Location = new System.Drawing.Point(12, 147);
            this.BT_conn.Name = "BT_conn";
            this.BT_conn.Size = new System.Drawing.Size(150, 35);
            this.BT_conn.TabIndex = 5;
            this.BT_conn.Text = "Connect";
            this.BT_conn.UseVisualStyleBackColor = true;
            this.BT_conn.Click += new System.EventHandler(this.ConnButton_Click);
            // 
            // usbComboBox
            // 
            this.usbComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usbComboBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usbComboBox.FormattingEnabled = true;
            this.usbComboBox.Location = new System.Drawing.Point(12, 12);
            this.usbComboBox.Name = "usbComboBox";
            this.usbComboBox.Size = new System.Drawing.Size(150, 24);
            this.usbComboBox.TabIndex = 9;
            this.usbComboBox.Visible = false;
            // 
            // LB_pids
            // 
            this.LB_pids.FormattingEnabled = true;
            this.LB_pids.ItemHeight = 12;
            this.LB_pids.Location = new System.Drawing.Point(213, 12);
            this.LB_pids.Name = "LB_pids";
            this.LB_pids.Size = new System.Drawing.Size(150, 100);
            this.LB_pids.TabIndex = 10;
            // 
            // BT_attach
            // 
            this.BT_attach.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_attach.Location = new System.Drawing.Point(3, 3);
            this.BT_attach.Name = "BT_attach";
            this.BT_attach.Size = new System.Drawing.Size(150, 32);
            this.BT_attach.TabIndex = 11;
            this.BT_attach.Text = "Attach";
            this.BT_attach.UseVisualStyleBackColor = true;
            this.BT_attach.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "[tid]";
            // 
            // BT_detach
            // 
            this.BT_detach.Enabled = false;
            this.BT_detach.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_detach.Location = new System.Drawing.Point(3, 50);
            this.BT_detach.Name = "BT_detach";
            this.BT_detach.Size = new System.Drawing.Size(150, 23);
            this.BT_detach.TabIndex = 13;
            this.BT_detach.Text = "Detach";
            this.BT_detach.UseVisualStyleBackColor = true;
            this.BT_detach.Click += new System.EventHandler(this.BT_detach_Click);
            // 
            // P_pids
            // 
            this.P_pids.Controls.Add(this.BT_attach);
            this.P_pids.Controls.Add(this.BT_detach);
            this.P_pids.Enabled = false;
            this.P_pids.Location = new System.Drawing.Point(213, 132);
            this.P_pids.Name = "P_pids";
            this.P_pids.Size = new System.Drawing.Size(171, 82);
            this.P_pids.TabIndex = 14;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 214);
            this.Controls.Add(this.P_pids);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_pids);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.CB_Protocol);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.BT_conn);
            this.Controls.Add(this.usbComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open";
            this.P_pids.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.ComboBox CB_Protocol;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button BT_conn;
        private System.Windows.Forms.ComboBox usbComboBox;
        private System.Windows.Forms.ListBox LB_pids;
        private System.Windows.Forms.Button BT_attach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_detach;
        private System.Windows.Forms.Panel P_pids;
    }
}

