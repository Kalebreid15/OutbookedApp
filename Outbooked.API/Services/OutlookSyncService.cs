using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Outbooked.API.Models;

namespace Outbooked.API.Services;

public class OutlookSyncService
{
    // Simulate syncing a single event to Outlook
    public static async Task<bool> SyncEventAsync(CalendarEvent evt)
    {
        await Task.Delay(200); // Simulated latency
        Console.WriteLine($"[SYNC] {evt.ClientName} successfully synced to Outlook");
        return true;
    }

    // 👇 This is the method your Razor Page now calls
    public void Sync()
    {
        // Placeholder logic — replace with actual sync trigger or summary
        Console.WriteLine("[SYNC] Sync function triggered.");
    }
}