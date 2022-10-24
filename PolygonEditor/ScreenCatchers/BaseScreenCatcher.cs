using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;

namespace PolygonEditor.ScreenCatchers
{
    public abstract class BaseScreenCatcher
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

        public virtual void LeftMouseDown(int x, int y) { }

        public virtual void LeftMouseUp(int x, int y) { }

        public virtual void RightMouseDown(int x, int y) { }

        public virtual void RightMouseUp(int x, int y) { }

        public virtual void MouseMove(int x, int y) { }

        public virtual void Destroy() { }
    }
}
