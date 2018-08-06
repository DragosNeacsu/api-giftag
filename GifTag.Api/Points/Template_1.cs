using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_1 : Points
    {
        public override PointF AirlineLogo => new PointF(70, 70);
        public override PointF FirstName => new PointF(500f, 10f);
        public override PointF LastName => new PointF(500f, 50f);
        public override PointF FromName => new PointF(500f, 100f);
        public override PointF ToName => new PointF(500f, 150f);

        public override PointF AirlineName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override PointF FromCode => throw new System.NotImplementedException();

        public override PointF ToCode => throw new System.NotImplementedException();

        public override PointF FlightDate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PointF BoardingTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PointF FlightNumber { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PointF Gate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PointF Seat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PointF Class { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
