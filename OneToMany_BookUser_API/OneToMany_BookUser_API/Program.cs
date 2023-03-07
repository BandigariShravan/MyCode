using Microsoft.EntityFrameworkCore;
using OneToMany_BookUser_API.Data;
using OneToMany_BookUser_API.DataManager;
using OneToMany_BookUser_API.Models;
using OneToMany_BookUser_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Nothing
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<BookUserDBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBook")));
builder.Services.AddScoped<IDataRepository<Book>, BookManager>();
builder.Services.AddScoped<IDataRepository<User>, UserManager>();

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
