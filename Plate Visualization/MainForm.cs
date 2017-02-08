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
    public partial class MainForm : Form
    {
        private Plate plate;
        private Graphics graphic;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphic = graph.CreateGraphics();
        }

        public void getPlateData(List<Tuple<int, float>> inputWidth, List<Tuple<int, float>> inputLength)
        {

            plate = new Plate(inputWidth, inputLength, graph.Width, graph.Height);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewPlateForm newForm = new NewPlateForm())
            {
                newForm.ShowDialog(this);
            }
        }

        private void newStripButton_Click(object sender, EventArgs e)
        {
            using (NewPlateForm newForm = new NewPlateForm())
            {
                newForm.ShowDialog(this);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
