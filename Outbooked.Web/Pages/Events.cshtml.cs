using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class EventsModel(EventRepository repository, OutlookSyncService syncService) : PageModel
{
    private readonly EventRepository _repository = repository;
    private readonly OutlookSyncService _syncService = syncService;

    public List<CalendarEvent> AllEvents { get; set; } = [];

    public void OnGet()
    {
        AllEvents = _repository.GetAll();
    }

    public IActionResult OnPostSyncOutlook()
    {
        _syncService.Sync(); // Simulated sync call

        // ✅ Only update events currently marked as "Confirmed"
        foreach (var evt in _repository.GetAll().Where(e => e.Status == "Confirmed"))
        {
            evt.Status = "Synced";
        }

        TempData["ToastMessage"] = "Outlook calendar synced.";
        return RedirectToPage();
    }
}