using PolygonEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolygonEditor.Creation
{
    public class PolygonBuilder
    {
        private Polygon polygon = new Polygon();

        public void addVertex(int x, int y)
        {
            checkBuilderState();

            polygon.addVertex(new Vertex(x, y));
        }

        public bool canBuild()
        {
            checkBuilderState();

            return polygon.isPossibleToFinishPolygon();
        }

        public Polygon build()
        {
            checkBuilderState();

            polygon.FinishPolygon();
            return polygon;
        }

        public List<Edge> GetCurrentEdgesCopy()
        {
            return polygon.Edges.Select(e =>
            new Edge(new Vertex(e.beginning.x, e.beginning.y), new Vertex(e.end.x, e.end.y))).ToList();
        }

        private void checkBuilderState()
        {
            if (builderFinishedWork())
            {
                throw new InvalidOperationException("Builder finished work!");
            }
        }

        private bool builderFinishedWork()
        {
            return polygon.IsFinished;
        }
    }
}
