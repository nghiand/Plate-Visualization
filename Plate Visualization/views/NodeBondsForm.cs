using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Bonds form
    /// </summary>
    public partial class NodeBondsForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NodeBondsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bonds">Bonds</param>
        public NodeBondsForm(List<int> bonds)
        {
            InitializeComponent();
            bondWithZ.Checked = (bonds[0] == 1);
            bondWithOx.Checked = (bonds[1] == 1);
            bondWithOy.Checked = (bonds[2] == 1);
        }

        /// <summary>
        /// Call when cancel button is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Call when ok button is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
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
