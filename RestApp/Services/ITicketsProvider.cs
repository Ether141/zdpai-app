using RestApp.Models;

namespace RestApp.Services;

public interface ITicketsProvider
{
    public IEnumerable<Ticket> GetAllTickets();
    public Ticket? GetTicket(int id);
}
