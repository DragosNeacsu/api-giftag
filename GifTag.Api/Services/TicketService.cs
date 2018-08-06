using GifTag.Api.Points;
using GifTag.Database;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

public class TicketService : ITicketService
{
    private readonly DataContext _context;
    public TicketService(DataContext context)
    {
        _context = context;
    }

    public string Generate(Ticket ticket)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "TicketTemplate", ticket.Template);
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template {ticket.Template} does not exist");
        }
        var points = PointFactory.Get(ticket.Template);
        Bitmap bitmap = (Bitmap)Image.FromFile(templatePath);

        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            using (Font arialFont = new Font("Arial", 16))
            {
                TryDrawingThePoint(graphics, GetFullName(ticket), arialFont, points.Name);
                TryDrawingThePoint(graphics, ticket.FirstName, arialFont, points.FirstName);
                TryDrawingThePoint(graphics, ticket.LastName, arialFont, points.LastName);
                TryDrawingThePoint(graphics, ticket.FromName, arialFont, points.FromName);
                TryDrawingThePoint(graphics, ticket.FlightTime, arialFont, points.FlightTime);
                TryDrawingThePoint(graphics, ticket.FlightDate, arialFont, points.FlightDate);
                TryDrawingThePoint(graphics, ticket.FlightNumber, arialFont, points.FlightNumber);
                TryDrawingThePoint(graphics, ticket.Gate, arialFont, points.Gate);
                TryDrawingThePoint(graphics, ticket.Seat, arialFont, points.Seat);
                TryDrawingThePoint(graphics, ticket.Class, arialFont, points.Class);
                TryDrawingThePoint(graphics, ticket.ToName, arialFont, points.ToName);
                TryDrawingThePoint(graphics, GetBoardingTime(ticket.FlightTime), arialFont, points.BoardingTime);

                TryDrawingThePoint(graphics, ticket.Class, arialFont, points.Side_Class);
                TryDrawingThePoint(graphics, ticket.FlightDate, arialFont, points.Side_FlightDate);
                TryDrawingThePoint(graphics, ticket.FlightTime, arialFont, points.Side_FlightTime);
                TryDrawingThePoint(graphics, ticket.FromName, arialFont, points.Side_FromName);
                TryDrawingThePoint(graphics, GetFullName(ticket), arialFont, points.Side_Name);
                TryDrawingThePoint(graphics, ticket.Seat, arialFont, points.Side_Seat);
                TryDrawingThePoint(graphics, ticket.ToName, arialFont, points.Side_ToName);
            }
        }

        if (points.AirlineLogo != null)
        {
            bitmap = AddAirlineLogo(bitmap, ticket, points.AirlineLogo.Value);
        }

        var fileName = $"{Guid.NewGuid()}.png";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", fileName);
        bitmap.Save(filePath, ImageFormat.Png);
        return fileName;
    }

    private string GetFullName(Ticket ticket) {
        return $"{ticket.FirstName} {ticket.LastName}";
    }
    private void TryDrawingThePoint(Graphics graphics, string field, Font arialFont, PointF? point)
    {
        if (point != null)
        {
            try
            {
                graphics.DrawString(field, arialFont, Brushes.Black, point.Value);
            }
            catch { }
        }
    }

    private static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
    private string GetBoardingTime(string flightTime)
    {
        if (!string.IsNullOrEmpty(flightTime))
        {
            var date = DateTime.Parse(flightTime, System.Globalization.CultureInfo.CurrentCulture);

            return date.AddMinutes(-40).ToString("HH:mm");
        }
        return string.Empty;
    }

    public Ticket GetById(int ticketId)
    {
        var ticket = _context.Tickets.Find(ticketId);
        _context.Entry(ticket).Reference(r => r.User).Load();
        return ticket;
    }

    public void Update(Ticket ticket)
    {
        if (_context.Tickets.Find(ticket.Id) == null)
        {
            throw new NullReferenceException($"Ticket {ticket.Id} was not found");
        }
        _context.SaveChanges();
    }

    public Ticket Save(TicketDto ticketDto)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "TicketTemplate", ticketDto.Template);
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template {ticketDto.Template} does not exist");
        }
        if (ticketDto.Airline != null)
        {
            var airlineLogoImage = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines", ticketDto.Airline.AirlineCode);
            if (!File.Exists(airlineLogoImage))
            {
                throw new FileNotFoundException($"Airline logo {ticketDto.Airline.AirlineCode} does not exist");
            }
        }

        var ticket = new Ticket
        {
            FromName = ticketDto.From.PlaceName,
            AirlineCode = ticketDto.Airline?.AirlineCode,
            FirstName = ticketDto.FirstName,
            LastName = ticketDto.LastName,
            AirlineName = ticketDto.Airline?.AirlineName,
            ToCode = ticketDto.To?.PlaceId,
            ToName = ticketDto.To?.PlaceName,
            FlightTime = ticketDto.FlightTime,
            Class = ticketDto.Class,
            FlightDate = ticketDto.FlightDate,
            FlightNumber = ticketDto.FlightNumber,
            FromCode = ticketDto.From?.PlaceId,
            Gate = ticketDto.Gate,
            Language = ticketDto.Language,
            Seat = ticketDto.Seat,
            Template = ticketDto.Template,
            GeneratedTicket = ticketDto.GeneratedTicket,
            User = new User
            {
                EmailAddress = ticketDto.Email,
                FirstName = "Unknown",
                LastName = "Unknown"
            },
            IsPaid = false
        };
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
        return ticket;
    }

    private Bitmap AddAirlineLogo(Bitmap bitmap, Ticket ticket, PointF logo)
    {
        if (!string.IsNullOrEmpty(ticket.AirlineCode))
        {
            var airlineLogoImage = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines", ticket.AirlineCode);
            if (!File.Exists(airlineLogoImage))
            {
                throw new FileNotFoundException($"Airline logo {ticket.AirlineCode} does not exist");
            }
            Bitmap airlineBitmap = (Bitmap)Image.FromFile(airlineLogoImage);

            Graphics gra = Graphics.FromImage(bitmap);
            gra.DrawImage(airlineBitmap, logo);
        }
        return bitmap;
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmm");
    }
}

