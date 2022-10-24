using PolygonEditor.Model;
using PolygonEditor.Model.Constraints;
using System.Drawing;

namespace PolygonEditor.Drawing
{
    public class Drawer
    {
        public int vertexRadius = 5;
        protected Bitmap drawingArea;
        protected Brush defaultBrush = Brushes.Black;
        protected Pen defaultPen = new Pen(Color.Black, 1);
        protected Font defaultFont = new Font("Arial", 12);
        protected Brush perpendicularBrush = Brushes.Red;
        protected Brush fixedLengthBrush = Brushes.Green;

        public Drawer(Bitmap drawingArea)
        {
            this.drawingArea = drawingArea;
        }

        #region public members

        public void DrawEdge(Edge edge)
        {
            drawLine(edge);

            drawEdgeConstraint(edge);

            drawVertex(edge.beginning);
            drawVertex(edge.end);
        }

        public void DrawPolygon(Polygon polygon)
        {
            foreach (Edge e in polygon.Edges)
            {
                DrawEdge(e);
            }
        }

        #endregion

        #region private members

        protected virtual void drawLine(Edge edge)
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

        private void drawEdgeConstraint(Edge edge)
        {
            if (edge.Constraint == null)
            {
                return;
            }

            int x = (edge.beginning.x + edge.end.x) / 2;
            int y = (edge.beginning.y + edge.end.y) / 2;

            if (edge.Constraint is PerpendicularConstraint)
            {
                using (Graphics g = Graphics.FromImage(drawingArea))
                {
                    g.DrawString(edge.Constraint.Id.ToString(), defaultFont, perpendicularBrush, x, y);
                }
            }

            if (edge.Constraint is FixedLengthConstraint)
            {
                using (Graphics g = Graphics.FromImage(drawingArea))
                {
                    g.FillEllipse(Brushes.Green, x, y, vertexRadius * 2, vertexRadius * 2);
                }
            }
        }

        #endregion
    }

}
