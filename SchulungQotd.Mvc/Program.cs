using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Mvc.Controllers;
using SchulungQotd.Mvc.Data;
using SchulungQotd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//MVC
builder.Services.AddControllersWithViews();

//QotdContext
builder.Services.AddDbContext<QotdContext>(options => options.UseSqlServer(connectionString));

//QotdService
builder.Services.AddScoped<IQotdService, QotdService>();
builder.Services.AddKeyedScoped<IQotdService, FakeQotdService>("fakeService");

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//Startbeispiel Middleware ############################################################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"];
//    await context.Response.WriteAsync($"First middleware {userAgent}\n");
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

// Configure the HTTP request pipeline. ##############################################################################
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
