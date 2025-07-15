using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class CreateEventModel(TripleSeatService tripleSeatService) : PageModel
{
    private readonly TripleSeatService _tripleSeatService = tripleSeatService;

    [BindProperty]
    public CalendarEvent NewEvent { get; set; } = new();

    public void OnGet()
    {
        NewEvent.StartTime = DateTime.Now.AddHours(1).AddMinutes(-(DateTime.Now.AddHours(1).Minute % 15)); // rounded to nearest 15
        NewEvent.EndTime = NewEvent.StartTime.AddHours(1);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        bool hasConflict = await _tripleSeatService.IsOverlappingAsync(NewEvent);

        if (hasConflict)
        {
            TempData["ToastMessage"] = "⚠️ Overlapping event detected. Please reschedule.";
            return Page(); // preserve form data and show error toast
        }

        await _tripleSeatService.SaveEventAsync(NewEvent);
        TempData["ToastMessage"] = "✅ Event created successfully!";
        return RedirectToPage("Events");
    }
}