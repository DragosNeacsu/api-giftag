using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_2 : Points
    {
        public override PointF? AirlineLogo => new PointF(68, 68);
        public override PointF? Name => new PointF(68, 164);
        public override PointF? FirstName => null;
        public override PointF? LastName => null;
        public override PointF? FromName => null;
        public override PointF? ToName => null;
        public override PointF? FromCode => new PointF(676, 100);
        public override PointF? ToCode => new PointF(848, 100);
        public override PointF? FlightDate => new PointF(676, 164);
        public override PointF? FlightTime => new PointF(368, 548);
        public override PointF? BoardingTime => null;
        public override PointF? FlightNumber => new PointF(68, 548);
        public override PointF? Gate => new PointF(996, 548);
        public override PointF? Seat => new PointF(1268, 548);
        public override PointF? Class => null;

        #region Right
        public override PointF? Side_Seat => new PointF(1632, 269);
        public override PointF? Side_Class => null;
        public override PointF? Side_FromName => null;
        public override PointF? Side_ToName => null;
        public override PointF? Side_Name => new PointF(1508, 168);
        public override PointF? Side_FlightDate => null;
        public override PointF? Side_FlightTime => new PointF(1632, 338);
        public override PointF? Side_AirlineLogo => null;
        public override PointF? Side_FirstName => null;
        public override PointF? Side_LastName => null;
        public override PointF? Side_FromCode => null;
        public override PointF? Side_ToCode => null;
        public override PointF? Side_BoardingTime => null;
        public override PointF? Side_FlightNumber => new PointF(1632, 516);
        public override PointF? Side_Gate => null;
        #endregion
    }
}
