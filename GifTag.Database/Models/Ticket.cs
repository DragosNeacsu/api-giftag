using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Ticket
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FromName { get; set; }
    public string FromCode { get; set; }
    public string ToName { get; set; }
    public string ToCode { get; set; }
    public string FlightDate { get; set; }
    public string BoardingTime { get; set; }
    public string AirlineName { get; set; }
    public string AirlineCode { get; set; }
    public string FlightNumber { get; set; }
    public string Gate { get; set; }
    public string Seat { get; set; }
    public string Class { get; set; }
    public string Language { get; set; }
    public string Template { get; set; }
}

