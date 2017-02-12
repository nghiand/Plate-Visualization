using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public partial class NewPlateForm : Form
    {
        public NewPlateForm()
        {
            InitializeComponent();
        }

        private void createCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createOkButton_Click(object sender, EventArgs e)
        {
            List<Tuple<int, float>> inputWidth = new List<Tuple<int, float>>();

            for (int rows = 0; rows < widthData.Rows.Count - 1; rows++)
            {
                float length = 0;
                if (widthData.Rows[rows].Cells[0].Value == null ||
                    !float.TryParse(widthData.Rows[rows].Cells[0].Value.ToString(),  out length))
                {
                    // TODO: Add dialog to show error message
                    return;
                }
                int cnt = 0;
                if (widthData.Rows[rows].Cells[1].Value == null ||
                    !int.TryParse(widthData.Rows[rows].Cells[1].Value.ToString(), out cnt))
                {
                    // TODO: Add dialog to show error message
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
                    // TODO: Add dialog to show error message
                    return;
                }
                int cnt = 0;
                if (lengthData.Rows[rows].Cells[1].Value == null ||
                    !int.TryParse(lengthData.Rows[rows].Cells[1].Value.ToString(), out cnt))
                {
                    // TODO: Add dialog to show error message
                    return;
                }
                inputLength.Add(new Tuple<int, float>(cnt, length));
            }

            MainForm parent = (MainForm)this.Owner;
            parent.CreatePlate(inputWidth, inputLength);
            this.Close();
        }
    }
}
