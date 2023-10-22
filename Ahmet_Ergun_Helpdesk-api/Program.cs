using Helpdesk_api.Core;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Helpdesk_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo{ Title = "Help Desk Api", Version = "v1" });
});

builder.Services.AddDbContext<HelpDeskDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(HelpDeskDbContext));
});

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<TicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
