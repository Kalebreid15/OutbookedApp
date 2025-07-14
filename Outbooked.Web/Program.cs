using Outbooked.API.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Register backend services for DI
builder.Services.AddSingleton<EventRepository>(); // Centralized event store
builder.Services.AddScoped<TripleSeatService>();
builder.Services.AddScoped<OutlookSyncService>();

// Razor Pages setup
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 🔁 Redirect root ("/") to /Events
app.MapGet("/", context =>
{
    context.Response.Redirect("/Events");
    return Task.CompletedTask;
});

// Map Razor Pages (no controllers yet)
app.MapRazorPages();

app.Run();