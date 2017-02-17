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
            plate = null;
            SetToolItemsAvailability(false);
        }

        private void SetToolItemsAvailability(bool enabled)
        {
            selectNodeButton.Enabled = enabled;
            bondButton.Enabled = enabled;
            selectElementButton.Enabled = enabled;
            stiffnessButton.Enabled = enabled;
            saveStripButton.Enabled = enabled;
            saveAsStripButton.Enabled = enabled;
        }

        public void CreatePlate(List<Tuple<int, float>> inputWidth, List<Tuple<int, float>> inputLength)
        {
            if (inputWidth.Count == 0 || inputLength.Count == 0)
            {
                // TODO: Add dialog to show message
                return;
            }
            plate = new Plate(inputWidth, inputLength, graph.Width, graph.Height, graphic);

            selectElementButton.Enabled = true;
            selectNodeButton.Enabled = true;
            saveStripButton.Enabled = true;
            saveAsStripButton.Enabled = true;

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
            if (plate == null)
                return;
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
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                panning = true;
                startingPoint = new Point(e.Location.X, e.Location.Y);
            }
        }

        private void graph_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                Point movingVector = new Point(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                plate.Move(movingVector);
                startingPoint = new Point(e.Location.X, e.Location.Y);
                graphic.DrawPlate(plate);
            }
            else if (plate != null)
            {
                plate.MouseMove(e.Location);
            }
        }

        private void graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectElementButton.Checked)
                {
                    plate.MouseClickOnElement();
                    stiffnessButton.Enabled = true;
                }
                else if (selectNodeButton.Checked)
                {
                    plate.MouseClickOnNode();
                    bondButton.Enabled = true;
                }
            }
        }

        private void graph_SizeChanged(object sender, EventArgs e)
        {
            if (plate != null)
            {
                graphic = new Graphic(graph.CreateGraphics());
                plate.Subscribe(graphic);
                graphic.DrawPlate(plate);
            }
        }

        private void selectElementButton_Click(object sender, EventArgs e)
        {
            if (selectElementButton.Checked)
            {
                selectElementButton.Checked = false;
                stiffnessButton.Enabled = false;
            }
            else
            {
                selectElementButton.Checked = true;
                selectNodeButton.Checked = false;
                bondButton.Enabled = false;
            }
        }

        private void stiffnessButton_Click(object sender, EventArgs e)
        {
            List<Element> selectingElements = plate.SelectingElements();
            Stiffness stiffness = new Stiffness();
            if (selectingElements.Count > 0)
            {
                stiffness = selectingElements[0].Stiffness;
            }
            for (int i = 1; i < selectingElements.Count; i++)
            {
                if (!selectingElements[i].Stiffness.Equals(selectingElements[i - 1].Stiffness))
                {
                    stiffness = new Stiffness();
                    break;
                }
            }
            using (StiffnessForm stiffnessForm = new StiffnessForm(stiffness))
            {
                stiffnessForm.ShowDialog(this);
            }
        }

        private void selectNodeButton_Click(object sender, EventArgs e)
        {
            if (selectNodeButton.Checked)
            {
                selectNodeButton.Checked = false;
                bondButton.Enabled = false;
            }
            else
            {
                selectNodeButton.Checked = true;
                selectElementButton.Checked = false;
                stiffnessButton.Enabled = false;
            }
        }

        private void selectNodeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectNodeButton.Checked)
            {
            }
            else
            {
                plate.DeselectNodes();
            }
        }

        private void bondButton_Click(object sender, EventArgs e)
        {
            List<Node> selectingNodes = plate.SelectingNodes();
            List<int> bonds = new List<int>(3) { 0, 0, 0 };
            if (selectingNodes.Count > 0)
            {
                bonds = selectingNodes[0].Bonds;
            }
            for (int i = 1; i < selectingNodes.Count; i++)
            {
                if (!selectingNodes[i].Bonds.Equals(selectingNodes[i - 1].Bonds))
                {
                    bonds = new List<int>(3) { 0, 0, 0 };
                    break;
                }
            }
            using (NodeBondsForm bondsForm = new NodeBondsForm(bonds))
            {
                bondsForm.ShowDialog(this);
            }
        }

        public void SetBonds(List<int> bonds)
        {
            plate.SetBonds(bonds);
        }

        public void SetStiffness(Stiffness s)
        {
            plate.SetStiffness(s);
        }

        private void selectElementButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectElementButton.Checked)
            {
            }
            else
            {
                plate.DeselectElements();
            }
        }
    }
}
