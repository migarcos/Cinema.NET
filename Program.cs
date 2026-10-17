using TicketSales.Components;
using TicketSales.Services;
using Microsoft.EntityFrameworkCore;
using TicketSales.Data;

var builder = WebApplication.CreateBuilder(args);

// AddDbContext together with UseSqlite(...) is the standard EF Core registration pattern
builder.Services.AddDbContext<CinemaContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("CinemaDb"));
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
// Add Movie Service  to introduce deoendency injection. 
// Singleton means one service instance is shared for the app lifetime
// builder.Services.AddSingleton<MovieService>();
// builder.Services.AddSingleton<AuditoriumService>();
// builder.Services.AddSingleton<ShowingService>();

// A DbContext is scoped. A Singleton service cannot safely depend on a scoped DbContext.
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<AuditoriumService>();
builder.Services.AddScoped<ShowingService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SessionService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    UserSeed.Initialize(
        scope.ServiceProvider);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
