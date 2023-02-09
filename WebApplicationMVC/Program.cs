using Infrastructure;
using WebApplicationMVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<GlobalExceptionHandler>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
