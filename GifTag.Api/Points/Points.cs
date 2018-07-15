using System.Drawing;

namespace GifTag.Api.Points
{
    public abstract class Points
    {
        public abstract PointF FirstName { get; }
        public abstract PointF LastName { get; }
        public abstract PointF FromName { get; }
        public abstract PointF ToName { get; }
    }
}
