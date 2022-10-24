using PolygonEditor.Drawing;
using PolygonEditor.Helpers;
using PolygonEditor.Model;
using PolygonEditor.Model.Constraints;
using PolygonEditor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.ScreenCatchers
{
    public class RemovePolygonScreenCatcher : BaseScreenCatcher
    {
        public RemovePolygonScreenCatcher(BoardState state, BoardDrawer drawer, ConstraintController constraintController) : base(state, drawer, constraintController)
        {

        }

        public override void LeftMouseDown(int x, int y)
        {
            Polygon polygon = ScreenToElementFinder.FindNearestPolygon(state, x, y);

            if (polygon != null)
            {
                foreach (Edge edge in polygon.Edges)
                {
                    if (edge.Constraint != null)
                    {
                        edge.Constraint.Remove();
                    }
                }

                state.polygons.Remove(polygon);
            }
            else
            {
                throw new Exception("No polygon found");
            }

            drawer.Refresh();
        }
    }
}
