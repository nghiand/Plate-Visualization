using Plate_Visualization.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Plate_Visualization
{
    class Plate
    {
        public List<Element> Elements
        {
            get; set;
        }
        public List<Node> Nodes
        {
            get; set;
        }
        public List<PlateObject> Objects
        {
            get; set;
        }
        public int Width
        {
            get; set;
        }
        public int Length
        {
            get; set;
        }
        private List<Tuple<int, float>> Widths, Lengths;

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

        private void CreateNodes()
        {
            Nodes = new List<Node>();
            Objects = new List<PlateObject>();
            Node node;

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

        private void GenerateNodePositionIn2D(int graphicWidth, int graphicLength)
        {
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

        private void GenerateNodePositionIn3D(int graphicWidth, int graphicLength)
        {
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
                        Widths[currentWidth].Item1, Lengths[currentLength].Item1,
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

        public void TranslateTo3D(int graphicWidth, int graphicLength)
        {
            GenerateNodePositionIn3D(graphicWidth, graphicLength);
        }

        public void TranslateTo2D(int graphicWidth, int graphicLength)
        {
            GenerateNodePositionIn2D(graphicWidth, graphicLength);
        }

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

        public void Move(PointF movingVector)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Position = new PointF(
                    Nodes[i].X + movingVector.X,
                    Nodes[i].Y + movingVector.Y);
            }
        }

        public bool Modified
        {
            get; set;
        }

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

        public void SetBonds(List<int> bonds)
        {
            List<Node> selectingNodes = SelectingNodes();
            foreach (Node n in selectingNodes)
            {
                n.Bonds = bonds;
            }
        }

        public void DeselectNodes()
        {
            List<Node> selectingNodes = SelectingNodes();
            foreach (Node n in selectingNodes)
            {
                n.Deselect();
            }
        }

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

        public void DeselectElements()
        {
            List<Element> selectingElements = SelectingElements();
            foreach (Element e in selectingElements)
            {
                e.Deselect();
            }
        }

        public void SetStiffness(Stiffness s)
        {
            List<Element> selectingElements = SelectingElements();
            foreach (Element e in selectingElements)
            {
                e.Stiffness = s;
            }
        }

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
    }
}
