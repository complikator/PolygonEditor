using PolygonEditor.Creation;
using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
using PolygonEditor.ScreenCatchers;
using PolygonEditor.State;
using System.Windows.Forms;

namespace PolygonEditor
{
    public enum Mode
    {
        AddPolygon,
        AddRemoveVertex,
        MoveElements,
        MovePolygon,
        AddConstraints,
        RemoveConstraints,
        RemovePolygon,
    }

    internal class Manager
    {
        private Mode currentMode;
        private DrawingType currentDrawingType;
        private PictureBox canvas;

        public BoardDrawer drawer;
        public BaseScreenCatcher screenCatcher;
        public BoardState state = new BoardState();
        public ConstraintController constraintController;

        public Manager(PictureBox canvas)
        {
            this.canvas = canvas;
            drawer = new BoardDrawer(canvas, state, DrawingType.Library);

            constraintController = new ConstraintController(state);            

            screenCatcher = new AddPolygonScreenCatcher(state, drawer, constraintController);

            initDemo();
        }

        private void initDemo()
        {
            var builder = new PolygonBuilder();

            builder.addVertex(100, 100);
            builder.addVertex(200, 100);
            builder.addVertex(200, 200);
            builder.addVertex(100, 200);

            var firstPolygon = builder.build();

            builder = new PolygonBuilder();

            builder.addVertex(300, 300);
            builder.addVertex(400, 500);
            builder.addVertex(500, 600);
            builder.addVertex(600, 300);

            var secondPolygon = builder.build();

            state.polygons.Add(firstPolygon);
            state.polygons.Add(secondPolygon);

            constraintController.TryAddFixedLengthConstraint(secondPolygon.Edges[0]);
            constraintController.TryAddFixedLengthConstraint(secondPolygon.Edges[1]);

            constraintController.TryAddPerpendicularConstaint(firstPolygon.Edges[0], firstPolygon.Edges[1]);
            constraintController.TryAddPerpendicularConstaint(firstPolygon.Edges[2], firstPolygon.Edges[3]);

            drawer.Refresh();
        }

        public void ChangeMode(Mode mode)
        {
            if (mode == currentMode)
            {
                return;
            }

            changeMode(mode);

            drawer.Refresh();
        }

        public void ReinstallBoard()
        {
            drawer = new BoardDrawer(canvas, state, currentDrawingType);

            screenCatcher.drawer = drawer;
            drawer.Refresh();
        }

        public void ChangeDrawingType(DrawingType type)
        {
            drawer.ChangeDrawingType(type);
        }

        private void changeMode(Mode mode)
        {
            changeScreenCatcher(mode);
            
            currentMode = mode;
        }

        private void changeScreenCatcher(Mode mode)
        {
            if (mode == Mode.AddPolygon)
            {
                screenCatcher = new AddPolygonScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.AddRemoveVertex)
            {
                screenCatcher = new AddRemoveVertexScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.MoveElements)
            {
                screenCatcher = new MoveElementsScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.MovePolygon)
            {
                screenCatcher = new MovePolygonScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.AddConstraints)
            {
                screenCatcher = new AddConstraintsScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.RemoveConstraints)
            {
                screenCatcher = new RemoveConstraintsScreenCatcher(state, drawer, constraintController);
            }
            else if (mode == Mode.RemovePolygon)
            {
                screenCatcher = new RemovePolygonScreenCatcher(state, drawer, constraintController);
            }
        }
    }
}
