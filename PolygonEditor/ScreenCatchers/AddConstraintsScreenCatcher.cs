using PolygonEditor.Drawing;
using PolygonEditor.Helpers;
using PolygonEditor.Model;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.ScreenCatchers
{
    internal class AddConstraintsScreenCatcher : BaseScreenCatcher
    {
        private Edge first;
        private Edge second;

        public AddConstraintsScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {

        }

        public override void Destroy()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
        {

        }

        public override void LeftMouseUp(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (first == null)
            {
                if (found.nearest.Constraint != null)
                {
                    throw new Exception("This edge already has constraint!");
                }

                first = found.nearest;
            }
            else if (found.nearest != first)
            {
                if (found.nearest.Constraint != null)
                {
                    throw new Exception("This edge already has constraint!");
                }

                second = found.nearest;

                bool result = constraintController.TryAddPerpendicularConstaint(first, second);

                drawer.Refresh();

                if (result)
                {
                    first = null;
                    second = null;
                }
                else
                {
                    first = null;
                    second = null;

                    throw new Exception("Could not apply Perpendicular Edges Constraint");
                }
            }
        }

        public override void MouseMove(int x, int y)
        {

        }

        public override void RightMouseDown(int x, int y)
        {

        }

        public override void RightMouseUp(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            if (found.nearest.Constraint != null)
            {
                throw new Exception("This edge already has constraint!");
            }

            bool result = constraintController.TryAddFixedLengthConstraint(found.nearest);

            drawer.Refresh();

            if (!result)
            {
                throw new Exception("Could not apply Fixed Length Constraint");
            }
        }
    }
}
