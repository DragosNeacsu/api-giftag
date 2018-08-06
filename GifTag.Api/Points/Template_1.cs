using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_1 : Points
    {
        public override PointF? AirlineLogo => new PointF(536, 48);
        public override PointF? Name => new PointF(112, 236);
        public override PointF? FirstName => null;
        public override PointF? LastName => null;
        public override PointF? FromName => new PointF(112, 500);
        public override PointF? ToName => new PointF(740, 500);
        public override PointF? FlightDate => new PointF(440, 360);
        public override PointF? FlightTime => new PointF(740, 360);
        public override PointF? FlightNumber => new PointF(112, 360);
        public override PointF? Seat => new PointF(1180, 360);
        public override PointF? Class => new PointF(1032, 360);
        public override PointF? BoardingTime => new PointF(440, 660);
        public override PointF? Gate => null;

        #region Right
        public override PointF? Side_Name => new PointF(1533, 314);
        public override PointF? Side_Seat => new PointF(1680, 172);
        public override PointF? Side_Class => new PointF(1544, 172);
        public override PointF? Side_FromName => new PointF(1716, 464);
        public override PointF? Side_ToName => new PointF(1716, 492);
        public override PointF? Side_FlightDate => new PointF(1533, 584);
        public override PointF? Side_FlightTime => new PointF(1720, 584);
        #endregion
    }
}
