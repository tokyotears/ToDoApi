using System.Text.Json.Serialization;
using Api.Services;
using Api.Endpoints;
using Api.Data;
using Api.Repositories;
using Api.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<TaskRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();
app.MapTaskEndpoints();

app.Run();