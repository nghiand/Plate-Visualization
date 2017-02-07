namespace Plate_Visualization
{
    partial class NewPlateForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heightData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.widthData = new System.Windows.Forms.DataGridView();
            this.LengthWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LengthHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.createCancelButton = new System.Windows.Forms.Button();
            this.createOkButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Генерация плиты";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.heightData);
            this.groupBox1.Location = new System.Drawing.Point(13, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаг вдоль первой оси";
            // 
            // heightData
            // 
            this.heightData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.heightData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LengthHeight,
            this.NumberHeight});
            this.heightData.Location = new System.Drawing.Point(7, 32);
            this.heightData.Name = "heightData";
            this.heightData.Size = new System.Drawing.Size(159, 195);
            this.heightData.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Значение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.widthData);
            this.groupBox2.Location = new System.Drawing.Point(194, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаг вдоль второй оси";
            // 
            // widthData
            // 
            this.widthData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.widthData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LengthWidth,
            this.NumberWidth});
            this.widthData.Location = new System.Drawing.Point(7, 32);
            this.widthData.Name = "widthData";
            this.widthData.Size = new System.Drawing.Size(163, 195);
            this.widthData.TabIndex = 0;
            // 
            // LengthWidth
            // 
            this.LengthWidth.HeaderText = "L(м)";
            this.LengthWidth.Name = "LengthWidth";
            this.LengthWidth.Width = 60;
            // 
            // NumberWidth
            // 
            this.NumberWidth.HeaderText = "N";
            this.NumberWidth.Name = "NumberWidth";
            this.NumberWidth.Width = 60;
            // 
            // LengthHeight
            // 
            this.LengthHeight.Frozen = true;
            this.LengthHeight.HeaderText = "L(м)";
            this.LengthHeight.Name = "LengthHeight";
            this.LengthHeight.Width = 60;
            // 
            // NumberHeight
            // 
            this.NumberHeight.Frozen = true;
            this.NumberHeight.HeaderText = "N";
            this.NumberHeight.Name = "NumberHeight";
            this.NumberHeight.Width = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Количество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Значение";
            // 
            // createCancelButton
            // 
            this.createCancelButton.Location = new System.Drawing.Point(296, 273);
            this.createCancelButton.Name = "createCancelButton";
            this.createCancelButton.Size = new System.Drawing.Size(75, 23);
            this.createCancelButton.TabIndex = 3;
            this.createCancelButton.Text = "Cancel";
            this.createCancelButton.UseVisualStyleBackColor = true;
            this.createCancelButton.Click += new System.EventHandler(this.createCancelButton_Click);
            // 
            // createOkButton
            // 
            this.createOkButton.Location = new System.Drawing.Point(201, 273);
            this.createOkButton.Name = "createOkButton";
            this.createOkButton.Size = new System.Drawing.Size(75, 23);
            this.createOkButton.TabIndex = 4;
            this.createOkButton.Text = "OK";
            this.createOkButton.UseVisualStyleBackColor = true;
            this.createOkButton.Click += new System.EventHandler(this.createOkButton_Click);
            // 
            // NewPlateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 312);
            this.Controls.Add(this.createOkButton);
            this.Controls.Add(this.createCancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlateForm";
            this.ShowIcon = false;
            this.Text = "Создание плиты";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView heightData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView widthData;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button createCancelButton;
        private System.Windows.Forms.Button createOkButton;
    }
}