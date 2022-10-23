using PolygonEditor.Model;
using System;
using System.Drawing;

namespace PolygonEditor.Drawing
{

    public class BresenhamDrawer : Drawer
    {
        public BresenhamDrawer(Bitmap drawingArea) : base(drawingArea)
        {

        }

        private void drawLine(Edge edge)
        {
            bresenhamLine(edge.beginning.x, edge.beginning.y, edge.end.x, edge.end.y, new Pen(Color.Red, 2));
        }

        private void bresenhamLine(int x, int y, int x2, int y2, Pen pen)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                putPixel(x, y, pen);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        private void putPixel(int x, int y, Pen pen)
        {
            using (Graphics g = Graphics.FromImage(drawingArea))
            {
                g.DrawRectangle(pen, x, y, 1, 1);
            }
        }
    }
}
