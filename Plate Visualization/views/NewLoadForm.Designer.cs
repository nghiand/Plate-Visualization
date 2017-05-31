namespace Plate_Visualization.views
{
    partial class NewLoadForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createLoadOkButton = new System.Windows.Forms.Button();
            this.createLoadCancelButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Значение";
            // 
            // pInput
            // 
            this.pInput.Location = new System.Drawing.Point(74, 17);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(100, 20);
            this.pInput.TabIndex = 1;
            this.pInput.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "т";
            // 
            // createLoadOkButton
            // 
            this.createLoadOkButton.Location = new System.Drawing.Point(116, 276);
            this.createLoadOkButton.Name = "createLoadOkButton";
            this.createLoadOkButton.Size = new System.Drawing.Size(75, 23);
            this.createLoadOkButton.TabIndex = 3;
            this.createLoadOkButton.Text = "ОК";
            this.createLoadOkButton.UseVisualStyleBackColor = true;
            this.createLoadOkButton.Click += new System.EventHandler(this.createLoadOkButton_Click);
            // 
            // createLoadCancelButton
            // 
            this.createLoadCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.createLoadCancelButton.Location = new System.Drawing.Point(197, 276);
            this.createLoadCancelButton.Name = "createLoadCancelButton";
            this.createLoadCancelButton.Size = new System.Drawing.Size(75, 23);
            this.createLoadCancelButton.TabIndex = 4;
            this.createLoadCancelButton.Text = "Отмена";
            this.createLoadCancelButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Plate_Visualization.Properties.Resources.axis;
            this.pictureBox1.Location = new System.Drawing.Point(16, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // NewLoadForm
            // 
            this.AcceptButton = this.createLoadOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.createLoadCancelButton;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.createLoadCancelButton);
            this.Controls.Add(this.createLoadOkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewLoadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Задание нагрузок";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createLoadOkButton;
        private System.Windows.Forms.Button createLoadCancelButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}