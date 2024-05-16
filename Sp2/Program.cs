using Microsoft.EntityFrameworkCore;
using Sp2.Models;
using Sp2.Persistence;
using Sp2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext Oracle on the project
//builder.Services.AddDbContext<OracleDbContext>(options =>
//{
//    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
//});

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OracleDbContext>(o => o.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
