public class TicketDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public AirportDto From { get; set; }
    public AirportDto To { get; set; }
    public string FlightDate { get; set; }
    public string BoardingTime { get; set; }
    public AirlineDto Airline { get; set; }
    public string FlightNumber { get; set; }
    public string Gate { get; set; }
    public string Seat { get; set; }
    public string Class { get; set; }
    public string Language { get; set; }
    public string Template { get; set; }
    public string GeneratedTicket { get; set; }
}
