using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outbooked.API.Models;

namespace Outbooked.API.Services;

public class EventRepository
{
    private readonly List<CalendarEvent> _events;

    public EventRepository()
    {
        _events = new()
        {
            new() {
                Id = Guid.Parse("07101055-7931-433f-a447-5a8376c54ba8"),
                ClientName = "Sunset Catering Co.",
                Location = "Grand Ballroom",
                StartTime = DateTime.Today.AddHours(14),
                EndTime = DateTime.Today.AddHours(17),
                Status = "Confirmed"
            },
            new() {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ClientName = "Elegant Events",
                Location = "Rooftop Terrace",
                StartTime = DateTime.Today.AddHours(18),
                EndTime = DateTime.Today.AddHours(21),
                Status = "Lead"
            }
        };
    }

    public List<CalendarEvent> GetAll() => _events;

    public CalendarEvent? GetById(Guid id) =>
        _events.FirstOrDefault(e => e.Id == id);

    public void Add(CalendarEvent newEvent)
    {
        newEvent.Id = Guid.NewGuid();
        _events.Add(newEvent);
    }

    public void Update(CalendarEvent updatedEvent)
    {
        var index = _events.FindIndex(e => e.Id == updatedEvent.Id);
        if (index >= 0)
            _events[index] = updatedEvent;
    }

    public void Remove(Guid id)
    {
        var evt = _events.FirstOrDefault(e => e.Id == id);
        if (evt is not null)
            _events.Remove(evt);
    }
}

