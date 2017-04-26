using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public partial class NodeBondsForm : Form
    {
        public NodeBondsForm()
        {
            InitializeComponent();
        }

        public NodeBondsForm(List<int> bonds)
        {
            InitializeComponent();
            bondWithZ.Checked = (bonds[0] == 1);
            bondWithOx.Checked = (bonds[1] == 1);
            bondWithOy.Checked = (bonds[2] == 1);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            MainForm parent = (MainForm)this.Owner;
            List<int> bonds = new List<int>(3) {
                bondWithZ.Checked ? 1 : 0,
                bondWithOx.Checked ? 1 : 0,
                bondWithOy.Checked ? 1 : 0
            };
            parent.SetBonds(bonds);
            Close();
        }
    }
}
