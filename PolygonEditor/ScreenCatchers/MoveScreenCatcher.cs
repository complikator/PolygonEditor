using PolygonEditor.Drawing;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PolygonEditor.Helpers;
using PolygonEditor.Validators;
using System.Threading.Tasks;
using PolygonEditor.Model;

namespace PolygonEditor.ScreenCatchers
{
    internal class MoveScreenCatcher : BaseScreenCatcher
    {
        private MoveElementValidator moveElementValidator;

        private bool isVertexMoving = false;
        private bool isEdgeMoving = false;

        private (Vertex v, Polygon polygon) currentVertex;
        private (Edge e, Polygon polygon) currentEdge;

        private (int x, int y) startVertexPosition;
        private ((int x, int y) beginning, (int x, int y) end) startEdgePosition;

        private (int x, int y) startMousePosition;

        public MoveScreenCatcher(BoardState state, BoardDrawer drawer) : base(state, drawer)
        {
            this.moveElementValidator = new MoveElementValidator(state);
        }
        /// <summary>
        /// Start moving vertex
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void LeftMouseDown(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestVertex(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            isVertexMoving = true;
            startVertexPosition = (found.nearest.x, found.nearest.y);
            startMousePosition = (x, y);
            currentVertex = found;
        }

        /// <summary>
        /// Finish moving vertex
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void LeftMouseUp(int x, int y)
        {
            currentVertex = (null, null);
            isVertexMoving = false;
        }

        public override void MouseMove(int x, int y)
        {
            if (isVertexMoving)
            {
                if (moveElementValidator.isPossibleToMoveVertex(currentVertex.v, x, y))
                {
                    int newX = startVertexPosition.x + (x - startMousePosition.x);
                    int newY = startVertexPosition.y + (y - startMousePosition.y);
                    currentVertex.polygon.MoveVertex(currentVertex.v, newX, newY);
                }
            }
            else if (isEdgeMoving)
            {
                if (moveElementValidator.isPossibleToMoveEdge(currentEdge.e, x - startMousePosition.x, y - startMousePosition.y))
                {
                    (int x, int y) newBeginning = (startEdgePosition.beginning.x + (x - startMousePosition.x),
                        startEdgePosition.beginning.y + (y - startMousePosition.y));
                    (int x, int y) newEnd = (startEdgePosition.end.x + (x - startMousePosition.x),
                        startEdgePosition.end.y + (y - startMousePosition.y));

                    currentEdge.polygon.MoveVertex(currentEdge.e.beginning, newBeginning.x, newBeginning.y);
                    currentEdge.polygon.MoveVertex(currentEdge.e.end, newEnd.x, newEnd.y);
                }
            }

            drawer.Refresh();
        }

        /// <summary>
        /// Start moving edge
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void RightMouseDown(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestEdge(state, x, y);

            if (found.nearest == null)
            {
                return;
            }

            isEdgeMoving = true;
            startEdgePosition = ((found.nearest.beginning.x, found.nearest.beginning.y), (found.nearest.end.x, found.nearest.end.y));
            startMousePosition = (x, y);
            currentEdge = found;
        }

        /// <summary>
        /// Finish moving edge
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void RightMouseUp(int x, int y)
        {
            currentEdge = (null, null);
            isEdgeMoving = false;
        }
    }
}
