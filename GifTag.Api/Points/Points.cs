using System.Drawing;

namespace GifTag.Api.Points
{
    public abstract class Points
    {
        public abstract PointF? AirlineLogo { get; }
        public abstract PointF? FirstName { get; }
        public abstract PointF? LastName { get; }
        public abstract PointF? Name { get; }
        public abstract PointF? FromName { get; }
        public abstract PointF? ToName { get; }
        public abstract PointF? FromCode { get; }
        public abstract PointF? ToCode { get; }
        public abstract PointF? FlightDate { get; }
        public abstract PointF? FlightTime { get; }
        public abstract PointF? BoardingTime { get; }
        public abstract PointF? FlightNumber { get; }
        public abstract PointF? Gate { get; }
        public abstract PointF? Seat { get; }
        public abstract PointF? Class { get; }

        #region Right
        public abstract PointF? Side_AirlineLogo { get; }
        public abstract PointF? Side_FirstName { get; }
        public abstract PointF? Side_LastName { get; }
        public abstract PointF? Side_Name { get; }
        public abstract PointF? Side_FromName { get; }
        public abstract PointF? Side_ToName { get; }
        public abstract PointF? Side_FromCode { get; }
        public abstract PointF? Side_ToCode { get; }
        public abstract PointF? Side_FlightDate { get; }
        public abstract PointF? Side_FlightTime { get; }
        public abstract PointF? Side_BoardingTime { get; }
        public abstract PointF? Side_FlightNumber { get; }
        public abstract PointF? Side_Gate { get; }
        public abstract PointF? Side_Seat { get; }
        public abstract PointF? Side_Class { get; }
        #endregion
    }
}
