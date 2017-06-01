using Plate_Visualization.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Class describes plate
    /// </summary>
    public class Plate
    {
        public const float MAX_LENGTH = 1000f;
        public const float MAX_WIDTH = 1000f;
        public const float MAX_ELEMENT_CNT = 100;
        /// <summary>
        /// Elements list
        /// </summary>
        public List<Element> Elements
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
        /// Objects list
        /// </summary>
        public List<PlateObject> Objects
        {
            get; set;
        }
        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get; set;
        }
        /// <summary>
        /// Length
        /// </summary>
        public int Length
        {
            get; set;
        }
        /// <summary>
        /// Check if current plate is display on 2d mode
        /// </summary>
        public bool Mode2D
        {
            get; set;
        }
        /// <summary>
        /// Input lists
        /// </summary>
        public List<Tuple<int, float>> Widths, Lengths;
        /// <summary>
        /// Modified
        /// </summary>
        public bool Modified
        {
            get; set;
        }

        /// <summary>
        /// Unit
        /// </summary>
        public float Unit
        {
            get
            {
                if (Elements == null || Elements.Count == 0) return 0;
                return MathHelper.Distance(Elements[0].Nodes[0].Position, Elements[0].Nodes[1].Position) / Elements[0].Width;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="widths">List of elements along the first axis</param>
        /// <param name="lengths">List of elements along the second axis</param>
        /// <param name="graphicWidth">Windows width</param>
        /// <param name="graphicLength">Windows length</param>
        /// <param name="modified">Modified</param>
        public Plate(List<Tuple<int, float>> widths, List<Tuple<int, float>> lengths, int graphicWidth, int graphicLength, bool modified = true)
        {
            Widths = widths;
            Lengths = lengths;
            Objects = new List<PlateObject>();
            CreateNodes();
            GenerateNodePositionIn2D(graphicWidth, graphicLength);
            GenerateElement();
            Modified = modified;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="widths">List of elements along the first axis</param>
        /// <param name="lengths">List of elements along the second axis</param>
        public Plate(List<Tuple<int, float>> widths, List<Tuple<int, float>> lengths)
        {
            Widths = widths;
            Lengths = lengths;
            Objects = new List<PlateObject>();
            CreateNodes();
            GenerateElement();
            Modified = false;
        }

        public Plate()
        {
        }

        /// <summary>
        /// Create nodes base on widths and lengths arrays
        /// </summary>
        private void CreateNodes()
        {
            Nodes = new List<Node>();
            Objects = new List<PlateObject>();
            Node node;

            node = new Node(Nodes.Count);
            Nodes.Add(node);
            Objects.Add(node);

            Width = 0;
            foreach (Tuple<int, float> elementX in Widths)
            {
                Width += elementX.Item1;
            }

            Length = 0;
            foreach (Tuple<int, float> elementY in Lengths)
            {
                Length += elementY.Item1;
            }

            foreach (Tuple<int, float> elementX in Widths)
            {
                for (int i = 0; i < elementX.Item1; i++)
                {
                    node = new Node(Nodes.Count);
                    Nodes.Add(node);
                    Objects.Add(node);
                }
            }

            foreach (Tuple<int, float> elementY in Lengths)
            {
                for (int j = 0; j < elementY.Item1; j++)
                {
                    node = new Node(Nodes.Count);
                    Nodes.Add(node);
                    Objects.Add(node);
                    foreach (Tuple<int, float> elementX in Widths)
                    {
                        for (int i = 0; i < elementX.Item1; i++)
                        {
                            node = new Node(Nodes.Count);
                            Nodes.Add(node);
                            Objects.Add(node);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generate nodes positions in 2d mode
        /// </summary>
        /// <param name="graphicWidth">Windows width</param>
        /// <param name="graphicLength">Windows length</param>
        private void GenerateNodePositionIn2D(int graphicWidth, int graphicLength)
        {
            Mode2D = true;
            float lengthX = 0.8f * graphicWidth;
            float lengthY = 0.8f * graphicLength;

            float sumX = 0;
            foreach (Tuple<int, float> elementX in Widths)
            {
                sumX += elementX.Item2 * elementX.Item1;
            }
            float sumY = 0;
            foreach (Tuple<int, float> elementY in Lengths)
            {
                sumY += elementY.Item2 * elementY.Item1;
            }

            float unit = Math.Min(lengthX / sumX, lengthY / sumY);

            lengthX = sumX * unit;
            lengthY = sumY * unit;

            float paddingX = (1.0f * graphicWidth - lengthX) / 2;
            float paddingY = (1.0f * graphicLength - lengthY) / 2;

            float x = paddingX;
            float y = paddingY;
            int count = 0;
            Nodes[count++].Position = new PointF(x, y);
            foreach (Tuple<int, float> elementX in Widths)
            {
                for (int i = 0; i < elementX.Item1; i++)
                {
                    x += elementX.Item2 * unit;
                    Nodes[count++].Position = new PointF(x, y);
                }
            }

            foreach (Tuple<int, float> elementY in Lengths)
            {
                for (int j = 0; j < elementY.Item1; j++)
                {
                    x = paddingX;
                    y += elementY.Item2 * unit;
                    Nodes[count++].Position = new PointF(x, y);
                    foreach (Tuple<int, float> elementX in Widths)
                    {
                        for (int i = 0; i < elementX.Item1; i++)
                        {
                            x += elementX.Item2 * unit;
                            Nodes[count++].Position = new PointF(x, y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generate nodes positions in 3D mode
        /// </summary>
        /// <param name="graphicWidth"></param>
        /// <param name="graphicLength"></param>
        private void GenerateNodePositionIn3D(int graphicWidth, int graphicLength)
        {
            Mode2D = false;
            float lengthX = 0.8f * graphicWidth;
            float lengthY = 0.8f * graphicLength;

            float sumX = 0;
            Width = 0;
            foreach (Tuple<int, float> elementX in Widths)
            {
                sumX += elementX.Item2 * elementX.Item1;
                Width += elementX.Item1;
            }
            float sumY = 0;
            Length = 0;
            foreach (Tuple<int, float> elementY in Lengths)
            {
                sumY += elementY.Item2 * elementY.Item1;
                Length += elementY.Item1;
            }

            float unit = Math.Min(lengthX / (sumX + sumY / 2), lengthY / (sumY * (float)Math.Sqrt(3) / 2));

            lengthX = (sumX + sumY / 2) * unit;
            lengthY = (sumY * (float)Math.Sqrt(3) / 2) * unit;

            float paddingX = (1.0f * graphicWidth - lengthX) / 2;
            float paddingY = (1.0f * graphicLength - lengthY) / 2;

            float x = paddingX + sumY / 2 * unit;
            float y = paddingY;
            float tempX = x;
            int count = 0;
            Nodes[count++].Position = new PointF(x, y);
            foreach (Tuple<int, float> elementX in Widths)
            {
                for (int i = 0; i < elementX.Item1; i++)
                {
                    x += elementX.Item2 * unit;
                    Nodes[count++].Position = new PointF(x, y);
                }
            }


            foreach (Tuple<int, float> elementY in Lengths)
            {
                for (int j = 0; j < elementY.Item1; j++)
                {
                    tempX -= elementY.Item2 * unit / 2;
                    x = tempX;
                    y += elementY.Item2 * unit * (float)Math.Sqrt(3) / 2;
                    Nodes[count++].Position = new PointF(x, y);
                    foreach (Tuple<int, float> elementX in Widths)
                    {
                        for (int i = 0; i < elementX.Item1; i++)
                        {
                            x += elementX.Item2 * unit;
                            Nodes[count++].Position = new PointF(x, y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generate elements
        /// </summary>
        private void GenerateElement()
        {
            Elements = new List<Element>();
            int nodeId = 0;
            int currentWidth = 0, currentLength = 0;
            int maxWidth = Widths[0].Item1, maxLength = Lengths[0].Item1;
            for (int i = 0; i < Length; i++)
            {
                if (i >= maxLength)
                {
                    currentLength++;
                    maxLength += Lengths[currentLength].Item1;
                }
                currentWidth = 0;
                maxWidth = Widths[0].Item1;
                for (int j = 0; j < Width; j++)
                {
                    if (j >= maxWidth)
                    {
                        currentWidth++;
                        maxWidth += Widths[currentWidth].Item1;
                    }
                    Element element = new Element(i * Width + j,
                        Widths[currentWidth].Item2, Lengths[currentLength].Item2,
                        Nodes[nodeId],
                        Nodes[nodeId + 1],
                        Nodes[nodeId + Width + 1],
                        Nodes[nodeId + Width + 2]);
                    Elements.Add(element);
                    Objects.Add(element);
                    nodeId++;
                }
                nodeId++;
            }
        }

        /// <summary>
        /// Translate nodes positions to 3D mode
        /// </summary>
        /// <param name="graphicWidth">Windows width</param>
        /// <param name="graphicLength">Windows length</param>
        public void TranslateTo3D(int graphicWidth, int graphicLength)
        {
            GenerateNodePositionIn3D(graphicWidth, graphicLength);
        }

        /// <summary>
        /// Translate nodes positions to 2D mode
        /// </summary>
        /// <param name="graphicWidth">Windows width</param>
        /// <param name="graphicLength">Windows length</param>
        public void TranslateTo2D(int graphicWidth, int graphicLength)
        {
            GenerateNodePositionIn2D(graphicWidth, graphicLength);
        }

        /// <summary>
        /// Zoom
        /// </summary>
        /// <param name="location">Pointer location</param>
        /// <param name="zoomIn">Check if zoom in</param>
        public void Zoom(PointF location, bool zoomIn)
        {
            float factor = 1.0f;
            if (zoomIn)
            {
                factor += MathHelper.SCALE_FACTOR;
            }
            else
            {
                factor -= MathHelper.SCALE_FACTOR;
            }
            float x0 = location.X;
            float y0 = location.Y;

            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Position = new PointF(
                    factor * (Nodes[i].X - x0) + x0, 
                    factor * (Nodes[i].Y - y0) + y0);
            }
        }

        /// <summary>
        /// Move
        /// </summary>
        /// <param name="movingVector">Moving vector</param>
        public void Move(PointF movingVector)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Position = new PointF(
                    Nodes[i].X + movingVector.X,
                    Nodes[i].Y + movingVector.Y);
            }
        }

        /// <summary>
        /// Call when mouse move on plate
        /// </summary>
        /// <param name="e">Mouse event</param>
        public void OnMouseMove(MouseEventArgs e)
        {
            PlateObject hoveredObj = null;

            foreach (PlateObject obj in Objects)
            {
                if (obj.IsOnHover(e))
                {
                    hoveredObj = obj;
                    break;
                }
            }

            foreach (PlateObject obj in Objects)
            {
                if (obj.Hovered && obj != hoveredObj)
                {
                    obj.OnMouseLeave(e);
                }
            }

            if (hoveredObj != null && !hoveredObj.Hovered)
                hoveredObj.OnMouseHover(e);
        }

        /// <summary>
        /// Call when mouse click on plate
        /// </summary>
        /// <param name="e"></param>
        public void OnMouseClick(MouseEventArgs e)
        {
            foreach (PlateObject obj in Objects)
            {
                if (obj.IsOnHover(e))
                {
                    obj.OnMouseClick(e);
                    break;
                }
            }
        }

        /// <summary>
        /// Selecting objects
        /// </summary>
        /// <returns>List of selecting objects</returns>
        public List<PlateObject> SelectingObjects()
        {
            List<PlateObject> list = new List<PlateObject>();
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].State == State.Selecting)
                {
                    list.Add(Objects[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// Selecting nodes
        /// </summary>
        /// <returns>List of selecting nodes</returns>
        public List<Node> SelectingNodes()
        {
            List<Node> list = new List<Node>();
            foreach (Node n in Nodes)
            {
                if (n.State == State.Selecting)
                {
                    list.Add(n);
                }
            }
            return list;
        }

        /// <summary>
        /// Set bonds to nodes
        /// </summary>
        /// <param name="bonds">Bonds</param>
        public void SetBonds(List<int> bonds)
        {
            List<Node> selectingNodes = SelectingNodes();
            foreach (Node n in selectingNodes)
            {
                n.Bonds = bonds;
            }
        }

        /// <summary>
        /// Deselect all nodes
        /// </summary>
        public void DeselectNodes()
        {
            List<Node> selectingNodes = SelectingNodes();
            foreach (Node n in selectingNodes)
            {
                n.Deselect();
            }
        }

        /// <summary>
        /// Selecting elements
        /// </summary>
        /// <returns>List of selecting elements</returns>
        public List<Element> SelectingElements()
        {
            List<Element> list = new List<Element>();
            foreach (Element e in Elements)
            {
                if (e.State == State.Selecting)
                {
                    list.Add(e);
                }
            }
            return list;
        }

        /// <summary>
        /// Deselect elements
        /// </summary>
        public void DeselectElements()
        {
            List<Element> selectingElements = SelectingElements();
            foreach (Element e in selectingElements)
            {
                e.Deselect();
            }
        }

        /// <summary>
        /// Set stiffness for elements
        /// </summary>
        /// <param name="s"></param>
        public void SetStiffness(Stiffness s)
        {
            List<Element> selectingElements = SelectingElements();
            foreach (Element e in selectingElements)
            {
                e.Stiffness = s;
            }
        }

        /// <summary>
        /// Subscribe form to listen events
        /// </summary>
        /// <param name="form">Form</param>
        public void Subscribe(MainForm form)
        {
            foreach (PlateObject obj in Objects)
            {
                obj.MouseClick += form.plateObject_MouseClick;
                obj.MouseHover += form.plateObject_MouseHover;
                obj.MouseLeave += form.plateObject_MouseLeave;
                obj.Selected += form.plateObject_Selected;
                obj.Deselected += form.plateObject_Deselected;
            }
        }

        /// <summary>
        /// Clone plate
        /// </summary>
        /// <returns>Cloned plate</returns>
        public Plate Clone()
        {
            Plate ret = new Plate();
            ret.Widths = Widths.GetRange(0, Widths.Count);
            ret.Lengths = Lengths.GetRange(0, Lengths.Count);
            ret.Width = Width;
            ret.Length = Length;
            ret.Nodes = new List<Node>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                ret.Nodes.Add(Nodes[i].Clone());
            }
            ret.Elements = new List<Element>();
            for (int i = 0; i < Elements.Count; i++)
            {
                Element e = Elements[i].Clone();
                for (int j = 0; j < Elements[i].Nodes.Count; j++)
                {
                    Node n = ret.Nodes[Elements[i].Nodes[j].Id];
                    e.Nodes.Add(n);
                }
                ret.Elements.Add(e);
            }
            ret.Objects = new List<PlateObject>();
            for (int i = 0; i < ret.Nodes.Count; i++)
                ret.Objects.Add(ret.Nodes[i]);
            for (int i = 0; i < ret.Elements.Count; i++)
                ret.Objects.Add(ret.Elements[i]);
            //ret.Objects = Objects.GetRange(0, Objects.Count);
            return ret;
        }
    }
}
