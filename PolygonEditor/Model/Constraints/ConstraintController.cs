using PolygonEditor.Drawing;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool TryAddPerpendicularConstaint(Edge first, Edge second, BoardDrawer drawer)
        {
            state.MakeSnapshot();

            PerpendicularConstraint constraint = new PerpendicularConstraint(first, second);

            first.Constraint = constraint;
            second.Constraint = constraint;

            bool adjustResult = tryApplyConstraints(drawer, null);

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

        public bool TryAddFixedLengthConstraint(Edge edge, BoardDrawer drawer)
        {
            state.MakeSnapshot();

            FixedLengthConstraint fixedLength = new FixedLengthConstraint(edge);
            edge.Constraint = fixedLength;

            bool adjustResult = tryApplyConstraints(drawer, null);

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
            state.MakeSnapshot():

            Console.WriteLine($"Trying to move vertex from: ({vertex.x}, {vertex.y}) to ({x}, {y})");

            vertex.x = x;
            vertex.y = y;

            bool adjustResult = tryApplyConstraints(null, vertex);

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

        private bool tryApplyConstraints(BoardDrawer drawer, Vertex pattern)
        {
            for (int i = 0; i < ConstraintController.MAX_ITERATIONS; i++)
            {
                bool isGood = true;
                foreach (Polygon p in state.polygons)
                {
                    Edge temp = p.Edges.Find(e => e.beginning == pattern);
                    int currentEdgeIndex = p.Edges.IndexOf(temp ?? p.Edges[0]);
                    for (int j = 0; j < p.Edges.Count; j++)
                    {
                        Edge e = p.Edges[(currentEdgeIndex + j) % p.Edges.Count];
                        if (e.Constraint == null)
                        {
                            continue;
                        }
                        Console.WriteLine("Controller checking constraint...");
                        if (e.Constraint.IsFulfilled == false)
                        {
                            Console.WriteLine("Controller trying to fix constraint");
                            //if (new List<Vertex>() { e.beginning, e.end }.Contains(pattern))
                            //{
                            //    e.Constraint.Enforce(pattern);
                            //}else
                            //{
                            //    e.Constraint.Enforce();
                            //}

                            e.Constraint.Enforce(e.beginning);

                            isGood = false;
                        }
                    }
                }

                if (drawer != null)
                {
                    drawer.Refresh();
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
