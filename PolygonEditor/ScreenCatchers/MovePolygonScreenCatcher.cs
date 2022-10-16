﻿using PolygonEditor.Drawing;
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
    internal class MovePolygonScreenCatcher : BaseScreenCatcher
    {
        private BoardState state;
        private BoardDrawer drawer;

        private bool isPolygonMoving = false;
        private Polygon currentPolygon;

        List<(int x, int y)> startVerticesPositions = new List<(int x, int y)>();
        private (int x, int y) startMousePosition;

        public MovePolygonScreenCatcher(BoardState state, BoardDrawer drawer)
        {
            this.state = state;
            this.drawer = drawer;
        }

        public void LeftMouseDown(int x, int y)
        {
            var found = ScreenToElementFinder.FindNearestPolygon(state, x, y);

            if (found == null)
            {
                return;
            }

            isPolygonMoving = true;
            startMousePosition = (x, y);
            currentPolygon = found;

            foreach (Vertex v in currentPolygon.Vertices)
            {
                startVerticesPositions.Add((v.x, v.y));
            }
        }

        public void LeftMouseUp(int x, int y)
        {
            currentPolygon = null;
            isPolygonMoving = false;

            startVerticesPositions = new List<(int x, int y)>();
        }

        public void MouseMove(int x, int y)
        {
            if (isPolygonMoving)
            {
                int xDist = x - startMousePosition.x;
                int yDist = y - startMousePosition.y;

                for (int i = 0; i < currentPolygon.Vertices.Count; i++)
                {
                    currentPolygon.MoveVertex(currentPolygon.Vertices[i],
                        startVerticesPositions[i].x + (x - startMousePosition.x),
                        startVerticesPositions[i].y + (y - startMousePosition.y));
                }
            }

            drawer.Refresh();
        }

        public void RightMouseDown(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void RightMouseUp(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}