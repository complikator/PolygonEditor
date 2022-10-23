namespace PolygonEditor.Model.Constraints
{
    public abstract class Constraint
    {
        public abstract bool IsFulfilled { get; }

        /// <summary>
        /// Changes edge coordinates to enforce constraint
        /// </summary>
        /// <param name="pattern">this vertex won't be changed during enforcement</param>
        public abstract void Enforce(Vertex pattern = null);

        public abstract void Remove();
    }
}
