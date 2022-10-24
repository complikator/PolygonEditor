using PolygonEditor.Creation;
using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;

namespace PolygonEditor.ScreenCatchers
{
    internal class AddPolygonScreenCatcher : BaseScreenCatcher
    {
        private bool buildingInProgress = false;
        private PolygonBuilder builder;

        public AddPolygonScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {
        }

        public override void LeftMouseUp(int x, int y)
        {
            if (!buildingInProgress)
            {
                buildingInProgress = true;
                builder = new PolygonBuilder();
            }

            builder.addVertex(x, y);

            drawer.DrawWIPPolygon(builder.GetCurrentEdgesCopy());
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
