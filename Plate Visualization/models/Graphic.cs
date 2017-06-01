using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Plate_Visualization
{
    /// <summary>
    /// Class to Draw on graphics
    /// </summary>
    public class Graphic
    {
        /// <summary>
        /// Graphics
        /// </summary>
        private Graphics g;
        /// <summary>
        /// Node size
        /// </summary>
        public const int NODE_SIZE = 8;
        /// <summary>
        /// Font size
        /// </summary>
        private const int FONT_SIZE = 10;
        /// <summary>
        /// Color list
        /// </summary>
        private static Color[] FillColor = new Color[] { Color.White, Color.Gray, Color.LightGray };
        /// <summary>
        /// Color object while hovering
        /// </summary>
        private static Color HoveredColor = Color.LightBlue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graphic">Graphics</param>
        public Graphic(Graphics graphic)
        {
            g = graphic;
        }

        private void DrawArrowhead(Pen pen, PointF p, float nx, float ny, float length)
        {
            float ax = length * (-ny - nx);
            float ay = length * (nx - ny);
            PointF[] points =
            {
                new PointF(p.X + ax, p.Y + ay),
                p,
                new PointF(p.X - ay, p.Y + ax)
            };
            g.DrawLines(pen, points);
        }

        private void DrawArrow(Pen pen, PointF p1, PointF p2, float length)
        {
            // Draw the shaft.
            g.DrawLine(pen, p1, p2);

            // Find the arrow shaft unit vector.
            float vx = p2.X - p1.X;
            float vy = p2.Y - p1.Y;
            float dist = (float)Math.Sqrt(vx * vx + vy * vy);
            vx /= dist;
            vy /= dist;
            DrawArrowhead(pen, p2, vx, vy, length);
        }

        /// <summary>
        /// Draw node
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="OnHover">On hover</param>
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
                brush = new SolidBrush(HoveredColor);
            else
                brush = new SolidBrush(FillColor[(int)node.State]);
            g.FillEllipse(
                brush,
                node.X - NODE_SIZE / 2,
                node.Y - NODE_SIZE / 2,
                NODE_SIZE, NODE_SIZE);
        }

        /// <summary>
        /// Draw node index
        /// </summary>
        /// <param name="node">Node</param>
        private void DrawNodeIndex(Node node, bool result = false)
        {
            if (!result)
                g.DrawString((node.Id + 1).ToString(), new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Blue, node.X + 1, node.Y + 1);
            else
                g.DrawString((node.Id + 1).ToString(), new Font("Consolas", FONT_SIZE, FontStyle.Regular), Brushes.Blue, node.X + 1, node.Y + node.Delta + 1);
        }

        /// <summary>
        /// Draw element
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="OnHover">On hover</param>
        public void DrawElement(Element element, bool OnHover = false)
        {
            SolidBrush brush;
            if (OnHover)
                brush = new SolidBrush(HoveredColor);
            else
                brush = new SolidBrush(FillColor[(int)element.State]);
            PointF[] PointFs = new PointF[4];
            PointFs[0] = element.Nodes[0].Position;
            PointFs[1] = element.Nodes[1].Position;
            PointFs[2] = element.Nodes[3].Position;
            PointFs[3] = element.Nodes[2].Position;
            g.FillPolygon(brush, PointFs);
            g.DrawPolygon(new Pen(Color.Blue), PointFs);
            for (int i = 0; i < 4; i++)
            {
                DrawNode(element.Nodes[i]);
            }
            DrawNodeIndex(element.Nodes[0]);
            DrawElementIndex(element);
        }

        /// <summary>
        /// Draw element index
        /// </summary>
        /// <param name="element">Element</param>
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

        /// <summary>
        /// Draw plate
        /// </summary>
        /// <param name="plate">Plate</param>
        public void DrawPlate(Plate plate)
        {
            // draw plate
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

        /// <summary>
        /// Draw load
        /// </summary>
        /// <param name="load">Load</param>
        public void DrawLoad(Load load)
        {
            PointF pos = ((Node)load.Position).Position;
            using (Pen p = new Pen(Brushes.Green, 4f))
            {
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(p, pos.X, pos.Y - 50, pos.X, pos.Y);
            }
        }

        /// <summary>
        /// Draw loads list
        /// </summary>
        /// <param name="loads">Loads list</param>
        public void DrawLoads(List<Load> loads)
        {
            foreach (Load l in loads)
                DrawLoad(l);
        }

        /// <summary>
        /// Draw scheme
        /// </summary>
        /// <param name="scheme">Scheme</param>
        public void DrawScheme(Scheme scheme)
        {
            g.Clear(Color.White);
            DrawPlate(scheme.Plate);
            DrawLoads(scheme.Loads);
        }

        /// <summary>
        /// Call when mouse hovers on an object
        /// </summary>
        /// <param name="sender">Object</param>
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

        /// <summary>
        /// Call when mouse leaves an object
        /// </summary>
        /// <param name="sender">Object</param>
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

        /// <summary>
        /// Call when mouse clicks on an object
        /// </summary>
        /// <param name="sender">Object</param>
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

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            g.Clear(Control.DefaultBackColor);
        }

        public void DrawPlateResult(Plate plate)
        {
            // draw plate
            Pen pen = new Pen(Brushes.Red, 2);
            Pen bluePen = new Pen(Brushes.Blue);
            // draw vertical lines
            for (int i = 0; i <= plate.Width; i++)
            {
                List<PointF> points = new List<PointF>();
                List<PointF> originalPoints = new List<PointF>();
                for (int j = i; j < plate.Nodes.Count; j += plate.Width + 1)
                {
                    points.Add(new PointF(plate.Nodes[j].X, plate.Nodes[j].Y + plate.Nodes[j].Delta * plate.Unit));
                    originalPoints.Add(plate.Nodes[j].Position);
                }
                GraphicsPath gPath = new GraphicsPath();
                gPath.AddCurve(points.ToArray());
                g.DrawPath(pen, gPath);
                g.DrawLines(bluePen, originalPoints.ToArray());
            }

            // draw horizontal lines
            for (int i = 0; i < plate.Nodes.Count; i += plate.Width + 1)
            {
                List<PointF> points = new List<PointF>();
                List<PointF> originalPoints = new List<PointF>();
                for (int j = 0; j <= plate.Width; j++)
                {
                    points.Add(new PointF(plate.Nodes[i + j].X, plate.Nodes[i + j].Y + plate.Nodes[i + j].Delta * plate.Unit));
                    originalPoints.Add(plate.Nodes[i + j].Position);
                }
                GraphicsPath gPath = new GraphicsPath();
                gPath.AddCurve(points.ToArray());
                g.DrawPath(pen, gPath);
                g.DrawLines(bluePen, originalPoints.ToArray());
            }

            for (int i = 0; i < plate.Nodes.Count; i++)
            {
                if (plate.Nodes[i].Delta != 0)
                {
                    DrawArrow(bluePen, plate.Nodes[i].Position, new PointF(plate.Nodes[i].X, plate.Nodes[i].Y + plate.Nodes[i].Delta * plate.Unit), 5);
                }
            }
        }

        public void DrawSchemeResult(Scheme scheme)
        {
            g.Clear(Color.White);
            DrawPlateResult(scheme.Plate);
        }
    }
}
