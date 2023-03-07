using Microsoft.EntityFrameworkCore;
using UnitTesting_Final.Data;
using UnitTesting_Final.DataManager;
using UnitTesting_Final.DataRepository;
using UnitTesting_Final.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionProduct")));
builder.Services.AddScoped<IDataRepository,ProductManager>();


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

