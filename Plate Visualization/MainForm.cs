using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public partial class MainForm : Form
    {
        private Plate plate;
        private Graphic graphic;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphic = new Graphic(graph.CreateGraphics());
            status.Text = "Started";
        }

        public void getPlateData(List<Tuple<int, float>> inputWidth, List<Tuple<int, float>> inputLength)
        {
            if (inputWidth.Count == 0 || inputLength.Count == 0)
            {
                // TODO: Add dialog to show message
                return;
            }
            plate = new Plate(inputWidth, inputLength, graph.Width, graph.Height);
            graphic.DrawPlate(plate);
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

        // Zoom in/out
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            graph.Focus();
            if (graph.Focused == true && e.Delta != 0)
            {
                plate.Zoom(e.Location, e.Delta > 0);
                graphic.DrawPlate(plate);
            }
        }

        private Point startingPoint = Point.Empty;
        private bool panning = false;

        private void graph_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
