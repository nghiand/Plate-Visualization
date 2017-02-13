using Plate_Visualization.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plate_Visualization
{
    class Node
    {
        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        private Point coordinate;
        public int X
        {
            get
            {
                return this.coordinate.X;
            }
        }
        public int Y
        {
            get
            {
                return this.coordinate.Y;
            }
        }

        public Point Point
        {
            get
            {
                return this.coordinate;
            }
            set
            {
                this.coordinate = value;
            }
        }

        // bonds with Z, axis Ox, axis Oy
        private List<int> bonds = null;

        public List<int> Bonds
        {
            get
            {
                return this.bonds;
            }
            set
            {
                this.bonds = value;
            }
        }

        private State state;
        public State State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public Node(int id)
        {
            this.id = id;
            bonds = new List<int>(3) { 0, 0, 0 };
            this.state = State.Normal;
        }

        public Node(int id, int x, int y)
        {
            this.id = id;
            this.coordinate = new Point(x, y);
            bonds = new List<int>(3) { 0, 0, 0 };
            this.state = State.Normal;
        }

        public bool Hovered
        {
            get; set;
        }


        public void MouseMove(Point location)
        {
            double dis = MathHelper.distance(location, Point);
            if (dis <= Graphic.NODE_SIZE / 2)
            {
                if (Hovered == false)
                {
                    Hovered = true;
                    MouseHover?.Invoke(this);
                }
            }
            else
            {
                if (Hovered == true)
                {
                    Hovered = false;
                    MouseLeave?.Invoke(this);
                }
            }
        }

        private bool IsSelected()
        {
            foreach (int k in bonds)
            {
                if (k != 0)
                    return true;
            }
            return false;
        }

        public void Selecting()
        {
            if (state == State.Selecting)
            {
                if (IsSelected())
                    state = State.Selected;
                else
                    state = State.Normal;
            }
            else
            {
                state = State.Selecting;
            }
            MouseClick?.Invoke(this);
        }

        public event MouseHoverHandler MouseHover;
        public event MouseLeaveHandler MouseLeave;
        public event MouseClickHandler MouseClick;
    }
}
