
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
            this.connButton = new System.Windows.Forms.Button();
            this.usbComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.attachButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipTextBox
            // 
            this.ipTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ipTextBox.Location = new System.Drawing.Point(53, 34);
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
            this.CB_Protocol.Location = new System.Drawing.Point(53, 122);
            this.CB_Protocol.Name = "CB_Protocol";
            this.CB_Protocol.Size = new System.Drawing.Size(150, 24);
            this.CB_Protocol.TabIndex = 7;
            // 
            // portTextBox
            // 
            this.portTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portTextBox.Location = new System.Drawing.Point(53, 66);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(150, 26);
            this.portTextBox.TabIndex = 6;
            this.portTextBox.Text = "6000";
            // 
            // connButton
            // 
            this.connButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connButton.Location = new System.Drawing.Point(53, 169);
            this.connButton.Name = "connButton";
            this.connButton.Size = new System.Drawing.Size(150, 35);
            this.connButton.TabIndex = 5;
            this.connButton.Text = "Connect";
            this.connButton.UseVisualStyleBackColor = true;
            this.connButton.Click += new System.EventHandler(this.ConnButton_Click);
            // 
            // usbComboBox
            // 
            this.usbComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usbComboBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usbComboBox.FormattingEnabled = true;
            this.usbComboBox.Location = new System.Drawing.Point(53, 34);
            this.usbComboBox.Name = "usbComboBox";
            this.usbComboBox.Size = new System.Drawing.Size(150, 24);
            this.usbComboBox.TabIndex = 9;
            this.usbComboBox.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(260, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 124);
            this.listBox1.TabIndex = 10;
            // 
            // attachButton
            // 
            this.attachButton.Enabled = false;
            this.attachButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.attachButton.Location = new System.Drawing.Point(260, 169);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(150, 35);
            this.attachButton.TabIndex = 11;
            this.attachButton.Text = "Attach";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "titleId";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.CB_Protocol);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.connButton);
            this.Controls.Add(this.usbComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.ComboBox CB_Protocol;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connButton;
        private System.Windows.Forms.ComboBox usbComboBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Label label1;
    }
}

