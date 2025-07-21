using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;


public class CreateEventModel(EventRepository repository, TripleSeatService tripleSeatService) : PageModel
{
    private readonly EventRepository _repository = repository;
    private readonly TripleSeatService _tripleSeatService = tripleSeatService;

    [BindProperty]
    public CalendarEvent NewEvent { get; set; } = new();

    public void OnGet()
    {
        var now = DateTime.Now;
        NewEvent.StartTime = now;
        NewEvent.EndTime = now.AddHours(1);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // 🛑 Overlap detection
        if (await _tripleSeatService.IsOverlappingAsync(NewEvent))
        {
            TempData["ToastError"] = "This event overlaps with an existing one.";
            return Page();
        }


        _repository.Add(NewEvent);
        TempData["ToastMessage"] = "Event created successfully!";
        return RedirectToPage("/Events");
    }
}