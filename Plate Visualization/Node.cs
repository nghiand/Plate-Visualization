using Plate_Visualization.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    class Node : PlateObject
    {
        public int Id
        {
            get; set;
        }

        public float X
        {
            get
            {
                return Position.X;
            }
        }
        public float Y
        {
            get
            {
                return Position.Y;
            }
        }

        public PointF Position
        {
            get; set;
        }

        // bonds with Z, axis Ox, axis Oy
        public List<int> Bonds
        {
            get; set;
        }

        public Node(int id)
        {
            Id = id;
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        public Node(int id, float x, float y)
        {
            Id = id;
            Position = new PointF(x, y);
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        public Node(int id, PointF position)
        {
            Id = id;
            Position = position;
            Bonds = new List<int>(3) { 0, 0, 0 };
            State = State.Normal;
        }

        public override bool IsSelected()
        {
            foreach (int k in Bonds)
            {
                if (k != 0)
                    return true;
            }
            return false;
        }

        public override bool IsOnHover(MouseEventArgs e)
        {
            double dis = MathHelper.Distance(e.Location, Position);
            return dis <= Graphic.NODE_SIZE / 2;
        }
    }
}
