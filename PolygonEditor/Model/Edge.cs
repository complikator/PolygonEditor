using PolygonEditor.Model.Constraints;
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
        public Constraint Constraint;

        public Edge(Vertex beginning, Vertex end)
        {
            this.beginning = beginning;
            this.end = end;
        }

        public Edge(Vertex beginning, Vertex end, Constraint constraint) : this(beginning, end)
        {
            if (constraint is null)
            {
                throw new ArgumentNullException("Constraint was null");
            }

            Constraint = constraint;
        }
    }
}
