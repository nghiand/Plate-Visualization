using Plate_Visualization.Helpers;
using System;
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

        public int X
        {
            get
            {
                return this.Position.X;
            }
        }
        public int Y
        {
            get
            {
                return this.Position.Y;
            }
        }

        public Point Position
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

        public Node(int id, int x, int y)
        {
            Id = id;
            Position = new Point(x, y);
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
