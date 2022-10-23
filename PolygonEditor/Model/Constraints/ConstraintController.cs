using PolygonEditor.State;
using System;

namespace PolygonEditor.Model.Constraints
{
    public class ConstraintController
    {
        private static int MAX_ITERATIONS = 100;

        public BoardState state;

        public ConstraintController(BoardState state)
        {
            this.state = state;
        }

        public bool TryAddPerpendicularConstaint(Edge first, Edge second)
        {
            state.MakeSnapshot();

            PerpendicularConstraint constraint = new PerpendicularConstraint(first, second);

            first.Constraint = constraint;
            second.Constraint = constraint;

            bool adjustResult = tryApplyConstraintsTwoSide(first.beginning, first.beginning);

            if (adjustResult)
            {
                return true;
            }
            else
            {
                state.RecreateFromLastSnapshot();
                return false;
            }
        }

        public bool TryAddFixedLengthConstraint(Edge edge)
        {
            state.MakeSnapshot();

            FixedLengthConstraint fixedLength = new FixedLengthConstraint(edge);
            edge.Constraint = fixedLength;

            bool adjustResult = tryApplyConstraintsTwoSide(edge.beginning, edge.beginning);

            if (adjustResult)
            {
                return true;
            }
            else
            {
                state.RecreateFromLastSnapshot();
                return false;
            }
        }
        
        public bool TryMoveVertex(Vertex vertex, int x, int y)
        {
            state.MakeSnapshot();

            Console.WriteLine($"Trying to move vertex from: ({vertex.x}, {vertex.y}) to ({x}, {y})");

            vertex.x = x;
            vertex.y = y;

            bool adjustResult = tryApplyConstraintsTwoSide(vertex, vertex);

            if (adjustResult)
            {
                Console.WriteLine("Moving vertex: SUCCESS");
                return true;
            }
            else
            {
                Console.WriteLine("Moving vertex: FAILURE");
                state.RecreateFromLastSnapshot();
                return false;
            }
        }

        public bool TryMoveEdge(Edge edge, int x, int y)
        {
            state.MakeSnapshot();

            edge.beginning.x += x;
            edge.beginning.y += y;

            edge.end.x += x;
            edge.end.y += y;

            bool adjustResult = tryApplyConstraintsTwoSide(edge.beginning, edge.end);

            if (adjustResult)
            {
                Console.WriteLine("Moving edge: SUCCESS");
                return true;
            }
            else
            {
                Console.WriteLine("Moving edge: FAILURE");
                state.RecreateFromLastSnapshot();
                return false;
            }
        }

        private bool tryApplyConstraintsTwoSide(Vertex leftStart, Vertex rightStart)
        {
            for (int i = 0; i < ConstraintController.MAX_ITERATIONS; i++)
            {
                bool isGood = true;

                foreach(Polygon polygon in state.polygons)
                {
                    Vertex left = polygon.Vertices[0];
                    Vertex right = left;
                    if (polygon.Vertices.Contains(leftStart))
                    {
                        left = leftStart;
                        right = rightStart;
                    }

                    while (true)
                    {
                        if (right.After.Constraint != null && right.After.Constraint.IsFulfilled == false)
                        {
                            right.After.Constraint.Enforce(right);
                            isGood = false;
                        }

                        right = right.After.end;


                        // check if vertices met
                        if (left == right)
                        {
                            break;
                        }

                        if (left.Before.Constraint != null && left.Before.Constraint.IsFulfilled == false)
                        {
                            left.Before.Constraint.Enforce(left);

                            isGood = false;
                        }

                        left = left.Before.beginning;

                        // check if vertices met
                        if (right == left)
                        {
                            break;
                        }
                    }
                }

                if (isGood)
                {
                    Console.WriteLine($"Fixing finished, iterations: {i}");
                    break;
                }
            }

            foreach (Polygon p in state.polygons)
            {
                foreach (Edge e in p.Edges)
                {
                    if (e.Constraint == null)
                    {
                        continue;
                    }

                    if (e.Constraint.IsFulfilled == false)
                    {
                        Console.WriteLine("FIXING FAILED");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
