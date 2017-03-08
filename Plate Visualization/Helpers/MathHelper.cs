using System;
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
    }
}
