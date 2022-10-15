using PolygonEditor.Drawing;
using PolygonEditor.Helpers;
using PolygonEditor.Model;
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
        private BoardState state;
        private BoardDrawer drawer;

        public AddRemoveVertexScreenCatcher(BoardState state, BoardDrawer drawer)
        {
            this.state = state;
            this.drawer = drawer;
        }

        public void LeftMouseDown(int x, int y)
        {

        }

        /// <summary>
        /// Adds new vertex in the middle of existing edge
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void LeftMouseUp(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            found.polygon.addMiddleVertex(found.nearest);
            drawer.Refresh();
        }

        public void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void RightMouseDown(int x, int y)
        {

        }

        /// <summary>
        /// Removes existing vertex
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RightMouseUp(int x, int y)
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
