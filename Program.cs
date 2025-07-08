using FFCProject.Components;
using FFCProject.Services;
using FFCProject.Data;
using Microsoft.EntityFrameworkCore;
using NetcodeHub.Packages.Components.Toast;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register EmailSystem
builder.Services.AddScoped(sp =>
    new EmailSystem(
        "smtp.gmail.com",
        587,
        "h.abbubakar10@gmail.com",
        "kzkb iufg knjf csvt\r\n"
    )
);

// ✅ Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString")));

// ✅ ADD THIS: Register API Controllers
builder.Services.AddControllers();

// ✅ ADD THIS: Register user state service
builder.Services.AddSingleton<UserStateService>();

builder.Services.AddScoped<ToastService>();          

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// ✅ Map API Controllers
app.MapControllers();

// ✅ Map Blazor Razor Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
