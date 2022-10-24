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

        protected override void drawLine(Edge edge)
        {
            Console.WriteLine("bresenham line");
            bresenhamLine(edge.beginning.x, edge.beginning.y, edge.end.x, edge.end.y, defaultBrush);
        }

        private void bresenhamLine(int x1, int y1, int x2, int y2, Brush brush)
        {
            // zmienne pomocnicze
            int d, dx, dy, ai, bi, xi, yi;
            int x = x1, y = y1;
            // ustalenie kierunku rysowania
            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }
            // ustalenie kierunku rysowania
            if (y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }
            // pierwszy piksel
            putPixel(x, y, brush);
            // oś wiodąca OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // pętla po kolejnych x
                while (x != x2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    putPixel(x, y, brush);
                }
            }
            // oś wiodąca OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // pętla po kolejnych y
                while (y != y2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    putPixel(x, y, brush);
                }
            }
        }

        private void putPixel(int x, int y, Brush brush)
        {
            Console.WriteLine($"drawing point: {x}, {y}");
            using (Graphics g = Graphics.FromImage(drawingArea))
            {
                g.FillRectangle(brush, x, y, 1, 1);
            }
        }
    }
}
