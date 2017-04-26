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
                // TODO: Add dialog to show error message
                return;
            }
            parent.SetLoads(P);
            Close();
        }
    }
}
