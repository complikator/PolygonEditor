using PolygonEditor.Creation;
using PolygonEditor.Drawing;
using PolygonEditor.State;
using PolygonEditor.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.ScreenCatchers
{
    internal class AddPolygonScreenCatcher : BaseScreenCatcher
    {
        private BoardState state;
        private AddVertexValidator addVertexValidator;
        private bool buildingInProgress = false;
        private PolygonBuilder builder;
        private BoardDrawer drawer;

        public AddPolygonScreenCatcher(BoardState state, BoardDrawer drawer)
        {
            this.state = state;
            this.addVertexValidator = new AddVertexValidator(state);
            this.drawer = drawer;
        }
        public void LeftMouseDown(int x, int y)
        {
            
        }

        public void LeftMouseUp(int x, int y)
        {
            if (addVertexValidator.isPossibleToAddVertex(x,y))
            {
                if (!buildingInProgress)
                {
                    buildingInProgress = true;
                    builder = new PolygonBuilder();
                }

                builder.addVertex(x, y);

                drawer.DrawWIPPolygon(builder.GetCurrentEdgesCopy());
            }
        }

        public void MouseMove(int x, int y)
        {

        }

        public void RightMouseDown(int x, int y)
        {

        }

        public void RightMouseUp(int x, int y)
        {
            if (buildingInProgress && builder.canBuild())
            {
                state.polygons.Add(builder.build());
                buildingInProgress = false;

                drawer.DrawBoard();
            }
        }
    }
}
