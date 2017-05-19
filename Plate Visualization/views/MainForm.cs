using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public partial class MainForm : Form
    {
        private Graphic graphic;
        private Scheme scheme;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Initial()
        {
            status.Text = "";
            SetToolItemsAvailability(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphic = new Graphic(graph.CreateGraphics());
            Initial();
        }

        private void SetToolItemsAvailability(bool enabled)
        {
            selectNodeButton.Enabled = enabled;
            bondButton.Enabled = enabled;
            selectElementButton.Enabled = enabled;
            stiffnessButton.Enabled = enabled;
            saveStripButton.Enabled = enabled;
            saveAsStripButton.Enabled = enabled;
            view2D.Enabled = enabled;
            view3D.Enabled = enabled;
        }

        public void CreatePlate(string name, List<Tuple<int, float>> inputWidth, List<Tuple<int, float>> inputLength)
        {
            if (inputWidth.Count == 0 || inputLength.Count == 0 || name == "")
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            scheme = new Scheme();
            scheme.Name = name;
            scheme.Plate = new Plate(inputWidth, inputLength, graph.Width, graph.Height);
            scheme.Loads = new List<Load>();
            scheme.Plate.Subscribe(this);
            scheme.IsModified = true;

            InitiateTools();

            graphic.DrawScheme(scheme);
        }

        private void InitiateTools()
        {
            selectElementButton.Enabled = true;
            selectNodeButton.Enabled = true;
            saveStripButton.Enabled = true;
            saveAsStripButton.Enabled = true;
            view2D.Enabled = true;
            view3D.Enabled = true;
            view2D.Checked = true;
            view3D.Checked = false;
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
            Close();
        }

        // Zoom in/out
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            graph.Focus();
            if (scheme == null)
                return;
            if (graph.Focused == true && e.Delta != 0)
            {
                scheme.Plate.Zoom(e.Location, e.Delta > 0);
                graphic.DrawScheme(scheme);
            }
        }

        private PointF startingPoint = PointF.Empty;
        private bool panning = false;

        private void graph_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                panning = true;
                startingPoint = new PointF(e.Location.X, e.Location.Y);
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
                PointF movingVector = new PointF(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                scheme.Plate.Move(movingVector);
                startingPoint = new PointF(e.Location.X, e.Location.Y);
                graphic.DrawScheme(scheme);
            }
            else if (scheme != null)
            {
                scheme.Plate.OnMouseMove(e);
            }
        }

        private void graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (scheme != null && e.Button == MouseButtons.Left)
            {
                scheme.Plate.OnMouseClick(e);
            }
        }

        private void graph_SizeChanged(object sender, EventArgs e)
        {
            if (scheme != null)
            {
                graphic = new Graphic(graph.CreateGraphics());
                graphic.DrawScheme(scheme);
            }
        }

        public void plateObject_MouseClick(object sender)
        {
            if (selectNodeButton.Checked && sender is Node)
            {
                ((PlateObject)sender).Toggle();
            }
            else if (selectElementButton.Checked && sender is Element)
            {
                ((PlateObject)sender).Toggle();
            }
        }

        public void plateObject_MouseHover(object sender)
        {
            if (sender is Node)
            {
                Node node = (Node)sender;
                graphic.DrawNode(node, true);
                graphic.DrawLoads(scheme.Loads);
                status.Text = "Связи: (" + node.Bonds[0].ToString()
                    + ", " + node.Bonds[0].ToString()
                    + ", " + node.Bonds[0].ToString() + ")";
            }
            else if (sender is Element)
            {
                Element element = (Element)sender;
                graphic.DrawElement(element, true);
                graphic.DrawLoads(scheme.Loads);
                status.Text = "E = " + element.Stiffness.E
                    + ", H = " + element.Stiffness.H.ToString()
                    + ", V = " + element.Stiffness.V.ToString();
            }
        }

        public void plateObject_MouseLeave(object sender)
        {
            if (sender is Node)
            {
                graphic.DrawNode((Node)sender);
                graphic.DrawLoads(scheme.Loads);
            }
            else if (sender is Element)
            {
                graphic.DrawElement((Element)sender);
                graphic.DrawLoads(scheme.Loads);
            }
            status.Text = "";
        }

        public void plateObject_Selected(object sender)
        {
            if (sender is Node)
            {
                graphic.DrawNode((Node)sender);
                graphic.DrawLoads(scheme.Loads);
            }
            else if (sender is Element)
            {
                graphic.DrawElement((Element)sender);
                graphic.DrawLoads(scheme.Loads);
            }
        }

        public void plateObject_Deselected(object sender)
        {
            if (sender is Node)
            {
                graphic.DrawNode((Node)sender);
                graphic.DrawLoads(scheme.Loads);
            }
            else if (sender is Element)
            {
                graphic.DrawElement((Element)sender);
                graphic.DrawLoads(scheme.Loads);
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
                stiffnessButton.Enabled = true;
                selectNodeButton.Checked = false;
                bondButton.Enabled = false;
            }
        }

        private void stiffnessButton_Click(object sender, EventArgs e)
        {
            List<Element> selectingElements = scheme.Plate.SelectingElements();
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
                bondButton.Enabled = true;
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
                scheme.Plate.DeselectNodes();
            }
        }

        private void bondButton_Click(object sender, EventArgs e)
        {
            List<Node> selectingNodes = scheme.Plate.SelectingNodes();
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
            scheme.Plate.SetBonds(bonds);
        }

        public void SetStiffness(Stiffness s)
        {
            scheme.Plate.SetStiffness(s);
        }

        private void selectElementButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectElementButton.Checked)
            {
            }
            else
            {
                scheme.Plate.DeselectElements();
            }
        }

        private void view2D_Click(object sender, EventArgs e)
        {
            if (view2D.Checked == false)
            {
                view2D.Checked = true;
                view3D.Checked = false;
                if (scheme == null)
                    return;
                scheme.Plate.TranslateTo2D(graph.Width, graph.Height);
                graphic.DrawScheme(scheme);
            }
        }

        private void view3D_Click(object sender, EventArgs e)
        {
            if (view3D.Checked == false)
            {
                view3D.Checked = true;
                view2D.Checked = false;
                if (scheme == null)
                    return;
                scheme.Plate.TranslateTo3D(graph.Width, graph.Height);
                graphic.DrawScheme(scheme);
            }
        }

        public void SetLoads(float P)
        {
            List<Node> selectingNodes = scheme.Plate.SelectingNodes();
            foreach (Node n in selectingNodes)
            {
                Load l = new Load(P, n);
                bool found = false;
                for (int i = 0; i < scheme.Loads.Count; i++)
                {
                    if (scheme.Loads[i].Position == n)
                    {
                        scheme.Loads[i] = l;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    scheme.Loads.Add(l);
                }
                graphic.DrawScheme(scheme);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            List<Node> selectingNodes = scheme.Plate.SelectingNodes();
            using (views.NewLoadForm loadForm = new views.NewLoadForm())
            {
                loadForm.ShowDialog(this);
            }
        }

        private string DisplaySaveFileDialog(string type)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = type;
            saveFileDialog.Title = "Сохранить в файл";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }

        private string DisplayOpenFileDialog(string type)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = type;
            openFileDialog.Title = "Открыть файл";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void SaveSchemeToFile()
        {
            if (scheme.Filename == "")
            {
                string filename = DisplaySaveFileDialog("Plate Visualization File|*.pv");
                if (filename != "")
                {
                    scheme.SaveToFile(filename);
                }
            }
            else
            {
                scheme.SaveFile();
            }
        }

        private void OpenScheme()
        {
            string filename = DisplayOpenFileDialog("Plate Visualization File|*.pv");
            if (filename != "")
            {
                if (scheme != null && scheme.IsModified)
                {
                    // TODO: show dialog to ask save file
                }
                Scheme new_scheme = new Scheme();
                new_scheme.OpenFromFile(filename);
                scheme = new_scheme;
                graphic.DrawScheme(scheme);
                scheme.Plate.Subscribe(this);

                InitiateTools();

                bool check = false;
                foreach (Element element in scheme.Plate.Elements)
                {
                    if (element.State == State.Selecting)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    selectElementButton.Checked = true;
                }
                else
                {
                    foreach (Node node in scheme.Plate.Nodes)
                    {
                        if (node.State == State.Selecting)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check)
                    {
                        selectNodeButton.Checked = true;
                    }
                }
                if (scheme.Plate.Mode2D == true)
                {
                    view2D.Checked = true;
                    view3D.Checked = false;
                }
                else
                {
                    view2D.Checked = false;
                    view3D.Checked = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSchemeToFile();
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            SaveSchemeToFile();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scheme == null)
                return;
            string filename = DisplaySaveFileDialog("Text File|*.txt");

            if (filename != "")
            {
                scheme.Export(filename);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphic.Clear();
            scheme = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenScheme();
        }
    }
}
