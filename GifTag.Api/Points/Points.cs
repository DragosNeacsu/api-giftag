using System.Drawing;

namespace GifTag.Api.Points
{
    public abstract class Points
    {
        public abstract PointF AirlineLogo { get; }
        public abstract PointF FirstName { get; }
        public abstract PointF LastName { get; }
        public abstract PointF FromName { get; }
        public abstract PointF ToName { get; }
        public abstract PointF FlightDate { get; }
        public abstract PointF BoardingTime { get; }
        public abstract PointF FlightNumber { get; }
        public abstract PointF Gate { get; }
        public abstract PointF Seat { get; }
        public abstract PointF Class { get; }
    }
}
