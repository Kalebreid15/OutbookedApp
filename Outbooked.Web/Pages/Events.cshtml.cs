using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Outbooked.API.Models;
using Outbooked.API.Services;

namespace Outbooked.Web.Pages;

public class EventsModel(EventRepository eventRepository, OutlookSyncService outlookSyncService) : PageModel
{
    private readonly EventRepository _eventRepository = eventRepository;
    private readonly OutlookSyncService _outlookSyncService = outlookSyncService;

    public List<CalendarEvent> Events { get; set; } = [];

    [BindProperty(SupportsGet = true)]
    public string Filter { get; set; } = "All";

    public Task OnGetAsync()
    {
        var allEvents = _eventRepository.GetAll();
        Events = Filter == "All"
            ? allEvents
            : [.. allEvents.Where(e => e.Status.Equals(Filter, StringComparison.OrdinalIgnoreCase))];

        return Task.CompletedTask;
    }

    public async Task<IActionResult> OnPostSyncAsync(Guid id)
    {
        var evt = _eventRepository.GetById(id);
        if (evt is null) return NotFound();

        var success = await _outlookSyncService.SyncEventAsync(evt);
        if (success)
        {
            evt.Status = "Synced";
            _eventRepository.Update(evt);
        }

        var allEvents = _eventRepository.GetAll();
        Events = Filter == "All"
            ? allEvents
            : [.. allEvents.Where(e => e.Status.Equals(Filter, StringComparison.OrdinalIgnoreCase))];

        return Page();
    }

    public async Task<IActionResult> OnPostSyncAllAsync()
    {
        var allEvents = _eventRepository.GetAll();

        // Snapshot to avoid modifying during iteration
        foreach (var evt in allEvents.Where(e => e.Status != "Synced").ToList())
        {
            var success = await _outlookSyncService.SyncEventAsync(evt);
            if (success)
            {
                evt.Status = "Synced";
                _eventRepository.Update(evt);
            }
        }

        Events = Filter == "All"
            ? allEvents
            : [.. allEvents.Where(e => e.Status.Equals(Filter, StringComparison.OrdinalIgnoreCase))];

        TempData["ShowSyncToast"] = "true";
        return Page();
    }
}