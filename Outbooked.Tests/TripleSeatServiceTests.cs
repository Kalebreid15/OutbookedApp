using Outbooked.API.Models;
using Outbooked.API.Services;
using Xunit;

namespace Outbooked.Tests
{
    public class TripleSeatServiceTests
    {
        [Fact]
        public void ConflictExists_ShouldReturnTrue_IfEventsOverlap()
        {
            var existing = new CalendarEvent
            {
                StartTime = DateTime.Today.AddHours(14),
                EndTime = DateTime.Today.AddHours(16)
            };

            var incoming = new CalendarEvent
            {
                StartTime = DateTime.Today.AddHours(15),
                EndTime = DateTime.Today.AddHours(17)
            };

            var result = TripleSeatService.ConflictExists(existing, incoming);
            Assert.True(result);
        }

        [Fact]
        public void ConflictExists_ShouldReturnFalse_IfNoOverlap()
        {
            var existing = new CalendarEvent
            {
                StartTime = DateTime.Today.AddHours(10),
                EndTime = DateTime.Today.AddHours(12)
            };

            var incoming = new CalendarEvent
            {
                StartTime = DateTime.Today.AddHours(12),
                EndTime = DateTime.Today.AddHours(13)
            };

            var result = TripleSeatService.ConflictExists(existing, incoming);
            Assert.False(result);
        }
    }
}