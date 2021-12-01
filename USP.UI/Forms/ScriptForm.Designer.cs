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
            this.hexacimalCheckBox = new System.Windows.Forms.CheckBox();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.pointerBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hexacimalCheckBox
            // 
            this.hexacimalCheckBox.AutoSize = true;
            this.hexacimalCheckBox.Location = new System.Drawing.Point(34, 83);
            this.hexacimalCheckBox.Name = "hexacimalCheckBox";
            this.hexacimalCheckBox.Size = new System.Drawing.Size(90, 16);
            this.hexacimalCheckBox.TabIndex = 11;
            this.hexacimalCheckBox.Text = "Hexadecimal";
            this.hexacimalCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeCB
            // 
            this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCB.Enabled = false;
            this.typeCB.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Location = new System.Drawing.Point(76, 51);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(121, 22);
            this.typeCB.TabIndex = 10;
            // 
            // pointerBox
            // 
            this.pointerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointerBox.Enabled = false;
            this.pointerBox.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pointerBox.Location = new System.Drawing.Point(31, 12);
            this.pointerBox.Name = "pointerBox";
            this.pointerBox.Size = new System.Drawing.Size(324, 23);
            this.pointerBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Type";
            // 
            // writeButton
            // 
            this.writeButton.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.writeButton.Location = new System.Drawing.Point(233, 163);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(92, 32);
            this.writeButton.TabIndex = 16;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // readButton
            // 
            this.readButton.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readButton.Location = new System.Drawing.Point(31, 163);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(92, 32);
            this.readButton.TabIndex = 15;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultBox.Location = new System.Drawing.Point(34, 114);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(142, 23);
            this.resultBox.TabIndex = 17;
            this.resultBox.Text = "0";
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Location = new System.Drawing.Point(213, 56);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(71, 12);
            this.AddrLabel.TabIndex = 18;
            this.AddrLabel.Text = "FFFFFFFFFFF";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 223);
            this.Controls.Add(this.AddrLabel);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hexacimalCheckBox);
            this.Controls.Add(this.typeCB);
            this.Controls.Add(this.pointerBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScriptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hexacimalCheckBox;
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.TextBox pointerBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Label AddrLabel;
    }
}