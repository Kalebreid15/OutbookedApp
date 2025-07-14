using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class CreateEventModel(EventRepository eventRepository) : PageModel
{
    private readonly EventRepository _eventRepository = eventRepository;

    [BindProperty]
    public CalendarEvent NewEvent { get; set; } = new();

    public IActionResult OnGet()
    {
        NewEvent.StartTime = DateTime.Now.AddHours(1); // Default start time to one hour from now
        NewEvent.EndTime = DateTime.Now.AddHours(2); // Default end time to two hours from now
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _eventRepository.Add(NewEvent);

        // Log to console for debugging
        Console.WriteLine($"[NEW EVENT] {NewEvent.ClientName} at {NewEvent.Location}");

        // Toast confirmation trigger
        TempData["ShowCreateToast"] = "true";

        return RedirectToPage("/Events");
    }
}
