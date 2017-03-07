using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plate_Visualization
{
    public enum State { Normal, Selecting, Selected }

    public delegate void MouseHoverHandler(object sender);
    public delegate void MouseLeaveHandler(object sender);
    public delegate void MouseClickHandler(object sender);

    abstract class PlateObject
    {
        public State State
        {
            get; set;
        }
        public bool Hovered
        {
            get; set;
        }
        public event MouseHoverHandler MouseHover;
        public event MouseLeaveHandler MouseLeave;
        public event MouseClickHandler MouseClick;

        abstract public bool IsOnHover(MouseEventArgs e);
        public void OnMouseClick(MouseEventArgs e)
        {
            MouseClick?.Invoke(this);
        }

        public void OnMouseHover(MouseEventArgs e)
        {
            if (Hovered == false)
            {
                Hovered = true;
                MouseHover?.Invoke(this);
            }
        }

        public void OnMouseLeave(MouseEventArgs e)
        {
            if (Hovered == true)
            {
                Hovered = false;
                MouseLeave?.Invoke(this);
            }
        }
    }
}
