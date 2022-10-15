using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Validators
{
    internal class AddVertexValidator
    {
        private BoardState state;

        public AddVertexValidator(BoardState state)
        {
            this.state = state;
        }

        public bool isPossibleToAddVertex(int x, int y)
        {
            return true;
        }
    }
}
