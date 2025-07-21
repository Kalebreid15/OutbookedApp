using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class EditEventModel(EventRepository repository, TripleSeatService tripleSeatService) : PageModel
{
    private readonly EventRepository _repository = repository;
    private readonly TripleSeatService _tripleSeatService = tripleSeatService;

    [BindProperty]
    public CalendarEvent EditableEvent { get; set; } = new();

    public IActionResult OnGet(Guid id)
    {
        var evt = _repository.GetById(id);
        if (evt is null) return RedirectToPage("/Events");

        EditableEvent = evt;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        if (await _tripleSeatService.IsOverlappingAsync(EditableEvent))
        {
            ModelState.AddModelError(string.Empty, "This event overlaps with an existing one.");
            return Page();
        }

        _repository.Update(EditableEvent);
        TempData["ToastMessage"] = "Event updated successfully!";
        return RedirectToPage("/Events");
    }
}