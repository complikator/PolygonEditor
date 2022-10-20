using PolygonEditor.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Model.Constraints
{
    public class PerpendicularConstraint : Constraint
    {
        public Edge first;
        public Edge second;

        public override bool IsFulfilled
        {
            get
            {
                double firstRate = Geometry.GetEdgeRate(first);
                double secondRate = Geometry.GetEdgeRate(second);


                if (firstRate.EqualsWithEpsilon(0))
                {
                    return secondRate.EqualsWithEpsilon(double.MaxValue);
                }
                else if (secondRate.EqualsWithEpsilon(0))
                {
                    return firstRate.EqualsWithEpsilon(double.MaxValue);
                }
                else
                {
                    return (firstRate * secondRate).EqualsWithEpsilon(-1);
                }
            }
        }

        public PerpendicularConstraint(Edge first, Edge second)
        {
            this.first = first;
            this.second = second;
        }

        public override void Enforce(Vertex pattern = null)
        {
            Edge containingEdge;
            Edge patternEdge;
            if (pattern != null)
            {
                if (first.beginning == pattern || first.end == pattern)
                {
                    containingEdge = first;
                    patternEdge = second;
                }
                else
                {
                    containingEdge = second;
                    patternEdge = first;
                }
            }
            else
            {
                containingEdge = first;
                patternEdge = second;
                pattern = containingEdge.beginning;
            }


            Console.WriteLine($"firstRate: {Geometry.GetEdgeRate(containingEdge)}, secondRate: {Geometry.GetEdgeRate(patternEdge)}");

            double x1 = containingEdge.beginning.x;
            double y1 = containingEdge.beginning.y;
            double x2 = containingEdge.end.x;
            double y2 = containingEdge.end.y;

            double patternRate = Geometry.GetEdgeRate(patternEdge);

            Vertex vertexToChange = pattern == containingEdge.beginning ? containingEdge.end : containingEdge.beginning;

            if (patternRate.EqualsWithEpsilon(0))
            {
                vertexToChange.x = pattern.x;
            }
            else if (patternRate.EqualsWithEpsilon(double.MaxValue))
            {
                vertexToChange.y = pattern.y;
            }
            else
            {
                double desiredRate = -1 / patternRate;

                double b = pattern.y - desiredRate * pattern.x;
                double b1 = vertexToChange.y - patternRate * vertexToChange.x;

                double xNew = (b - b1) / (patternRate - desiredRate);
                double yNew = patternRate * xNew + b1;

                vertexToChange.x = (int)xNew;
                vertexToChange.y = (int)yNew;
            }

            Console.WriteLine($"AFTER FIX: firstRate: {Geometry.GetEdgeRate(containingEdge)}, secondRate: {Geometry.GetEdgeRate(patternEdge)}");
        }


    }
}
