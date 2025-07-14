using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outbooked.API.Models;


namespace Outbooked.API.Services;

public class TripleSeatService(EventRepository repository)
{
    private readonly EventRepository _repository = repository;

    public static bool ConflictExists(CalendarEvent existing, CalendarEvent incoming)
    {
        return existing.StartTime < incoming.EndTime && incoming.StartTime < existing.EndTime;
    }

    public async Task<List<CalendarEvent>> GetMockEventsAsync()
    {
        await Task.Delay(200); // Simulate API latency
        return _repository.GetAll();
    }
}

