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

    public string Generate(Ticket ticket)
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
                graphics.DrawString(ticket.FromName, arialFont, Brushes.Black, new PointF(500f, 100f));
                graphics.DrawString(ticket.ToName, arialFont, Brushes.Black, new PointF(500f, 150f));
            }
        }

        bitmap = AddAirlineLogo(bitmap, ticket);

        var fileName = $"{Guid.NewGuid()}.png";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", fileName);
        bitmap.Save(filePath, ImageFormat.Png);
        return fileName;
    }

    public Ticket GetById(int ticketId)
    {
        var ticket= _context.Tickets.Find(ticketId);
        _context.Entry(ticket).Reference(r => r.User).Load();
        return ticket;
    }

    public void Update(Ticket ticket) {
        if(_context.Tickets.Find(ticket.Id) == null)
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

    private Bitmap AddAirlineLogo(Bitmap bitmap, Ticket ticket)
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
            gra.DrawImage(airlineBitmap, new Point(70, 70));
        }
        return bitmap;
    }

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmm");
    }
}