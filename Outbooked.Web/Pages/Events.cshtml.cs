using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class EventsModel(EventRepository repository) : PageModel
{
    private readonly EventRepository _repository = repository;

    public List<CalendarEvent> AllEvents { get; set; } = [];

    public void OnGet()
    {
        AllEvents = _repository.GetAll();
    }
}