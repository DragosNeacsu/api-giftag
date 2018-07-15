using GifTag.Database;

public interface ITicketService
{
    string Generate(Ticket ticket);
    Ticket Save(TicketDto ticketDto);
    Ticket GetById(int ticketId);
    void Update(Ticket ticket);
}
