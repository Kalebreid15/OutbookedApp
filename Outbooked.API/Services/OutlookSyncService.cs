using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outbooked.API.Models;

namespace Outbooked.API.Services;

public class OutlookSyncService
{
    public async Task<bool> SyncEventAsync(CalendarEvent evt)
    {
        await Task.Delay(200); // Simulate latency
        Console.WriteLine($"[SYNC] {evt.ClientName} successfully synced to Outlook");
        return true;
    }
}

