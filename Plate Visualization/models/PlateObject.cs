using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Object states
    /// </summary>
    public enum State { Normal, Selecting, Selected }

    /// <summary>
    /// Mouse hover handler
    /// </summary>
    /// <param name="sender">Sender</param>
    public delegate void MouseHoverHandler(object sender);
    /// <summary>
    /// Mouse leave handler
    /// </summary>
    /// <param name="sender">Sender</param>
    public delegate void MouseLeaveHandler(object sender);
    /// <summary>
    /// Mouse click handler
    /// </summary>
    /// <param name="sender">Sender</param>
    public delegate void MouseClickHandler(object sender);
    /// <summary>
    /// Seleted handler
    /// </summary>
    /// <param name="sender">Sender</param>
    public delegate void SelectedHandler(object sender);
    /// <summary>
    /// Deselected handler
    /// </summary>
    /// <param name="sender">Sender</param>
    public delegate void DeselectedHandler(object sender);


    /// <summary>
    /// Abstract class describes plate object (node and element)
    /// </summary>
    abstract class PlateObject
    {
        /// <summary>
        /// State
        /// </summary>
        public State State
        {
            get; set;
        }
        /// <summary>
        /// Hovered
        /// </summary>
        public bool Hovered
        {
            get; set;
        }
        /// <summary>
        /// Mouse hover handler
        /// </summary>
        public event MouseHoverHandler MouseHover;
        /// <summary>
        /// Mouse leave handler
        /// </summary>
        public event MouseLeaveHandler MouseLeave;
        /// <summary>
        /// Mouse click handler
        /// </summary>
        public event MouseClickHandler MouseClick;
        /// <summary>
        /// Selected handler
        /// </summary>
        public event SelectedHandler Selected;
        /// <summary>
        /// Deselected handler
        /// </summary>
        public event DeselectedHandler Deselected;

        /// <summary>
        /// Check if object is on mouse hover
        /// </summary>
        /// <param name="e">Mouse event</param>
        /// <returns>True if objecg is on mouse hover</returns>
        abstract public bool IsOnHover(MouseEventArgs e);
        /// <summary>
        /// Check if object is selected
        /// </summary>
        /// <returns>True if object is selected</returns>
        abstract public bool IsSelected();

        /// <summary>
        /// Call when mouse clicks on object
        /// </summary>
        /// <param name="e">Mouse event</param>
        public void OnMouseClick(MouseEventArgs e)
        {
            MouseClick?.Invoke(this);
        }

        /// <summary>
        /// Call when mouse hovers on object
        /// </summary>
        /// <param name="e">Mouse event</param>
        public void OnMouseHover(MouseEventArgs e)
        {
            if (Hovered == false)
            {
                Hovered = true;
                MouseHover?.Invoke(this);
            }
        }

        /// <summary>
        /// Call when mouse leaves object
        /// </summary>
        /// <param name="e">Mouse event</param>
        public void OnMouseLeave(MouseEventArgs e)
        {
            if (Hovered == true)
            {
                Hovered = false;
                MouseLeave?.Invoke(this);
            }
        }

        /// <summary>
        /// Toggle object's state
        /// </summary>
        public void Toggle()
        {
            if (State == State.Selecting)
                Deselect();
            else
                Select();
        }

        /// <summary>
        /// Select object
        /// </summary>
        public void Select()
        {
            State = State.Selecting;
            Selected?.Invoke(this);
        }

        /// <summary>
        /// Deselect object
        /// </summary>
        public void Deselect()
        {
            if (IsSelected())
                State = State.Selected;
            else
                State = State.Normal;
            Deselected?.Invoke(this);
        }
    }
}
