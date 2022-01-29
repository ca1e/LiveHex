namespace USP.Plugins
{
    partial class DigiShow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultBox = new System.Windows.Forms.TextBox();
            this.hexacimalCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultBox.Location = new System.Drawing.Point(4, 29);
            this.resultBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(248, 23);
            this.resultBox.TabIndex = 19;
            this.resultBox.Text = "0";
            // 
            // hexacimalCheckBox
            // 
            this.hexacimalCheckBox.AutoSize = true;
            this.hexacimalCheckBox.Location = new System.Drawing.Point(4, 72);
            this.hexacimalCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.hexacimalCheckBox.Name = "hexacimalCheckBox";
            this.hexacimalCheckBox.Size = new System.Drawing.Size(101, 21);
            this.hexacimalCheckBox.TabIndex = 18;
            this.hexacimalCheckBox.Text = "Hexadecimal";
            this.hexacimalCheckBox.UseVisualStyleBackColor = true;
            // 
            // DigiShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.hexacimalCheckBox);
            this.Name = "DigiShow";
            this.Size = new System.Drawing.Size(256, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.CheckBox hexacimalCheckBox;
    }
}
