using Outbooked.API.Models;

namespace Outbooked.API.Services;

public class TripleSeatService(EventRepository repository)
{
    private readonly EventRepository _repository = repository;

    public static bool ConflictExists(CalendarEvent existing, CalendarEvent incoming)
    {
        return existing.Id != incoming.Id &&
           existing.StartTime < incoming.EndTime &&
           incoming.StartTime < existing.EndTime;
    }

    public async Task<bool> IsOverlappingAsync(CalendarEvent incoming)
    {
        var existingEvents = _repository.GetAll();

        // Simulate async latency
        await Task.Delay(100);

        return existingEvents.Any(existing =>
            existing.Id != incoming.Id &&
            existing.StartTime < incoming.EndTime &&
            incoming.StartTime < existing.EndTime
        );
    }

    public async Task SaveEventAsync(CalendarEvent newEvent)
    {
        await Task.Delay(50); // Simulated delay for realism

        if (newEvent.Id == Guid.Empty || _repository.GetById(newEvent.Id) is null)
        {
            _repository.Add(newEvent);
        }
        else
        {
            _repository.Update(newEvent);
        }
    }
}