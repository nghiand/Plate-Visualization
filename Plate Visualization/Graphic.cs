using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plate_Visualization
{
    class Graphic
    {
        private System.Drawing.Graphics g;
        public const int NODE_SIZE = 8;
        private const int FONT_SIZE = 10;

        private static Color[] FillColor = new Color[] { Color.White, Color.Red, Color.Blue };

        public Graphic(System.Drawing.Graphics graphic)
        {
            this.g = graphic;
        }

        private void DrawNode(Node node)
        {
            Pen pen = new Pen(Brushes.Blue);
            g.DrawEllipse(
                pen,
                node.X - NODE_SIZE / 2,
                node.Y - NODE_SIZE / 2,
                NODE_SIZE, NODE_SIZE);

            SolidBrush brush;
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

        private void DrawElementIndex(Element element)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Point top = element.Nodes[0].Point;
            Point bot = element.Nodes[3].Point;

            Point center = new Point((top.X + bot.X) / 2, (top.Y + bot.Y) / 2);

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
                g.DrawLine(pen, plate.Nodes[i].Point, plate.Nodes[i + plate.Width + 1].Point);
            }
            // draw horizontal lines
            for (int i = 0; i <= plate.Length; i++)
            {
                for (int j = i * (plate.Width + 1); j < i * (plate.Width + 1) + plate.Width; j++)
                {
                    g.DrawLine(pen, plate.Nodes[j].Point, plate.Nodes[j + 1].Point);
                }
            }
            // draw elements
            for (int i = 0; i < plate.Elements.Count; i++)
            {
                SolidBrush brush = new SolidBrush(FillColor[(int)plate.Elements[i].State]);
                g.FillRectangle(
                    brush,
                    plate.Elements[i].Nodes[0].X + 1,
                    plate.Elements[i].Nodes[0].Y + 1,
                    plate.Elements[i].Nodes[3].X - plate.Elements[i].Nodes[0].X - 1,
                    plate.Elements[i].Nodes[3].Y - plate.Elements[i].Nodes[0].Y - 1
                );
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
    }
}
