using Api.Services;
using Api.Endpoints;
using Api.Data;
using Api.Repositories;
using Api.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<PasswordService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();
app.MapTaskEndpoints();
app.MapUserEndpoints();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();