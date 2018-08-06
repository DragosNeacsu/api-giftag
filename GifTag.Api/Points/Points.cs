using System.Drawing;

namespace GifTag.Api.Points
{
    public abstract class Points
    {
        public abstract PointF AirlineLogo { get; }
        public abstract PointF AirlineName { get; set; }
        public abstract PointF FirstName { get; }
        public abstract PointF LastName { get; }
        public abstract PointF FromName { get; }
        public abstract PointF FromCode { get; }
        public abstract PointF ToName { get; }
        public abstract PointF ToCode { get; }
        public abstract PointF FlightDate { get; set; }
        public abstract PointF BoardingTime { get; set; }
        public abstract PointF FlightNumber { get; set; }
        public abstract PointF Gate { get; set; }
        public abstract PointF Seat { get; set; }
        public abstract PointF Class { get; set; }
    }
}
