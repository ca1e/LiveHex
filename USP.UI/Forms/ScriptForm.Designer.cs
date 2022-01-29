namespace USP.UI
{
    partial class ScriptForm
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
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.pointerBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.readButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeCB
            // 
            this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCB.Enabled = false;
            this.typeCB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Location = new System.Drawing.Point(68, 56);
            this.typeCB.Margin = new System.Windows.Forms.Padding(4);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(140, 22);
            this.typeCB.TabIndex = 10;
            // 
            // pointerBox
            // 
            this.pointerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointerBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pointerBox.Location = new System.Drawing.Point(16, 17);
            this.pointerBox.Margin = new System.Windows.Forms.Padding(4);
            this.pointerBox.Name = "pointerBox";
            this.pointerBox.ReadOnly = true;
            this.pointerBox.Size = new System.Drawing.Size(389, 23);
            this.pointerBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Type";
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Location = new System.Drawing.Point(283, 58);
            this.AddrLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(74, 17);
            this.AddrLabel.TabIndex = 18;
            this.AddrLabel.Text = "FFFFFFFFFFF";
            // 
            // DataPanel
            // 
            this.DataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataPanel.Location = new System.Drawing.Point(16, 89);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(389, 243);
            this.DataPanel.TabIndex = 19;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readButton.Location = new System.Drawing.Point(55, 339);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(96, 30);
            this.readButton.TabIndex = 20;
            this.readButton.Text = "read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.writeButton.Location = new System.Drawing.Point(261, 339);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(96, 30);
            this.writeButton.TabIndex = 21;
            this.writeButton.Text = "write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 381);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.AddrLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeCB);
            this.Controls.Add(this.pointerBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 420);
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScriptForm";
            this.Load += new System.EventHandler(this.ScriptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.TextBox pointerBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AddrLabel;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button writeButton;
    }
}