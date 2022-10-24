using PolygonEditor.Drawing;
using PolygonEditor.State;
using System;
using PolygonEditor.Helpers;
using PolygonEditor.Model;
using PolygonEditor.Model.Constraints;

namespace PolygonEditor.ScreenCatchers
{
    internal class MoveElementsScreenCatcher : BaseScreenCatcher
    {
        private bool isVertexMoving = false;
        private bool isEdgeMoving = false;

        private (Vertex v, Polygon polygon) currentVertex;
        private (Edge e, Polygon polygon) currentEdge;

        private (int x, int y) startVertexPosition;
        private ((int x, int y) beginning, (int x, int y) end) startEdgePosition;

        private (int x, int y) startMousePosition;

        public MoveElementsScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {

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
                int newX = startVertexPosition.x + (x - startMousePosition.x);
                int newY = startVertexPosition.y + (y - startMousePosition.y);
                //if (moveElementValidator.isPossibleToMoveVertex(currentVertex.v, x, y))
                //{
                //    int newX = startVertexPosition.x + (x - startMousePosition.x);
                //    int newY = startVertexPosition.y + (y - startMousePosition.y);
                //    currentVertex.polygon.MoveVertex(currentVertex.v, newX, newY);
                //}

                constraintController.TryMoveVertex(currentVertex.v, newX, newY);

            }
            else if (isEdgeMoving)
            {
                (int x, int y) newBeginning = (startEdgePosition.beginning.x + (x - startMousePosition.x),
                        startEdgePosition.beginning.y + (y - startMousePosition.y));
                (int x, int y) newEnd = (startEdgePosition.end.x + (x - startMousePosition.x),
                    startEdgePosition.end.y + (y - startMousePosition.y));

                //if (moveElementValidator.isPossibleToMoveEdge(currentEdge.e, x - startMousePosition.x, y - startMousePosition.y))
                //{

                //    currentEdge.polygon.MoveVertex(currentEdge.e.beginning, newBeginning.x, newBeginning.y);
                //    currentEdge.polygon.MoveVertex(currentEdge.e.end, newEnd.x, newEnd.y);
                //}

                //constraintController.TryMoveVertex(currentEdge.e.beginning, newBeginning.x, newBeginning.y);
                //constraintController.TryMoveVertex(currentEdge.e.end, newEnd.x, newEnd.y);

                int relativeX = x - startMousePosition.x;
                int relativeY = y - startMousePosition.y;

                startMousePosition = (x, y);

                constraintController.TryMoveEdge(currentEdge.e, relativeX, relativeY);
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
