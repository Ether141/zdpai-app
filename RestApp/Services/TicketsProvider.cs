using RestApp.Models;

namespace RestApp.Services;

public class TicketsProvider : ITicketsProvider
{
    private readonly List<Ticket> _tickets =
    [
        new()
        {
            Id = 1,
            Title = "Login issue",
            Description = "User cannot log in with correct credentials.",
            CreatedDate = new DateTime(2025, 10, 20, 9, 15, 0)
        },
        new()
        {
            Id = 2,
            Title = "Payment not processed",
            Description = "Payment gateway returned an error for order #5421.",
            CreatedDate = new DateTime(2025, 10, 21, 11, 30, 0)
        },
        new()
        {
            Id = 3,
            Title = "UI bug on dashboard",
            Description = "Widgets overlap on smaller screens (width < 1024px).",
            CreatedDate = new DateTime(2025, 10, 22, 14, 5, 0)
        },
        new()
        {
            Id = 4,
            Title = "Missing translation",
            Description = "Spanish translation for the settings page is missing.",
            CreatedDate = new DateTime(2025, 10, 23, 10, 45, 0)
        },
        new()
        {
            Id = 5,
            Title = "Performance degradation",
            Description = "Reports module takes more than 10 seconds to load.",
            CreatedDate = new DateTime(2025, 10, 24, 16, 20, 0)
        }
    ];

    public IEnumerable<Ticket> GetAllTickets() => _tickets.AsReadOnly();

    public Ticket? GetTicket(int id) => _tickets.FirstOrDefault(t => t.Id == id);
}
