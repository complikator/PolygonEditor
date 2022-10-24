using PolygonEditor.Drawing;
using PolygonEditor.Helpers;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;

namespace PolygonEditor.ScreenCatchers
{
    internal class AddRemoveVertexScreenCatcher : BaseScreenCatcher
    {
        public AddRemoveVertexScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {
        }

        /// <summary>
        /// Adds new vertex in the middle of existing edge
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void LeftMouseUp(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            found.polygon.addMiddleVertex(found.nearest);
            drawer.Refresh();
        }

        /// <summary>
        /// Removes existing vertex
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void RightMouseUp(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestVertex(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            found.polygon.removeVertex(found.nearest);
            drawer.Refresh();
        }
    }
}
