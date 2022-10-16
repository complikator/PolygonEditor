﻿using PolygonEditor.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.Drawing
{
    public class Drawer
    {
        public int vertexRadius = 3;
        protected Bitmap drawingArea;
        protected Brush defaultBrush = Brushes.Black;
        protected Pen defaultPen = new Pen(Color.Black, 1);

        public Drawer(Bitmap drawingArea)
        {
            this.drawingArea = drawingArea;
        }

        #region public members

        public void DrawEdge(Edge edge)
        {
            drawLine(edge);

            drawVertex(edge.beginning);
            drawVertex(edge.end);
        }

        public void DrawPolygon(Polygon polygon)
        {
            foreach(Edge e in polygon.Edges)
            {
                DrawEdge(e);
            }
        }

        #endregion

        #region private members

        private void drawLine(Edge edge)
        {
            using (Graphics g = Graphics.FromImage(drawingArea))
            {
                g.DrawLine(defaultPen, edge.beginning.x, edge.beginning.y, edge.end.x, edge.end.y);
            }
        }

        private void drawVertex(Vertex vertex)
        {
            using (Graphics g = Graphics.FromImage(drawingArea))
            {
                g.FillEllipse(defaultBrush, vertex.x - vertexRadius, vertex.y - vertexRadius, vertexRadius * 2, vertexRadius * 2);
            }
        }

        #endregion
    }

}