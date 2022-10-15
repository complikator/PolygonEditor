using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.ScreenCatchers
{
    internal interface BaseScreenCatcher
    {
        void LeftMouseDown(int x, int y);

        void LeftMouseUp(int x, int y);

        void RightMouseDown(int x, int y);

        void RightMouseUp(int x, int y);

        void MouseMove(int x, int y);
    }
}
