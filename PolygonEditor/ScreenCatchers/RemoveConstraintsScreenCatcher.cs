using PolygonEditor.Drawing;
using PolygonEditor.Helpers;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;

namespace PolygonEditor.ScreenCatchers
{
    internal class RemoveConstraintsScreenCatcher : BaseScreenCatcher
    {
        public RemoveConstraintsScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {

        }

        public override void LeftMouseDown(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (found.nearest != null)
            {
                if (found.nearest.Constraint != null)
                {
                    found.nearest.Constraint.Remove();
                }
            }

            drawer.Refresh();
        }
    }
}
