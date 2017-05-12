using System.Windows.Forms;

namespace Plate_Visualization.views
{
    public partial class NewLoadForm : Form
    {
        public NewLoadForm()
        {
            InitializeComponent();
        }

        private void createLoadOkButton_Click(object sender, System.EventArgs e)
        {
            MainForm parent = (MainForm)Owner;
            float P;
            if (!float.TryParse(pInput.Text, out P))
            {
                MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parent.SetLoads(P);
            Close();
        }
    }
}
