using System.Reflection;
using Microsoft.OpenApi.Models;
using SchulungQotd.Data;
using SchulungQotd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Qotd API",
        Version = "v1",
        Description = "Das ist ein Webservice für Qotd",
        Contact = new OpenApiContact()
        {
            Name = "Admin",
            Email = "admin@example.com",
            Url = new Uri("https://www.example.com")
        }
    });

    var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
    options.IncludeXmlComments(xmlPath);
});

//QotdContext
builder.Services.AddQotdDataServicesRegistration(builder.Configuration);

//DI
builder.Services.AddScoped<IQotdService, QotdService>();



var app = builder.Build();

// Configure the HTTP request pipeline. ###########################################################
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
