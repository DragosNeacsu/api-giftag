using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_3 : Points
    {
        public override PointF AirlineLogo => new PointF(70, 70);
        public override PointF FirstName => new PointF(500f, 10f);
        public override PointF LastName => new PointF(500f, 50f);
        public override PointF FromName => new PointF(500f, 100f);
        public override PointF ToName => new PointF(500f, 150f);

        public override PointF FlightDate => throw new System.NotImplementedException();

        public override PointF FlightTime => throw new System.NotImplementedException();

        public override PointF FlightNumber => throw new System.NotImplementedException();

        public override PointF Gate => throw new System.NotImplementedException();

        public override PointF Seat => throw new System.NotImplementedException();

        public override PointF Class => throw new System.NotImplementedException();

        public override PointF BoardingTime => throw new System.NotImplementedException();
    }
}
