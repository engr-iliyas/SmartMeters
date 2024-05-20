using Smart.Meters.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Smart.Meters.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Smart.Meters;

var builder = WebApplication.CreateBuilder(args);

string connectionString = string.Empty;

if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")))
{
    // Add services to the container.MySqlPameleoConnection MySQLConnection DefaultConnection
    connectionString = builder.Configuration.GetConnectionString("MySqlPameleoConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
else
{
    connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")!;
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found."))
    //options.UseInMemoryDatabase(databaseName: "InMemoryDatabase")
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );
builder.Services.AddQuickGridEntityFrameworkAdapter();;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run migrations
app.ApplyMigrations();

app.Run();