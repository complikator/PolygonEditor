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
    }

    internal class Manager
    {
        private Mode? currentMode = Mode.AddPolygon;

        public BoardDrawer drawer;
        public BaseScreenCatcher screenCatcher;
        public BoardState state = new BoardState();

        public Manager(PictureBox canvas)
        {
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
        }
    }
}
