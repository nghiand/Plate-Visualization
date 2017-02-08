using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate_Visualization
{
    class Plate
    {
        private List<Element> elements;
        public List<Element> Elements
        {
            get
            {
                return this.elements;
            }
        }
        private List<Node> nodes;
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }
        private int width;
        public int Width
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
        private int length;
        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = Length;
            }
        }

        public Plate(List<Tuple<int, float>> widths, List<Tuple<int, float>> lengths, int graphicWidth, int graphicLength)
        {
            nodes = new List<Node>();
            elements = new List<Element>();
            float lengthX = 0.8f * graphicWidth;
            float lengthY = 0.8f * graphicLength;

            float sumX = 0;
            this.width = 0;
            foreach (Tuple<int, float> elementX in widths)
            {
                sumX += elementX.Item2 * elementX.Item1;
                this.width += elementX.Item1;
            }
            float sumY = 0;
            this.length = 0;
            foreach (Tuple<int, float> elementY in lengths)
            {
                sumY += elementY.Item2 * elementY.Item1;
                this.length += elementY.Item1;
            }

            float unit = Math.Min(lengthX / sumX, lengthY / sumY);

            lengthX = sumX * unit;
            lengthY = sumY * unit;

            float paddingX = (1.0f * graphicWidth - lengthX) / 2;
            float paddingY = (1.0f * graphicLength - lengthY) / 2;

            float x = paddingX;
            float y = paddingY;
            nodes.Add(new Node(nodes.Count, (int)Math.Ceiling(x), (int)Math.Ceiling(y)));
            foreach (Tuple<int, float> elementX in widths)
            {
                for (int i = 0; i < elementX.Item1; i++)
                {
                    x += elementX.Item2 * unit;
                    nodes.Add(new Node(nodes.Count, (int)Math.Ceiling(x), (int)Math.Ceiling(y)));
                }
            }

            foreach (Tuple<int, float> elementY in lengths)
            {
                for (int j = 0; j < elementY.Item1; j++)
                {
                    x = paddingX;
                    y += elementY.Item2 * unit;
                    nodes.Add(new Node(nodes.Count, (int)Math.Ceiling(x), (int)Math.Ceiling(y)));
                    foreach (Tuple<int, float> elementX in widths)
                    {
                        for (int i = 0; i < elementX.Item1; i++)
                        {
                            x += elementX.Item2 * unit;
                            nodes.Add(new Node(nodes.Count, (int)Math.Ceiling(x), (int)Math.Ceiling(y)));
                        }
                    }
                }
            }

            int nodeId = 0;
            for (int i = 0; i < this.length; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    elements.Add(new Element(i * this.length + j,
                        widths[j].Item1, lengths[i].Item1,
                        nodes[nodeId],
                        nodes[nodeId + 1],
                        nodes[nodeId + this.width + 1],
                        nodes[nodeId + this.width + 2]));
                    nodeId++;
                }
                nodeId++;
            }
        }
    }
}
