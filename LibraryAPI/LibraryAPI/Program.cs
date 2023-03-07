using LibraryAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryAPIDBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("LibraaryConnection")));
//public void ConfigureServices(IServiceCollection services)
//{
    services.AddIdentity<IdentityUser, IdentityRole>();
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
            .AddGoogle(options =>
            {
                options.ClientId = "[MyGoogleClientId]";
                options.ClientSecret = "[MyGoogleSecretKey]";
            });
    services.AddMvc();
//}
builder.Services.AddScoped<>

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
