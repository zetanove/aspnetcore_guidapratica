using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using TodoWebApi;
using TodoWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sqlite"]);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
