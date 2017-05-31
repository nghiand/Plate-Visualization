using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// New plate form
    /// </summary>
    public partial class NewPlateForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NewPlateForm()
        {
            InitializeComponent();
            widthData.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            widthData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            lengthData.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            lengthData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Call when cancel button is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void createCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Call when ok button is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
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

            float swidth = 0;
            int cnt_width = 0;
            for (int i = 0; i < inputWidth.Count; i++)
            {
                swidth += inputWidth[i].Item1 * inputWidth[i].Item2;
                cnt_width += inputWidth[i].Item1;
            }

            float slength = 0;
            int cnt_length = 0;
            for (int i = 0; i < inputLength.Count; i++)
            {
                slength += inputLength[i].Item1 * inputLength[i].Item2;
                cnt_length += inputLength[i].Item1;
            }

            if (swidth > Plate.MAX_WIDTH || slength > Plate.MAX_LENGTH)
            {
                MessageBox.Show("Длина/ширина плиты больше ограничения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cnt_width > Plate.MAX_ELEMENT_CNT || cnt_length > Plate.MAX_ELEMENT_CNT)
            {
                MessageBox.Show("Количество элементов вдоль оси больше ограничения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm parent = (MainForm)this.Owner;
            parent.CreatePlate(name, inputWidth, inputLength);
            Close();
        }
    }
}
