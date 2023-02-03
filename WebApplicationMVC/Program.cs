using Application.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCnnection")));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
