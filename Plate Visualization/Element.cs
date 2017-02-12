using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate_Visualization
{
    class Element
    {
        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        double e;
        public double E
        {
            get
            {
                return e;
            }
            set
            {
                e = value;
            }
        }
        double v;
        public double V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }
        double h;
        public double H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }

        private List<Node> nodes = new List<Node>();
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        private double width, length;
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
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

        public Element(int id, double width, double length)
        {
            this.id = id;
            this.state = State.Normal;
            this.length = length;
            this.width = width;
        }

        public Element(int id, double width, double length, Node n0, Node n1, Node n2, Node n3)
        {
            this.id = id;
            nodes.Add(n0);
            nodes.Add(n1);
            nodes.Add(n2);
            nodes.Add(n3);
            this.state = State.Normal;
            this.length = length;
            this.width = width;
        }

        public bool Hovered
        {
            get; set;
        }


        public void MouseMove(Point location)
        {
            if (nodes[0].X + Graphic.NODE_SIZE / 2 < location.X && location.X < nodes[3].X - Graphic.NODE_SIZE / 2
                                && nodes[0].Y + Graphic.NODE_SIZE / 2 < location.Y && location.Y < nodes[3].Y - Graphic.NODE_SIZE / 2)
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

        public event MouseHoverHandler MouseHover;
        public event MouseLeaveHandler MouseLeave;
    }
}
