using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Data.Context;
using SchulungQotd.Mvc.Controllers;
using SchulungQotd.Mvc.Data;
using SchulungQotd.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//Identity
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//MVC
builder.Services.AddControllersWithViews();

//QotdContext
builder.Services.AddDbContext<QotdContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//DI
builder.Services.AddScoped<IQotdService, QotdService>();

var app = builder.Build();

// Configure the HTTP request pipeline. #############################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0];
//    await context.Response.WriteAsync("Erste Middleware\n" + userAgent);
//    await next();
//    await context.Response.WriteAsync("Erste Middleware Back\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Zweite Middleware\n");
//    await next();
//});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("End Middleware\n");
//});

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