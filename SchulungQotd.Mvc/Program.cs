using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Mvc.Controllers;
using SchulungQotd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Db
builder.Services.AddDbContext<QotdContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//DInjection
builder.Services.AddScoped<IQotdService, QotdService>();

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//Startbeispiel Middleware ############################################################################################
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync(context.Request.Headers["User-Agent"][0]);
//    await next();
//    await context.Response.WriteAsync("First middleware Rückweg\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Second middleware\n");
//    await next();
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});
//Endbeispiel Middleware ##############################################################################################


// Configure the HTTP request pipeline. ###########################################################################
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  //localhost:5001/{ControllerName}/{ActionName}

app.Run();