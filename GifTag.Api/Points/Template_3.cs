using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_3 : Points
    {
        public override PointF? AirlineLogo => new PointF(70, 70);
        public override PointF? FirstName => new PointF(500f, 10f);
        public override PointF? LastName => new PointF(500f, 50f);
        public override PointF? FromName => new PointF(500f, 100f);
        public override PointF? ToName => new PointF(500f, 150f);
        public override PointF? FromCode => null;
        public override PointF? ToCode => null;
        public override PointF? FlightDate => null;
        public override PointF? FlightTime => null;
        public override PointF? BoardingTime => null;
        public override PointF? FlightNumber => null;
        public override PointF? Gate => null;
        public override PointF? Seat => null;
        public override PointF? Class => null;
        public override PointF? Name => null;

        #region Right
        public override PointF? Side_Seat => null;
        public override PointF? Side_Class => null;
        public override PointF? Side_FromName => null;
        public override PointF? Side_ToName => null;
        public override PointF? Side_Name => null;
        public override PointF? Side_FlightDate => null;
        public override PointF? Side_FlightTime => null;
        public override PointF? Side_AirlineLogo => null;
        public override PointF? Side_FirstName => null;
        public override PointF? Side_LastName => null;
        public override PointF? Side_FromCode => null;
        public override PointF? Side_ToCode => null;
        public override PointF? Side_BoardingTime => null;
        public override PointF? Side_FlightNumber => null;
        public override PointF? Side_Gate => null;
        #endregion
    }
}
