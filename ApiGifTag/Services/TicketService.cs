using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;

public class TicketService
{
    public TicketViewModel Generate(Ticket ticket)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "TicketTemplate", $"template_{ticket.Template}.png");

        Bitmap bitmap = (Bitmap)Image.FromFile(templatePath);//load the image file

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

        return new TicketViewModel
        {
            FirstName = ticket.FirstName,
            LastName = ticket.LastName,
            Email = ticket.Email,
            Airline = ticket.Airline,
            BoardingTime = ticket.BoardingTime,
            Class = ticket.Class,
            FlightDate = ticket.FlightDate,
            FlightNumber = ticket.FlightNumber,
            From = ticket.From,
            Gate = ticket.Gate,
            Language = ticket.Language,
            To = ticket.To,
            Seat = ticket.Seat,
            GeneratedTicket = new GeneratedTicket
            {
                FileName = fileName,
                Path = $"/GeneratedTickets/{fileName}"
            }
        };
    }

    private Bitmap AddAirlineLogo(Bitmap bitmap, Ticket ticket)
    {
        if (ticket.Airline != null && !string.IsNullOrEmpty(ticket.Airline.AirlineCode))
        {
            var airlineLogoImage = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines", ticket.Airline.AirlineCode);
            Bitmap airlineBitmap = (Bitmap)Image.FromFile(airlineLogoImage); //load the image file

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