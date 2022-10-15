using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Model
{
    public class Edge
    {
        public Vertex beginning;
        public Vertex end;

        public Edge(Vertex beginning, Vertex end)
        {
            this.beginning = beginning;
            this.end = end;
        }
    }
}
