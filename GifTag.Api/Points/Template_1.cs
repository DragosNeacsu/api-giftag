using System.Drawing;

namespace GifTag.Api.Points
{
    public class Template_1 : Points
    {
        public override PointF AirlineLogo => new PointF(536, 48);
        public override PointF FirstName => new PointF(112, 236);
        public override PointF LastName => new PointF(170, 236);
        public override PointF FromName => new PointF(112, 500);
        public override PointF ToName => new PointF(740, 500);
        public override PointF FlightDate => new PointF(440, 360);
        public override PointF FlightTime => new PointF(740, 360);
        public override PointF FlightNumber => new PointF(112, 360);
        public override PointF Seat => new PointF(1180, 360);
        public override PointF Class => new PointF(1032, 360);
        public override PointF Gate => throw new System.NotImplementedException();

        public override PointF BoardingTime => throw new System.NotImplementedException();
    }
}
//time 740 * 360

//in partea dreapta
//class 1544 * 172
//seat 1680 * 172
//first name 1533 * 314
//last name dupa first name
//from 1716 * 464
//Dc nu le pui u?
//nu merge sa editez pe github
//Si crezi ca-s virusate?
//to 1716 * 492
//da
//date 1533 * 584
//time 1720 * 584