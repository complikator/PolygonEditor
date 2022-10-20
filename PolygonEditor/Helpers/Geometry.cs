using PolygonEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Helpers
{
    internal class Geometry
    {
        public static double GetEdgeRate(Edge edge)
        {
            double xDiff = edge.beginning.x - edge.end.x;
            double yDiff = edge.beginning.y - edge.end.y;

            if (xDiff == 0)
            {
                return double.MaxValue;
            }

            return yDiff / xDiff;
        }

        public static double GetDistanceSquared((double x, double y) first, (double x, double y) second)
        {
            return Math.Pow(first.x - second.x, 2) + Math.Pow(first.y - second.y, 2);
        }

        public static double GetEdgeLength(Edge edge)
        {
            double squared = GetDistanceSquared((edge.beginning.x, edge.beginning.y), (edge.end.x, edge.end.y));
            return Math.Sqrt(squared);
        }
    }
}
