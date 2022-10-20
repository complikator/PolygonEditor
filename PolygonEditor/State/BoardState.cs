using PolygonEditor.Drawing;
using PolygonEditor.Model;
using PolygonEditor.Model.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.State
{
    public class BoardSnapshot
    {
        public Dictionary<Vertex, (int x, int y)> VerticesCoordinates { get; private set; } = new Dictionary<Vertex, (int x, int y)>();

        public Dictionary<Edge, Constraint> EdgesConstraints { get; private set; } = new Dictionary<Edge, Constraint>();

        public BoardSnapshot(BoardState from)
        {
            createPolygonsDeepCopy(from.polygons);
        }
        private void createPolygonsDeepCopy(List<Polygon> from)
        {
            foreach (Polygon polygon in from)
            {
                foreach (Vertex vertex in polygon.Vertices)
                {
                    VerticesCoordinates.Add(vertex, (vertex.x, vertex.y));
                }

                foreach (Edge edge in polygon.Edges)
                {
                    EdgesConstraints.Add(edge, edge.Constraint);
                }
            }
        }
    }

    public class BoardState
    {
        private BoardSnapshot currentSnapshot;

        public List<Polygon> polygons = new List<Polygon>();

        public void MakeSnapshot()
        {
            currentSnapshot = new BoardSnapshot(this);
        }

        public void RecreateFromLastSnapshot()
        {
            if (currentSnapshot == null)
            {
                throw new InvalidOperationException("Last snapshot is null");
            }

            RecreateFromSnapshot(currentSnapshot);
        }

        public BoardSnapshot GetSnapshot()
        {
            return new BoardSnapshot(this);
        }

        public void RecreateFromSnapshot(BoardSnapshot snapshot)
        {
            Console.WriteLine("Recreating from snapshot");

            foreach (Polygon polygon in polygons)
            {
                foreach (Vertex vertex in polygon.Vertices)
                {
                    vertex.x = snapshot.VerticesCoordinates[vertex].x;
                    vertex.y = snapshot.VerticesCoordinates[vertex].y;
                }

                foreach (Edge edge in polygon.Edges)
                {
                    edge.Constraint = snapshot.EdgesConstraints[edge];
                }
            }
        }
    }
}
