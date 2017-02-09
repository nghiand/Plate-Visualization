using System.Collections.Generic;
using System.Drawing;

namespace Plate_Visualization
{
    public enum State { Normal, Selecting, Selected }

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

        public static int NodeSize = 10;

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
    }
}
