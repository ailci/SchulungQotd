using SchulungQotd.Data;
using SchulungQotd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
