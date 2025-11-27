using BlazorAuth.Api.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// Services
// -------------------------

builder.Services.AddControllers();

// CORS (utile si tu as des appels depuis un autre domaine/port, sinon pas strictement nécessaire ici)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Blazor Server / Razor Components
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

// HttpClient pour le frontend (API et Blazor sont sur le même projet, URL relative)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("/") });

// -------------------------
// Build app
// -------------------------

builder.WebHost.UseUrls("http://0.0.0.0:5254");


var app = builder.Build();

// -------------------------
// Middleware
// -------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

app.UseRouting();

app.UseCors();           // Active CORS si nécessaire
app.UseAuthorization();
app.UseAntiforgery();

// API Controllers
app.MapControllers();

// Blazor components
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

// -------------------------
// Run
// -------------------------

app.Run();
