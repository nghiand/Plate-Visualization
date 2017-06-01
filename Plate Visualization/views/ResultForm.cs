using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization.views
{
    public partial class ResultForm : Form
    {
        private Plate result;
        private Graphic graphic;
        /// <summary>
        /// Starting mouse click point
        /// </summary>
        private PointF startingPoint = PointF.Empty;
        /// <summary>
        /// Check is panning
        /// </summary>
        private bool panning = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResultForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultPlate">Result Plate</param>
        public ResultForm(Plate resultPlate)
        {
            InitializeComponent();
            result = resultPlate;
        }

        /// <summary>
        /// Result form load handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void ResultForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Result picturebox paint
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Paint event arguments</param>
        private void resultPicturebox_Paint(object sender, PaintEventArgs e)
        {
            graphic = new Graphic(e.Graphics);
            graphic.DrawPlateResult(result);
        }

        /// <summary>
        /// Call when mouse down on result picturebox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Mouse event arguments</param>
        private void resultPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                panning = true;
                startingPoint = new PointF(e.Location.X, e.Location.Y);
            }
        }

        /// <summary>
        /// Call when mouse up on result picturebox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Mouse event arguments</param>
        private void resultPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        /// <summary>
        /// Call when mouse move on result picturebox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Mouse event arguments</param>
        private void resultPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                PointF movingVector = new PointF(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                result.Move(movingVector);
                startingPoint = new PointF(e.Location.X, e.Location.Y);
                resultPicturebox.Refresh();
            }
        }

        /// <summary>
        /// Call when scroll mouse
        /// </summary>
        /// <param name="e">Mouse event</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            resultPicturebox.Focus();
            if (resultPicturebox.Focused == true && e.Delta != 0)
            {
                result.Zoom(e.Location, e.Delta > 0);
                resultPicturebox.Refresh();
            }
        }

        /// <summary>
        /// Call when result picturebox size changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        private void resultPicturebox_SizeChanged(object sender, EventArgs e)
        {
            resultPicturebox.Refresh();
        }
    }
}
