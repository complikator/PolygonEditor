namespace PolygonEditor.Model
{
    public class Vertex
    {
        public int x;
        public int y;

        public Edge Before;
        public Edge After;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
