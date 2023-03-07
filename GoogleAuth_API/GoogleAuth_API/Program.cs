using BAL.Data;
using BAL.Models;
using DAL.Repository;
using DAL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Google_Authentication",
        Version = "v1"
    });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode=new OpenApiOAuthFlow()
            {
                AuthorizationUrl=new Uri("https://accounts.google.com/o/oauth2/auth"),
                TokenUrl=new Uri("https://oauth2.googleapis.com/token"),
                Scopes= new Dictionary<string, string>
                {
                    {
                        "https://www.googleapis.com/auth/userinfo.email",
                        "bandigarishravan@gmail.com"
                    },
                    {
                         "https://www.googleapis.com/auth/userinfo.profile",
                        "Bandigari Shravan Kumar"
                    }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "oauth2"
            },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
        },
        new List < string > ()
    }});
});



builder.Services.AddDbContext<RecordDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = "164778201468-vsh7dnm2po19bfrgfio6r9sicmbq7fm6.apps.googleusercontent.com";
    options.ClientSecret = "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";
});


builder.Services.AddScoped<IDataRepository<Record>, RecordsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthDemo v1");

        c.OAuthClientId("164778201468-rtuss9ab6bjhcl4eg15qdrhu88cbe11j.apps.googleusercontent.com");
        c.OAuthClientSecret("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");

        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
