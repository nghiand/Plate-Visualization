using System.Windows.Forms;

namespace Plate_Visualization.views
{
    /// <summary>
    /// New Load form
    /// </summary>
    public partial class NewLoadForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NewLoadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Call when create load ok button is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void createLoadOkButton_Click(object sender, System.EventArgs e)
        {
            MainForm parent = (MainForm)Owner;
            float P;
            if (!float.TryParse(pInput.Text, out P))
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (P < 0)
            {
                MessageBox.Show("Некорректный ввод. Значение должно быть не отрицательным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            parent.SetLoads(P);
            Close();
        }
    }
}
