using Microsoft.AspNetCore.Mvc;
using RestApp.Models;
using RestApp.Services;

namespace RestApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : Controller
{
    private readonly ITicketsProvider _ticketsProvider;

    public TicketsController(ITicketsProvider ticketsProvider)
    {
        _ticketsProvider = ticketsProvider;
    }

    [HttpGet]
    public IActionResult GetTickets() => Ok(_ticketsProvider.GetAllTickets().Select(t => new { t.Id, t.Title }));

    [HttpGet("{id}")]
    public IActionResult GetTicket(int id)
    {
        Ticket? ticket = _ticketsProvider.GetTicket(id);

        if (ticket == null)
        {
            var problem = new ProblemDetails
            {
                Title = "Ticket not found",
                Detail = $"Ticket with id = {id} does not exist."
            };

            return NotFound(problem);
        }

        return Ok(ticket);
    }

    [HttpGet("assignee/{id}")]
    public IActionResult GetTicketAssignee(int id)
    {
        var problem = new ProblemDetails
        {
            Title = "Unauthorized user",
            Detail = "You do not have permissions to get information about assigned user to the ticket."
        };

        return Unauthorized(problem);
    }
}
