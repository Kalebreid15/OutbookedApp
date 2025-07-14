using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class DeleteEventModel : PageModel
{
    private readonly EventRepository _repository;

    public DeleteEventModel(EventRepository repository)
    {
        _repository = repository;
    }

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
        _repository.Remove(TargetEvent.Id);
        return RedirectToPage("/Events");
    }
}