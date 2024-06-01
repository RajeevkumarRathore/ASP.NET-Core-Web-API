using API.Adapter;
using Application.Adapter;
using Infrastructure;
using Middlewares;
using Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Settings;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Domain.Entities.LocalCheck;
using Domain.Entities.Connections;
using Infrastructure.Implementation.Hub;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
var myCors = "_myAllowSpecificOrigins";

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

ApiMapConfiguration.Configure(configuration);
ApiMapsterMappings.Configure();
ApplicationMapsterMappings.Configure();
//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors,
                      policy =>
                      {
                          policy.WithOrigins("https://test.com/", "https://localhost:4200", "*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(i => i.FullName);
    c.OperationFilter<AddRequiredHeaderParameter>();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Test API",
        Version = "v1"

    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      Array.Empty<string>()
                    }
                  });
});

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("Application"));
builder.Services.AddInfrastructure();
builder.Services.AddPersistence();
builder.Services.AddRazorTemplating();
builder.Services.AddSignalR();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//        options => builder.Configuration.Bind("JwtSettings", options))
//    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//        options => builder.Configuration.Bind("CookieSettings", options));
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var mailSettingsSection = builder.Configuration.GetSection("Mail");
builder.Services.Configure<Mailsetting>(mailSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);



var env = builder.Environment;
IConnectionString connectionString;
ILocalCheck localCheck;

if (env.IsDevelopment())
{
    connectionString = new ConnectionStringLocal();
    localCheck = new LocalCheckLocal();
}
else
{
    connectionString = new ConnectionStringHost();
    localCheck = new LocalCheckHost();

}

ConnectionString.Server = connectionString.Server();
ConnectionString.ApiUrl = connectionString.ApiUrl();
ConnectionString.WebUrl = connectionString.WebUrl();
ConnectionString.HubUrl = connectionString.HubUrl();
ConnectionString.HubUrl2 = connectionString.HubUrl2();
ConnectionString.HubUrl3 = connectionString.HubUrl3();
ConnectionString.ServerNewGeo = connectionString.ServerNewGeo();
ConnectionString.TrackMeUrl = connectionString.TrackMeUrl();
LocalCheck.isLocal = localCheck.IsLocal();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();


//app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
});
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(myCors);
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseStaticFiles(); // For the wwwroot folder

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapHub<LogoutUsersHub>("/LogoutUsers");
});
app.Run();
public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();
    }
}
