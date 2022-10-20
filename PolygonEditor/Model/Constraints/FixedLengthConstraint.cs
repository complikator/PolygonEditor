using PolygonEditor.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Model.Constraints
{
    public class FixedLengthConstraint : Constraint
    {
        public double DesiredLength;
        public Edge Edge;

        public override bool IsFulfilled
        {
            get
            {
                return Geometry.GetEdgeLength(Edge).EqualsWithEpsilon(DesiredLength, 3);
            }
        }

        public FixedLengthConstraint(Edge edge)
        {
            DesiredLength = Geometry.GetEdgeLength(edge);
            Edge = edge;
        }

        public override void Enforce(Vertex pattern = null)
        {
            Vertex vertexToChange = Edge.end;

            if (pattern == null)
            {
                pattern = Edge.beginning;
            }
            else if (pattern == Edge.end)
            {
                vertexToChange = Edge.beginning;
            }

            double x1 = pattern.x;
            double y1 = pattern.y;
            double x2 = vertexToChange.x;
            double y2 = vertexToChange.y;

            Console.WriteLine($"Length before fix: {Geometry.GetEdgeLength(Edge)}, pattern: ({pattern.x}, {pattern.y})");

            vertexToChange.x = (int)(x1 + (DesiredLength * (x2 - x1) / Geometry.GetEdgeLength(Edge)));
            vertexToChange.y = (int)(y1 + (DesiredLength * (y2 - y1) / Geometry.GetEdgeLength(Edge)));

            Console.WriteLine($"fixed length: {DesiredLength} <> {Geometry.GetEdgeLength(Edge)}");
        }
    }
}
