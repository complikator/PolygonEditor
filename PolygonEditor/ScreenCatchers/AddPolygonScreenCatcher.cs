using PolygonEditor.Creation;
using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
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
        private AddVertexValidator addVertexValidator;
        private bool buildingInProgress = false;
        private PolygonBuilder builder;

        public AddPolygonScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {
            this.addVertexValidator = new AddVertexValidator(state);
        }

        public override void Destroy()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
        {
            
        }

        public override void LeftMouseUp(int x, int y)
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

        public override void MouseMove(int x, int y)
        {

        }

        public override void RightMouseDown(int x, int y)
        {

        }

        public override void RightMouseUp(int x, int y)
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
