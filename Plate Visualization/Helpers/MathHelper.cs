using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plate_Visualization.Helpers
{
    class MathHelper
    {
        /// <summary>
        /// Scale factor
        /// </summary>
        public const float SCALE_FACTOR = 0.1f;

        /// <summary>
        /// Calculate distance between two points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance</returns>
        public static double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// Calculate ccw function
        /// </summary>
        /// <param name="p0">First point</param>
        /// <param name="p1">Second point</param>
        /// <param name="p2">Third point</param>
        /// <returns>Ccw</returns>
        public static float Ccw(PointF p0, PointF p1, PointF p2)
        {
            return (p1.X - p0.X) * (p2.Y - p0.Y) - (p1.Y - p0.Y) * (p2.X - p0.X);
        }

        /// <summary>
        /// Check if a point is in a polygon
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="polygon">List of points - vertex of polygon</param>
        /// <returns>True if point is in polygon</returns>
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
