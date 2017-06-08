namespace Plate_Visualization
{
    partial class NodeBondsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bondWithOy = new System.Windows.Forms.CheckBox();
            this.bondWithOx = new System.Windows.Forms.CheckBox();
            this.bondWithZ = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bondWithOy);
            this.groupBox1.Controls.Add(this.bondWithOx);
            this.groupBox1.Controls.Add(this.bondWithZ);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исключить перемещения и моменты";
            // 
            // bondWithOy
            // 
            this.bondWithOy.AutoSize = true;
            this.bondWithOy.Location = new System.Drawing.Point(58, 86);
            this.bondWithOy.Name = "bondWithOy";
            this.bondWithOy.Size = new System.Drawing.Size(40, 17);
            this.bondWithOy.TabIndex = 2;
            this.bondWithOy.Text = "My";
            this.bondWithOy.UseVisualStyleBackColor = true;
            // 
            // bondWithOx
            // 
            this.bondWithOx.AutoSize = true;
            this.bondWithOx.Location = new System.Drawing.Point(58, 63);
            this.bondWithOx.Name = "bondWithOx";
            this.bondWithOx.Size = new System.Drawing.Size(40, 17);
            this.bondWithOx.TabIndex = 1;
            this.bondWithOx.Text = "Mx";
            this.bondWithOx.UseVisualStyleBackColor = true;
            // 
            // bondWithZ
            // 
            this.bondWithZ.AutoSize = true;
            this.bondWithZ.Location = new System.Drawing.Point(58, 40);
            this.bondWithZ.Name = "bondWithZ";
            this.bondWithZ.Size = new System.Drawing.Size(33, 17);
            this.bondWithZ.TabIndex = 0;
            this.bondWithZ.Text = "Z";
            this.bondWithZ.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(13, 140);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(95, 139);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // NodeBondsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(183, 173);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NodeBondsForm";
            this.ShowIcon = false;
            this.Text = "Связи в узлах";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox bondWithOy;
        private System.Windows.Forms.CheckBox bondWithOx;
        private System.Windows.Forms.CheckBox bondWithZ;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}