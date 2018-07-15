using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_1 : Points
    {
        public override PointF FirstName => new PointF(500f, 10f);
        public override PointF LastName => new PointF(500f, 50f);
        public override PointF FromName => new PointF(500f, 100f);
        public override PointF ToName => new PointF(500f, 150f);
    }
}
