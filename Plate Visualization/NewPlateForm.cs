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
            List<Tuple<int, float>> inputHeight = new List<Tuple<int, float>>();

            for (int rows = 0; rows < heightData.Rows.Count - 1; rows++)
            {
                float length = float.Parse(heightData.Rows[rows].Cells[0].Value.ToString());
                int cnt = int.Parse(heightData.Rows[rows].Cells[1].Value.ToString());
                inputHeight.Add(new Tuple<int, float>(cnt, length));
            }

            List<Tuple<int, float>> inputWidth = new List<Tuple<int, float>>();

            for (int rows = 0; rows < widthData.Rows.Count - 1; rows++)
            {
                float length = float.Parse(widthData.Rows[rows].Cells[0].Value.ToString());
                int cnt = int.Parse(widthData.Rows[rows].Cells[1].Value.ToString());
                inputWidth.Add(new Tuple<int, float>(cnt, length));
            }

            MainForm parent = (MainForm)this.Owner;
            parent.getPlateData(inputHeight, inputWidth);
            this.Close();
        }
    }
}
