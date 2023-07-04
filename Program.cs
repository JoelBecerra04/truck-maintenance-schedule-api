using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using truck_maintenance_schedule_api.Models;
using Microsoft.Extensions.Configuration;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScheduleMaintenanceContext>();
builder.Services.AddTransient<Schedule>();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


var app = builder.Build();

app.MapGet("/drivers", async (ScheduleMaintenanceContext context) =>
    await context.Users.Where(d => d.Type == "Driver").ToListAsync()
); ;

app.MapGet("/dispatchers", async (ScheduleMaintenanceContext context) =>
    await context.Users.Where(d => d.Type == "Dispatcher").ToListAsync()
); ;

app.MapGet("/mechanics", async (ScheduleMaintenanceContext context) =>
    await context.Users.Where(d => d.Type == "Mechanic").ToListAsync()
); ;

app.MapGet("/trucks", async (ScheduleMaintenanceContext context) =>
    await context.Trucks.ToListAsync()
); ;

app.MapGet("/maintenances", async (ScheduleMaintenanceContext context) =>
    await context.Maintenances.ToListAsync()
); ;

app.MapGet("/schedules", async (ScheduleMaintenanceContext context) =>
    await context.Schedules.ToListAsync()
); ;

app.MapPost("/schedules", async (Schedule request, ScheduleMaintenanceContext context) =>
{
    context.Schedules.Add(request);
    await context.SaveChangesAsync();
    return request; 
});

app.Run();
