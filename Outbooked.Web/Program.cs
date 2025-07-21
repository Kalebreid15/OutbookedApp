using Outbooked.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<EventRepository>();
builder.Services.AddTransient<TripleSeatService>();
builder.Services.AddTransient<OutlookSyncService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();