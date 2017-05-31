using Plate_Visualization.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Class describes plate node
    /// </summary>
    public class Node : PlateObject
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// X
        /// </summary>
        public float X
        {
            get
            {
                return Position.X;
            }
        }
        /// <summary>
        /// Y
        /// </summary>
        public float Y
        {
            get
            {
                return Position.Y;
            }
        }
        /// <summary>
        /// Position
        /// </summary>
        public PointF Position
        {
            get; set;
        }
        
        /// <summary>
        /// Bonds with Z, azis Ox, axis Oy
        /// </summary>
        public List<int> Bonds
        {
            get; set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier</param>
        public Node(int id)
        {
            Id = id;
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public Node(int id, float x, float y)
        {
            Id = id;
            Position = new PointF(x, y);
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="position">Position</param>
        public Node(int id, PointF position)
        {
            Id = id;
            Position = position;
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        /// <summary>
        /// Check if node is selected
        /// </summary>
        /// <returns>true if node is selected</returns>
        public override bool IsSelected()
        {
            foreach (int k in Bonds)
            {
                if (k != 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check if node is on mouse hovering
        /// </summary>
        /// <param name="e">Mouse event</param>
        /// <returns>True if node is on hover</returns>
        public override bool IsOnHover(MouseEventArgs e)
        {
            double dis = MathHelper.Distance(e.Location, Position);
            return dis <= Graphic.NODE_SIZE / 2;
        }
    }
}
