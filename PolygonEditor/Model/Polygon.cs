﻿using System;
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
                Edge temp = new Edge(Vertices[Vertices.Count - 1], vertex);
                Edges.Add(temp);
                Vertices[Vertices.Count - 1].After = temp;
                vertex.Before = temp;
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

            Edge temp = new Edge(last, first);
            Edges.Add(temp);

            last.After = temp;
            first.Before = temp;

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
                Edges.Remove(Edges.Find(e => e.beginning == which));
                Edges.Remove(Edges.Find(e => e.end == which));

                Edge temp = new Edge(Vertices[Vertices.Count - 1], Vertices[0]);

                Edges.Add(temp);

                Vertices.RemoveAt(index);

                Vertices[0].Before = temp;
                Vertices[Vertices.Count - 1].After = temp;
            }
            else if (index == Vertices.Count - 1)
            {
                Edges.Remove(Edges.Find(e => e.beginning == which));
                Edges.Remove(Edges.Find(e => e.end == which));

                Edge temp = new Edge(Vertices[Vertices.Count - 2], Vertices[0]);

                Edges.Add(temp);

                Vertices.RemoveAt(index);

                Vertices[0].Before = temp;
                Vertices[Vertices.Count - 1].After = temp;
            }
            else
            {
                Edges.Remove(Edges.Find(e => e.beginning == which));
                Edges.Remove(Edges.Find(e => e.end == which));

                Edge temp = new Edge(Vertices[index - 1], Vertices[index + 1]);

                Edges.Add(temp);

                Vertices[index - 1].After = temp;
                Vertices[index + 1].Before = temp;

                Vertices.Remove(which);
            }
        }

        public void addMiddleVertex(Edge which)
        {
            Vertex v = new Vertex((which.beginning.x + which.end.x) / 2, (which.beginning.y + which.end.y) / 2);

            Edges.Remove(which);

            Edge tempBefore = new Edge(which.beginning, v);
            Edge tempAfter = new Edge(v, which.end);

            Edges.Add(tempBefore);
            Edges.Add(tempAfter);

            int index = Vertices.IndexOf(which.beginning);

            Vertices[index].After = tempBefore;
            Vertices[index + 1].Before = tempAfter;

            v.Before = tempBefore;
            v.After = tempAfter;

            Vertices.Insert(index + 1, v);
        }

        public void MoveVertex(Vertex v, int x, int y)
        {
            v.x = x;
            v.y = y;
        }
    }
}
