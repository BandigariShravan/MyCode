using BAL.Data;
using BAL.Models;
using DAL.Repository;
using DAL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(
//c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Facebook_Authentication",
//        Version = "v1"
//    });
//    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//    {
//        Type = SecuritySchemeType.OAuth2,
//        Flows = new OpenApiOAuthFlows()
//        {
//            AuthorizationCode = new OpenApiOAuthFlow()
//            {
//                AuthorizationUrl = new Uri("https://www.facebook.com/v11.0/dialog/oauth"),
//                TokenUrl = new Uri("https://graph.facebook.com/v11.0/oauth/access_token"),
//                Scopes = new Dictionary<string, string>
//                {
//                    {
//                        "public_profile",
//                        "shravan"
//                    },
//                    {
//                        "email",
//                        "shravan@gmail.com"
//                    }
//                }
//            }
//        }
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "oauth2"
//                },
//                Scheme = "oauth2",
//                Name = "oauth2",
//                In = ParameterLocation.Header
//            },
//            new List<string>()
//        }
//    });
//});

var facebookAppId = builder.Configuration["FacebookAuth:AppId"];
var facebookAppSecret = builder.Configuration["FacebookAuth:AppSecret"];
builder.Services.AddAuthentication(c =>
{
    c.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme=FacebookDefaults.AuthenticationScheme;
})
.AddCookie()
.AddFacebook(op =>
{
    //op.AppId="535722022019006";
    //op.AppSecret="b2ed99c6eb4f9b65ab8050f235605337";
    op.AppId=facebookAppId;
    op.AppSecret=facebookAppSecret;
});

builder.Services.AddDbContext<RecordDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));


builder.Services.AddScoped<IDataRepository<Record>, RecordsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    // {
    //     //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthDemo v1");

    //     //     //c.OAuthClientId("535722022019006");
    //     //c.OAuthClientSecret("b2ed99c6eb4f9b65ab8050f235605337");
    //     c.OAuthClientId(facebookAppId);
    //     c.OAuthClientSecret(facebookAppSecret);

    //     //     c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    // });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
