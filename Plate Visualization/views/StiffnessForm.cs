using System;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Stiffness form
    /// </summary>
    public partial class StiffnessForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StiffnessForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stiffness">Stiffness</param>
        public StiffnessForm(Stiffness stiffness)
        {
            InitializeComponent();
            eInput.Text = stiffness.E.ToString();
            hInput.Text = stiffness.H.ToString();
            vInput.Text = stiffness.V.ToString();
        }

        /// <summary>
        /// Call when ok button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            MainForm parent = (MainForm)this.Owner;
            float E, V, H;
            if (!float.TryParse(eInput.Text, out E) ||
                !float.TryParse(hInput.Text, out H) ||
                !float.TryParse(vInput.Text, out V))
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (E < 0 || V < 0 || H < 0)
            {
                MessageBox.Show("Некорректный ввод. Все значения должны быть не отрицательными!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Stiffness s = new Stiffness(E, V, H);
            parent.SetStiffness(s);
            Close();
        }
    }
}
