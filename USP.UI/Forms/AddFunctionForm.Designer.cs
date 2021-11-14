namespace USP.UI
{
    partial class AddFunctionForm
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
            this.okayBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hexacimalCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okayBtn
            // 
            this.okayBtn.Location = new System.Drawing.Point(12, 170);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(99, 29);
            this.okayBtn.TabIndex = 0;
            this.okayBtn.Text = "OK";
            this.okayBtn.UseVisualStyleBackColor = true;
            this.okayBtn.Click += new System.EventHandler(this.okayBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(134, 170);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(99, 28);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(12, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "main";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(12, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "No description";
            // 
            // typeCB
            // 
            this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCB.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Location = new System.Drawing.Point(12, 108);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(121, 22);
            this.typeCB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type";
            // 
            // hexacimalCheckBox
            // 
            this.hexacimalCheckBox.AutoSize = true;
            this.hexacimalCheckBox.Location = new System.Drawing.Point(12, 136);
            this.hexacimalCheckBox.Name = "hexacimalCheckBox";
            this.hexacimalCheckBox.Size = new System.Drawing.Size(90, 16);
            this.hexacimalCheckBox.TabIndex = 8;
            this.hexacimalCheckBox.Text = "Hexadecimal";
            this.hexacimalCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(244, 211);
            this.Controls.Add(this.hexacimalCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeCB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okayBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 250);
            this.Name = "AddFunctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okayBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox hexacimalCheckBox;
    }
}