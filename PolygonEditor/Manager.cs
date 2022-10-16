using PolygonEditor.Drawing;
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
    }

    internal class Manager
    {
        private Mode currentMode;
        private DrawingType currentDrawingType;
        private PictureBox canvas;

        public BoardDrawer drawer;
        public BaseScreenCatcher screenCatcher;
        public BoardState state = new BoardState();

        public Manager(PictureBox canvas)
        {
            this.canvas = canvas;
            drawer = new BoardDrawer(canvas, state, DrawingType.Library);
            screenCatcher = new AddPolygonScreenCatcher(state, drawer);
        }

        public void ChangeMode(Mode mode)
        {
            if (mode == currentMode)
            {
                return;
            }

            changeMode(mode);
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
                screenCatcher = new AddPolygonScreenCatcher(state, drawer);
            }
            else if (mode == Mode.AddRemoveVertex)
            {
                screenCatcher = new AddRemoveVertexScreenCatcher(state, drawer);
            }
            else if (mode == Mode.MoveElements)
            {
                screenCatcher = new MoveScreenCatcher(state, drawer);
            }
            else if (mode == Mode.MovePolygon)
            {
                screenCatcher = new MovePolygonScreenCatcher(state, drawer);
            }
        }
    }
}
