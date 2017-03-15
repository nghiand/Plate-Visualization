using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plate_Visualization.Helpers
{
    class MathHelper
    {
        public const float SCALE_FACTOR = 0.1f;
        public static double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static float Ccw(PointF p0, PointF p1, PointF p2)
        {
            return (p1.X - p0.X) * (p2.Y - p0.Y) - (p1.Y - p0.Y) * (p2.X - p0.X);
        }

        public static bool IsPointInPolygon(PointF p, List<PointF> polygon)
        {
            polygon.Add(polygon[0]);
            for (int i = 0; i < polygon.Count - 1; i++)
            {
                if (Ccw(p, polygon[i], polygon[i + 1]) <= 0) return false;
            }
            return true;
        }
    }
}
