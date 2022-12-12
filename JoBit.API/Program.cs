using JoBit.API.Shared.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v2", new OpenApiInfo
        {
            Version = "v2",
            Title = "NastyPad JoBit API",
            TermsOfService = new Uri("https://www.google.com/"),
            Contact = new OpenApiContact
            {
                Name = "NastyPad",
                Url = new Uri("https://www.google.com/")
            },
            License = new OpenApiLicense
            {
                Name = "NastyPad JoBit License",
                Url = new Uri("https://www.google.com/")
            }
        });
        options.EnableAnnotations();
    }
);

//ConnectionString to Database
// Instance ConnectionString
var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
);

// Lowercase Url's configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Dependency Injection
//--Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Add Automapper Configuration
builder.Services.AddAutoMapper(
    typeof(JoBit.API.JoBit.Mapping.ModelToResourceProfile),
    typeof(JoBit.API.JoBit.Mapping.ResourceToModelProfile),
    typeof(JoBit.API.Security.Mapping.ModelToResourceProfile),
    typeof(JoBit.API.Security.Mapping.ResourceToModelProfile)
);

//AppSettingsConfiguration
//builder.Services.Configure<AppSettings>()

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v2/swagger.json", "v2");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();