using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Model
{
    public class Polygon
    {
        private const int MINIMAL_VERTICES_NUMBER = 3;
        private bool isFinished = false;

        public List<Edge> Edges = new List<Edge>();
        public List<Vertex> Vertices = new List<Vertex>();

        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            private set
            {
                isFinished = value;
            }
        }

        public Polygon()
        {

        }

        public void addVertex(Vertex vertex)
        {
            if (Vertices.Count > 0)
            {
                Edges.Add(new Edge(Vertices[Vertices.Count - 1], vertex));
            }
            Vertices.Add(vertex);
        }

        public bool isPossibleToFinishPolygon()
        {
            return Vertices.Count >= Polygon.MINIMAL_VERTICES_NUMBER;
        }

        public void FinishPolygon()
        {
            if (!isPossibleToFinishPolygon())
            {
                throw new Exception("Cannot finish polygon");
            }

            Vertex first = Vertices[0];
            Vertex last = Vertices[Vertices.Count - 1];

            Edges.Add(new Edge(last, first));

            isFinished = true;
        }

        public void removeVertex(int which)
        {
            if (which > Vertices.Count - 1)
            {
                throw new ArgumentOutOfRangeException($"Cannot remove {which} vertex out of {Vertices.Count}");
            }

            Vertices.RemoveAt(which);
        }

        public void removeVertex(Vertex which)
        {
            if (Vertices.Count == Polygon.MINIMAL_VERTICES_NUMBER)
            {
                throw new Exception($"Cannot remove vertex, minimal number of vertices in polygon: {Polygon.MINIMAL_VERTICES_NUMBER}");
            }

            int index = Vertices.IndexOf(which);

            if (index == -1)
            {
                return;
            }

            if (index == 0)
            {
                Edges.Remove(Edges.Find(e => e.beginning == Vertices[0]));
                Edges.Remove(Edges.Find(e => e.end == Vertices[0]));
                
                Edges.Add(new Edge(Vertices[Vertices.Count - 1], Vertices[0]));
            }
            else if (index == Vertices.Count - 1)
            {
                Edges.Remove(Edges.Find(e => e.beginning == Vertices[index]));
                Edges.Remove(Edges.Find(e => e.end == Vertices[index]));
                Edges.Add(new Edge(Vertices[Vertices.Count - 1], Vertices[0]));

                Vertices.RemoveAt(index);
            }
            else
            {
                Edges.Remove(Edges.Find(e => e.beginning == Vertices[index]));
                Edges.Remove(Edges.Find(e => e.end == Vertices[index]));
                Edges.Add(new Edge(Vertices[index - 1], Vertices[index + 1]));

                Vertices.RemoveAt(index);
            }
        }

        public void addMiddleVertex(Edge which)
        {
            Vertex v = new Vertex((which.beginning.x + which.end.x) / 2, (which.beginning.y + which.end.y) / 2);

            Edges.Remove(which);
            Edges.Add(new Edge(which.beginning, v));
            Edges.Add(new Edge(v, which.end));

            int index = Vertices.IndexOf(which.beginning);
            Vertices.Insert(index + 1, v);
        }

        public void MoveVertex(Vertex v, int x, int y)
        {
            v.x = x;
            v.y = y;
        }
    }
}
