using Plate_Visualization.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    class Element : PlateObject
    {
        public int Id
        {
            get; set;
        }

        public Stiffness Stiffness
        {
            get; set;
        }

        public List<Node> Nodes
        {
            get; set;
        }

        public double Width
        {
            get; set;
        }

        public double Length
        {
            get; set;
        }

        public Element(int id, double width, double length)
        {
            Id = id;
            State = State.Normal;
            Length = length;
            Width = width;
            Stiffness = new Stiffness();
            Nodes = new List<Node>();
        }

        public Element(int id, double width, double length, Node n0, Node n1, Node n2, Node n3)
        {
            Id = id;
            Nodes = new List<Node>();
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);
            Nodes.Add(n3);
            State = State.Normal;
            Length = length;
            Width = width;
            Stiffness = new Stiffness();
        }

        public override bool IsOnHover(MouseEventArgs e)
        {
            List<PointF> polygon = new List<PointF>();
            polygon.Add(new PointF(Nodes[0].Position.X + Graphic.NODE_SIZE / 2, Nodes[0].Position.Y + Graphic.NODE_SIZE / 2));
            polygon.Add(new PointF(Nodes[1].Position.X - Graphic.NODE_SIZE / 2, Nodes[1].Position.Y + Graphic.NODE_SIZE / 2));
            polygon.Add(new PointF(Nodes[3].Position.X - Graphic.NODE_SIZE / 2, Nodes[3].Position.Y - Graphic.NODE_SIZE / 2));
            polygon.Add(new PointF(Nodes[2].Position.X + Graphic.NODE_SIZE / 2, Nodes[2].Position.Y - Graphic.NODE_SIZE / 2));
            return MathHelper.IsPointInPolygon(e.Location, polygon);
            /*
            if (Nodes[0].X + Graphic.NODE_SIZE / 2 < e.Location.X && e.Location.X < Nodes[3].X - Graphic.NODE_SIZE / 2
                && Nodes[0].Y + Graphic.NODE_SIZE / 2 < e.Location.Y && e.Location.Y < Nodes[3].Y - Graphic.NODE_SIZE / 2)
                return true;
            return false;
            */
        }

        public override bool IsSelected()
        {
            if (Stiffness.E != 0 || Stiffness.H != 0 || Stiffness.V != 0)
                return true;
            return false;
        }
    }
}
