using PolygonEditor.Model;
using PolygonEditor.State;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolygonEditor.Drawing
{
    public enum DrawingType
    {
        Library,
        Bresenham,
    }
    public class BoardDrawer
    {
        private DrawingType? currentDrawingType = null;
        private PictureBox canvas;
        private Bitmap drawingArea;

        public Drawer singleElementDrawer;
        public BoardState state;

        public BoardDrawer(PictureBox canvas, BoardState state, DrawingType type)
        {
            this.canvas = canvas;
            this.state = state;
            this.drawingArea = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = drawingArea;

            ChangeDrawingType(type);
        }

        public void ChangeDrawingType(DrawingType type)
        {
            if (type != currentDrawingType)
            {
                changeDrawingType(type);
            }

            Refresh();
        }
        public void Refresh()
        {
            clear();
            DrawBoard();
        }

        public void DrawBoard()
        {
            foreach (Polygon p in state.polygons)
            {
                singleElementDrawer.DrawPolygon(p);
            }
            canvas.Refresh();
        }

        public void DrawWIPPolygon(List<Edge> edges)
        {
            foreach(Edge e in edges)
            {
                singleElementDrawer.DrawEdge(e);
            }

            canvas.Refresh();
        }

        private void clear()
        {
            using (Graphics g = Graphics.FromImage(drawingArea))
            {
                g.Clear(Color.White);
            }
        }

        private void changeDrawingType(DrawingType type)
        {
            if (type == DrawingType.Library)
            {
                this.singleElementDrawer = new Drawer(drawingArea);
            }
            else
            {
                this.singleElementDrawer = new BresenhamDrawer(drawingArea);
            }
        }


    }
}
