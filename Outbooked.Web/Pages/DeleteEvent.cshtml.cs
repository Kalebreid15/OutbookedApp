using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class DeleteEventModel(EventRepository repository) : PageModel
{
    private readonly EventRepository _repository = repository;

    [BindProperty]
    public CalendarEvent TargetEvent { get; set; } = new();

    public IActionResult OnGet(Guid id)
    {
        var evt = _repository.GetById(id);
        if (evt is null) return NotFound();

        TargetEvent = evt;
        return Page();
    }

    public IActionResult OnPost()
    {
        Console.WriteLine($"[DELETE] Deleting ID: {TargetEvent.Id}");
        _repository.Remove(TargetEvent.Id);
        TempData["ToastMessage"] = "🗑️ Event deleted successfully!";
        return RedirectToPage("/Events");
    }
}