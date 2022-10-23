using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;

namespace PolygonEditor.ScreenCatchers
{
    internal abstract class BaseScreenCatcher
    {
        public BoardState state;
        public BoardDrawer drawer;
        public ConstraintController constraintController;

        public BaseScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController)
        {
            this.state = state;
            this.drawer = drawer;
            this.constraintController = constraintController;
        }

        public abstract void LeftMouseDown(int x, int y);

        public abstract void LeftMouseUp(int x, int y);

        public abstract void RightMouseDown(int x, int y);

        public abstract void RightMouseUp(int x, int y);

        public abstract void MouseMove(int x, int y);

        public abstract void Destroy();
    }
}
