using GifTag.Database;

public interface ITicketService
{
    TicketDto Generate(TicketDto ticket);
    Ticket GetById(int ticketId);
    void SeTicketAsPaid(int ticketId);
}
