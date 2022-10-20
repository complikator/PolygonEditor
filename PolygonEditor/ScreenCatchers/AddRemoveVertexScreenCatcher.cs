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
    internal class AddRemoveVertexScreenCatcher : BaseScreenCatcher
    {
        public AddRemoveVertexScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {
        }

        public override void Destroy()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
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

        public override void MouseMove(int x, int y)
        {

        }

        public override void RightMouseDown(int x, int y)
        {

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
