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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthData = new System.Windows.Forms.DataGridView();
            this.LengthHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lengthData = new System.Windows.Forms.DataGridView();
            this.LengthWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createCancelButton = new System.Windows.Forms.Button();
            this.createOkButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.problemName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Генерация плиты";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.widthData);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаг вдоль первой оси";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Значение";
            // 
            // widthData
            // 
            this.widthData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.widthData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LengthHeight,
            this.NumberHeight});
            this.widthData.Location = new System.Drawing.Point(7, 32);
            this.widthData.Name = "widthData";
            this.widthData.Size = new System.Drawing.Size(159, 195);
            this.widthData.TabIndex = 1;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lengthData);
            this.groupBox2.Location = new System.Drawing.Point(194, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаг вдоль второй оси";
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
            // lengthData
            // 
            this.lengthData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lengthData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LengthWidth,
            this.NumberWidth});
            this.lengthData.Location = new System.Drawing.Point(7, 32);
            this.lengthData.Name = "lengthData";
            this.lengthData.Size = new System.Drawing.Size(163, 195);
            this.lengthData.TabIndex = 2;
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
            // createCancelButton
            // 
            this.createCancelButton.Location = new System.Drawing.Point(296, 309);
            this.createCancelButton.Name = "createCancelButton";
            this.createCancelButton.Size = new System.Drawing.Size(75, 23);
            this.createCancelButton.TabIndex = 4;
            this.createCancelButton.Text = "Отмена";
            this.createCancelButton.UseVisualStyleBackColor = true;
            this.createCancelButton.Click += new System.EventHandler(this.createCancelButton_Click);
            // 
            // createOkButton
            // 
            this.createOkButton.Location = new System.Drawing.Point(201, 309);
            this.createOkButton.Name = "createOkButton";
            this.createOkButton.Size = new System.Drawing.Size(75, 23);
            this.createOkButton.TabIndex = 3;
            this.createOkButton.Text = "ОК";
            this.createOkButton.UseVisualStyleBackColor = true;
            this.createOkButton.Click += new System.EventHandler(this.createOkButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Имя задачи";
            // 
            // problemName
            // 
            this.problemName.Location = new System.Drawing.Point(86, 13);
            this.problemName.Name = "problemName";
            this.problemName.Size = new System.Drawing.Size(285, 20);
            this.problemName.TabIndex = 0;
            // 
            // NewPlateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 345);
            this.Controls.Add(this.problemName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.createOkButton);
            this.Controls.Add(this.createCancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlateForm";
            this.ShowIcon = false;
            this.Text = "Создание плиты";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView widthData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView lengthData;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button createCancelButton;
        private System.Windows.Forms.Button createOkButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox problemName;
    }
}