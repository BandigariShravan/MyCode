using Azure.Identity;
using BAL.DataManager;
using BAL.DataRepository;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var keyVaultEndPoint = new Uri($"https://{builder.Configuration["Connection"]}.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultEndPoint, new DefaultAzureCredential());//, new ClientCertificateCredential(builder.Configuration["ClientId"], builder.Configuration["TenantId"], x509Certificate));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MSAL_Authorization",
        Version = "v1"
    });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://login.microsoftonline.com/8f6bd982-92c3-4de0-985d-0e287c55e379/oauth2/v2.0/authorize"),
                TokenUrl = new Uri("https://login.microsoftonline.com/8f6bd982-92c3-4de0-985d-0e287c55e379/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string>
                {
                    {
                        "api://f541aaf5-11ef-4ac7-806b-49e2d33d1a39/access_BSK",
                        "User.Read"
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


builder.Services.AddDbContext<CompanyDBContext>(x => x.UseSqlServer(builder.Configuration["secret1"]));
//builder.Services.AddDbContext<CompanyDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString(""));

builder.Services.AddScoped<IDataMainRepository<Employee>, EmployeeManager>();
builder.Services.AddScoped<IDataMainRepository<Company>, CompanyManager>();

builder.Services.AddScoped<IGetAllRepository<Employee>, EmployeeManager>();
builder.Services.AddScoped<IGetAllRepository<Company>, CompanyManager>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthDemo v1");

        c.OAuthClientId("f541aaf5-11ef-4ac7-806b-49e2d33d1a39");
        c.OAuthClientSecret("da69f4e3-defe-43b1-a08a-18037834c3ab");

       c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();