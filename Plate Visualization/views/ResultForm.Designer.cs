namespace Plate_Visualization.views
{
    partial class ResultForm
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
            this.resultPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // resultPicturebox
            // 
            this.resultPicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPicturebox.Location = new System.Drawing.Point(0, 0);
            this.resultPicturebox.Name = "resultPicturebox";
            this.resultPicturebox.Size = new System.Drawing.Size(1036, 647);
            this.resultPicturebox.TabIndex = 0;
            this.resultPicturebox.TabStop = false;
            this.resultPicturebox.SizeChanged += new System.EventHandler(this.resultPicturebox_SizeChanged);
            this.resultPicturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.resultPicturebox_Paint);
            this.resultPicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resultPicturebox_MouseDown);
            this.resultPicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resultPicturebox_MouseMove);
            this.resultPicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resultPicturebox_MouseUp);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 647);
            this.Controls.Add(this.resultPicturebox);
            this.Name = "ResultForm";
            this.ShowIcon = false;
            this.Text = "Результат расчета";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox resultPicturebox;
    }
}