using Azure.Identity;
using BAL.DataManager;
using BAL.Repository;
using DAL;
using DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var keyVaultEndPoint = new Uri($"https://{builder.Configuration["Connection"]}.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultEndPoint, new DefaultAzureCredential());

builder.Services.AddDbContext<PersonDBContext>(x => x.UseSqlServer(builder.Configuration["secret1"]));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = "ASP.NET Core 6.0 Web API"
    });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
             Reference = new OpenApiReference
             {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
             }
           },
           new string[] { }
        }
    });
});

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7281",
            ValidAudience = "https://localhost:7281",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });
builder.Services.AddControllers();
builder.Services.AddScoped<IMainRepository<Person>, PersonManager>();
builder.Services.AddScoped<IInsertRepository<Person>, PersonManager>();
builder.Services.AddScoped<IUpdateRepository<Person>, PersonManager>();
builder.Services.AddScoped<IDeleteRepository<Person>, PersonManager>();

builder.Services.AddScoped<IMainRepositoryNew<Person>, PersonManagerNew>();

builder.Services.AddScoped<IMainRepository<DriverLicense>, DriverLicenseManager>();
builder.Services.AddScoped<IInsertRepository<DriverLicense>, DriverLicenseManager>();
builder.Services.AddScoped<IUpdateRepository<DriverLicense>, DriverLicenseManager>();
builder.Services.AddScoped<IDeleteRepository<DriverLicense>, DriverLicenseManager>();

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
