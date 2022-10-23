using System;

namespace PolygonEditor.Helpers
{
    public static class Extensions
    {
        public const double Epsilon = 0.02;
        public static bool EqualsWithEpsilon(this double value, double other, double epsilon = Epsilon)
        {
            return Math.Abs(value - other) < epsilon || Math.Abs(other - value) < epsilon;
        }
    }
}
