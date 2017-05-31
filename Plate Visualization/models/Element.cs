using Plate_Visualization.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Class describes Plate element
    /// </summary>
    public class Element : PlateObject
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// Stiffness
        /// </summary>
        public Stiffness Stiffness
        {
            get; set;
        }
        /// <summary>
        /// Nodes list
        /// </summary>
        public List<Node> Nodes
        {
            get; set;
        }
        /// <summary>
        /// Width
        /// </summary>
        public float Width
        {
            get; set;
        }
        /// <summary>
        /// Length
        /// </summary>
        public float Length
        {
            get; set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        public Element(int id, float width, float length)
        {
            Id = id;
            State = State.Normal;
            Length = length;
            Width = width;
            Stiffness = new Stiffness();
            Nodes = new List<Node>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        /// <param name="n0">First node</param>
        /// <param name="n1">Second node</param>
        /// <param name="n2">Third node</param>
        /// <param name="n3">Fouth node</param>
        public Element(int id, float width, float length, Node n0, Node n1, Node n2, Node n3)
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

        /// <summary>
        /// Check if element is on hover
        /// </summary>
        /// <param name="e">Mouse event</param>
        /// <returns>True if is on hover</returns>
        public override bool IsOnHover(MouseEventArgs e)
        {
            List<PointF> polygon = new List<PointF>();
            polygon.Add(Nodes[0].Position);
            polygon.Add(Nodes[1].Position);
            polygon.Add(Nodes[3].Position);
            polygon.Add(Nodes[2].Position);
            return MathHelper.IsPointInPolygon(e.Location, polygon);
            /*
            if (Nodes[0].X + Graphic.NODE_SIZE / 2 < e.Location.X && e.Location.X < Nodes[3].X - Graphic.NODE_SIZE / 2
                && Nodes[0].Y + Graphic.NODE_SIZE / 2 < e.Location.Y && e.Location.Y < Nodes[3].Y - Graphic.NODE_SIZE / 2)
                return true;
            return false;
            */
        }

        /// <summary>
        /// Check if stiffness is set
        /// </summary>
        /// <returns>True if stiffness is set</returns>
        public override bool IsSelected()
        {
            if (Stiffness.E != 0 || Stiffness.H != 0 || Stiffness.V != 0)
                return true;
            return false;
        }
    }
}
