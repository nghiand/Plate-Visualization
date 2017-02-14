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
    public partial class NodeBondsForm : Form
    {
        public NodeBondsForm()
        {
            InitializeComponent();
        }

        public NodeBondsForm(List<int> bonds)
        {
            InitializeComponent();
            this.bondWithZ.Checked = (bonds[0] == 1);
            this.bondWithOx.Checked = (bonds[1] == 1);
            this.bondWithOy.Checked = (bonds[2] == 1);
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
            this.Close();
        }
    }
}
