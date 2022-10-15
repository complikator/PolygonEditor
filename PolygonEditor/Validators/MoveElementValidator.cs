using PolygonEditor.Model;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Validators
{
    internal class MoveElementValidator
    {
        private BoardState state;

        public MoveElementValidator(BoardState state)
        {
            this.state = state;
        }

        public bool isPossibleToMoveVertex(Vertex v, int x, int y)
        {
            return true;
        }

        /// <summary>
        /// Checks if edge can be moved to new location which is described by 
        /// move vector with coordinates (x, y)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool isPossibleToMoveEdge(Edge e, int x, int y)
        {
            return true;
        }
    }
}
