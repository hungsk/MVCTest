using GenericServices.Setup;
using Microsoft.EntityFrameworkCore;
using MVCTest.DataAccess.Data;
using MVCTest.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//高手-單DB
builder.Services.GenericServicesSimpleSetup<ApplicationDbContext>(
   Assembly.GetAssembly(typeof(Category)));
//高手-多DB
//builder.Services.ConfigureGenericServicesEntities(typeof(BookDbContext), typeof(OrderDbContext))
//    .ScanAssemblesForDtos(Assembly.GetAssembly(typeof(BookListDto)))
//    .RegisterGenericServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
