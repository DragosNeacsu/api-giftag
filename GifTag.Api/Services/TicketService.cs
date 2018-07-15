using GifTag.Database;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class TicketService : ITicketService
{
    private readonly DataContext _context;
    public TicketService(DataContext context)
    {
        _context = context;
    }

    public TicketDto Generate(TicketDto ticket)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "TicketTemplate", ticket.Template);
        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template {ticket.Template} does not exist");
        }

        Bitmap bitmap = (Bitmap)Image.FromFile(templatePath);

        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            using (Font arialFont = new Font("Arial", 10))
            {
                graphics.DrawString(ticket.FirstName, arialFont, Brushes.Black, new PointF(500f, 10f));
                graphics.DrawString(ticket.LastName, arialFont, Brushes.Black, new PointF(500f, 50f));
                graphics.DrawString(ticket.From.PlaceName, arialFont, Brushes.Black, new PointF(500f, 100f));
                graphics.DrawString(ticket.To.PlaceName, arialFont, Brushes.Black, new PointF(500f, 150f));
            }
        }

        bitmap = AddAirlineLogo(bitmap, ticket);

        var fileName = $"{Guid.NewGuid()}.png";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", fileName);
        bitmap.Save(filePath, ImageFormat.Png);

        ticket.GeneratedTicket = fileName;
        ticket.Id = SaveToDb(ticket).Id.ToString();
        return ticket;
    }

    public Ticket GetById(int ticketId)
    {
        var ticket= _context.Tickets.Find(ticketId);
        _context.Entry(ticket).Reference(r => r.User).Load();
        return ticket;
    }

    public void SeTicketAsPaid(int ticketId) {
        var ticket = _context.Tickets.Find(ticketId);
        ticket.IsPaid = true;
        _context.SaveChanges();
    }

    private Ticket SaveToDb(TicketDto ticketDto)
    {
        var ticket = new Ticket
        {
            FromName = ticketDto.From.PlaceName,
            AirlineCode = ticketDto.Airline?.AirlineCode,
            FirstName = ticketDto.FirstName,
            LastName = ticketDto.LastName,
            AirlineName = ticketDto.Airline?.AirlineName,
            ToCode = ticketDto.To?.PlaceId,
            ToName = ticketDto.To?.PlaceName,
            BoardingTime = ticketDto.BoardingTime,
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

    private Bitmap AddAirlineLogo(Bitmap bitmap, TicketDto ticket)
    {
        if (ticket.Airline != null && !string.IsNullOrEmpty(ticket.Airline.AirlineCode))
        {
            var airlineLogoImage = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines", ticket.Airline.AirlineCode);
            if (!File.Exists(airlineLogoImage))
            {
                throw new FileNotFoundException($"Airline logo {ticket.Airline.AirlineCode} does not exist");
            }
            Bitmap airlineBitmap = (Bitmap)Image.FromFile(airlineLogoImage);

            Graphics gra = Graphics.FromImage(bitmap);
            gra.DrawImage(airlineBitmap, new Point(70, 70));
        }
        return bitmap;
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmm");
    }
}