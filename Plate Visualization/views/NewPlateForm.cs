using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public partial class NewPlateForm : Form
    {
        public NewPlateForm()
        {
            InitializeComponent();
            widthData.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            widthData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            lengthData.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            lengthData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void createCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createOkButton_Click(object sender, EventArgs e)
        {
            string name = problemName.Text;
            if (name == "")
            {
                MessageBox.Show("Вводите название задачи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Tuple<int, float>> inputWidth = new List<Tuple<int, float>>();
            if (widthData.Rows.Count <= 1 || lengthData.Rows.Count <= 1)
            {
                MessageBox.Show("Пустой ввод не разрешен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int rows = 0; rows < widthData.Rows.Count - 1; rows++)
            {
                float length = 0;
                if (widthData.Rows[rows].Cells[0].Value == null ||
                    !float.TryParse(widthData.Rows[rows].Cells[0].Value.ToString(),  out length))
                {
                    MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int cnt = 0;
                if (widthData.Rows[rows].Cells[1].Value == null ||
                    !int.TryParse(widthData.Rows[rows].Cells[1].Value.ToString(), out cnt))
                {
                    MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                inputWidth.Add(new Tuple<int, float>(cnt, length));
            }

            List<Tuple<int, float>> inputLength = new List<Tuple<int, float>>();

            for (int rows = 0; rows < lengthData.Rows.Count - 1; rows++)
            {
                float length = 0;
                if (lengthData.Rows[rows].Cells[0].Value == null ||
                    !float.TryParse(lengthData.Rows[rows].Cells[0].Value.ToString(), out length))
                {
                    MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int cnt = 0;
                if (lengthData.Rows[rows].Cells[1].Value == null ||
                    !int.TryParse(lengthData.Rows[rows].Cells[1].Value.ToString(), out cnt))
                {
                    MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                inputLength.Add(new Tuple<int, float>(cnt, length));
            }

            MainForm parent = (MainForm)this.Owner;
            parent.CreatePlate(name, inputWidth, inputLength);
            Close();
        }
    }
}
