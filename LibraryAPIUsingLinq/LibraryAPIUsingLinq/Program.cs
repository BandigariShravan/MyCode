using LibraryAPIUsingLinq.Data;
using LibraryAPIUsingLinq.DataManager;
using LibraryAPIUsingLinq.Models;
using LibraryAPIUsingLinq.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryAPIDBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));
builder.Services.AddScoped<IDataRepository<Library>, LibraryManager>();
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
