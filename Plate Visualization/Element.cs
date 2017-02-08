using System;
using System.Collections.Generic;
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

        public Element(int id, double length, double width)
        {
            this.id = id;
            this.state = State.Normal;
            this.length = length;
            this.width = width;
        }

        public Element(int id, double length, double width, Node n0, Node n1, Node n2, Node n3)
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
    }
}
