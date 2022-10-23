using PolygonEditor.Drawing;
using PolygonEditor.Model.Constraints;
using PolygonEditor.ScreenCatchers;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
