using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class EditEventModel(EventRepository eventRepository) : PageModel
{
    private readonly EventRepository _eventRepository = eventRepository;

    [BindProperty]
    public CalendarEvent EditableEvent { get; set; } = new();

    public IActionResult OnGet(Guid id)
    {
        var evt = _eventRepository.GetById(id);
        if (evt == null)
            return NotFound();

        EditableEvent = evt;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _eventRepository.Update(EditableEvent);
        Console.WriteLine($"[EDIT EVENT] {EditableEvent.ClientName} updated");

        TempData["ShowEditToast"] = "true"; // Optional: triggers toast on Events page

        return RedirectToPage("/Events");
    }
}