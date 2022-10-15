using PolygonEditor.Model;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Helpers
{
    internal class ScreenToElementFinder
    {
        public static (Vertex nearest, Polygon polygon) FindNearestVertex(BoardState state, int x, int y)
        {
            (Vertex v, Polygon p, double distance) min = (null, null, double.MaxValue);
            foreach (Polygon p in state.polygons)
            {
                foreach (Vertex v in p.Vertices)
                {
                    var currentDistance = Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2);
                    if (min.distance > currentDistance)
                    {
                        min = (v, p, currentDistance);
                    }
                }
            }

            return (min.v, min.p);
        }

        /// <summary>
        /// Find nearest edge calculating distance from its middle
        /// </summary>
        /// <param name="state"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static (Edge nearest, Polygon polygon) FindNearestEdge(BoardState state, int x, int y)
        {
            (Edge e, Polygon p, double distance) min = (null, null, double.MaxValue);
            foreach (Polygon p in state.polygons)
            {
                foreach (Edge e in p.Edges)
                {
                    (int x, int y) middle = ((e.beginning.x + e.end.x) / 2, (e.beginning.y + e.end.y) / 2);

                    var currentDistance = Math.Pow(x - middle.x, 2) + Math.Pow(y - middle.y, 2);
                    if (currentDistance < min.distance)
                    {
                        min = (e, p, currentDistance);
                    }
                }
            }

            return (min.e, min.p);
        }

        public static Polygon FindNearestPolygon(BoardState state, int x, int y)
        {
            (Polygon p, double distance) min = (null, double.MaxValue);

            foreach (Polygon p in state.polygons)
            {
                double middleX = p.Vertices.Select(v => v.x).Sum() / p.Vertices.Count;
                double middleY = p.Vertices.Select(v => v.y).Sum() / p.Vertices.Count;

                var currentDistance = Math.Pow(x - middleX, 2) + Math.Pow(y - middleY, 2);
                if (currentDistance < min.distance)
                {
                    min = (p, currentDistance);
                }
            }

            return min.p;
        }
    }
}
