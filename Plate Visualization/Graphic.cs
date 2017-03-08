using System.Drawing;

namespace Plate_Visualization
{
    class Graphic
    {
        private Graphics g;
        public const int NODE_SIZE = 8;
        private const int FONT_SIZE = 10;

        private static Color[] FillColor = new Color[] { Color.White, Color.Red, Color.Lime };

        public Graphic(Graphics graphic)
        {
            g = graphic;
        }

        public void DrawNode(Node node, bool OnHover = false)
        {
            Pen pen = new Pen(Brushes.Blue, 2);
            g.DrawEllipse(
                pen,
                node.X - NODE_SIZE / 2,
                node.Y - NODE_SIZE / 2,
                NODE_SIZE, NODE_SIZE);

            SolidBrush brush;
            if (OnHover)
                brush = new SolidBrush(Color.Lime);
            else
                brush = new SolidBrush(FillColor[(int)node.State]);
            g.FillEllipse(
                brush,
                node.X - NODE_SIZE / 2,
                node.Y - NODE_SIZE / 2,
                NODE_SIZE, NODE_SIZE);
        }

        private void DrawNodeIndex(Node node)
        {
            g.DrawString((node.Id + 1).ToString(), new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Blue, node.X + 1, node.Y + 1);
        }

        public void DrawElement(Element element, bool OnHover = false)
        {
            SolidBrush brush;
            if (OnHover)
                brush = new SolidBrush(Color.Lime);
            else
                brush = new SolidBrush(FillColor[(int)element.State]);
            PointF[] PointFs = new PointF[4];
            PointFs[0] = new PointF(element.Nodes[0].X + 1, element.Nodes[0].Y + 1);
            PointFs[1] = new PointF(element.Nodes[1].X - 1, element.Nodes[1].Y + 1);
            PointFs[2] = new PointF(element.Nodes[3].X - 1, element.Nodes[3].Y - 1);
            PointFs[3] = new PointF(element.Nodes[2].X + 1, element.Nodes[2].Y - 1);
            g.FillPolygon(brush, PointFs);
            /*
            g.FillRectangle(
                brush,
                element.Nodes[0].X + 1,
                element.Nodes[0].Y + 1,
                element.Nodes[3].X - element.Nodes[0].X - 1,
                element.Nodes[3].Y - element.Nodes[0].Y - 1
            );
            */
            for (int i = 0; i < 4; i++)
            {
                DrawNode(element.Nodes[i]);
            }
            DrawNodeIndex(element.Nodes[0]);
            DrawElementIndex(element);
        }

        private void DrawElementIndex(Element element)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            PointF top = element.Nodes[0].Position;
            PointF bot = element.Nodes[3].Position;

            PointF center = new PointF((top.X + bot.X) / 2, (top.Y + bot.Y) / 2);

            int id = element.Id + 1;

            g.DrawString(id.ToString(), new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Blue, center, sf);
        }

        public void DrawPlate(Plate plate)
        {
            // draw plate
            g.Clear(Color.White);
            Pen pen = new Pen(Brushes.Blue);
            // draw vertical lines
            for (int i = 0; i < plate.Nodes.Count - plate.Width - 1; i++)
            {
                g.DrawLine(pen, plate.Nodes[i].Position, plate.Nodes[i + plate.Width + 1].Position);
            }
            // draw horizontal lines
            for (int i = 0; i <= plate.Length; i++)
            {
                for (int j = i * (plate.Width + 1); j < i * (plate.Width + 1) + plate.Width; j++)
                {
                    g.DrawLine(pen, plate.Nodes[j].Position, plate.Nodes[j + 1].Position);
                }
            }
            // draw elements
            for (int i = 0; i < plate.Elements.Count; i++)
            {
                DrawElement(plate.Elements[i]);
            }
            // draw nodes
            for (int i = 0; i < plate.Nodes.Count; i++)
            {
                DrawNode(plate.Nodes[i]);
            }

            // draw nodes index
            for (int i = 0; i < plate.Nodes.Count; i++)
            {
                DrawNodeIndex(plate.Nodes[i]);
            }

            // draw elements index
            for (int i = 0; i < plate.Elements.Count; i++)
            {
                DrawElementIndex(plate.Elements[i]);
            }
        }

        public void MouseHover(object sender)
        {
            if (sender is Node)
            {
                Node n = sender as Node;
                DrawNode(n, true);
            }
            else if (sender is Element)
            {
                Element e = sender as Element;
                DrawElement(e, true);
            }
        }

        public void MouseLeave(object sender)
        {
            if (sender is Node)
            {
                Node n = sender as Node;
                DrawNode(n, false);
            }
            else if (sender is Element)
            {
                Element e = sender as Element;
                DrawElement(e, false);
            }
        }

        public void MouseClick(object sender)
        {
            if (sender is Node)
            {
                Node n = sender as Node;
                DrawNode(n, false);
            }
            else if (sender is Element)
            {
                Element e = sender as Element;
                DrawElement(e, false);
            }
        }
    }
}
