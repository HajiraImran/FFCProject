using FFCProject.Components;
using FFCProject.Services;
using FFCProject.Data;
using FFCProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetcodeHub.Packages.Components.Toast;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load configuration for EmailSettings
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

// ✅ Register EmailSystem using IOptions<EmailSettings>
builder.Services.AddScoped<EmailSystem>();

// ✅ Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ EF Core + Identity
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders(); // ✅ For OTP/reset password, etc.

// ✅ Authentication & Authorization
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// ✅ Controllers & Custom Services
builder.Services.AddControllers();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<ToastService>();

var app = builder.Build();

// ✅ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication(); // ✅ Identity Middleware
app.UseAuthorization();

// ✅ Routing
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
