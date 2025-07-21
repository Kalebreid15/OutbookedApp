using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;


public class DeleteEventModel(EventRepository repository) : PageModel
{
    private readonly EventRepository _repository = repository;

    [BindProperty]
    public CalendarEvent? TargetEvent { get; set; }

    public IActionResult OnGet(Guid id)
    {
        TargetEvent = _repository.GetById(id);
        if (TargetEvent is null) return RedirectToPage("/Events");
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        _repository.Remove(id);
        TempData["ToastMessage"] = "Event deleted successfully!";
        return RedirectToPage("/Events");
    }
}