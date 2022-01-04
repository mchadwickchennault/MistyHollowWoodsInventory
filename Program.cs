using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MistyHollowWoodsInventory.Data;

var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<misty_hollowContext>(options =>
{
    options.UseMySQL(config["DevwickConnection"]);
});

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
    pattern: "{controller=Bowls}/{action=Index}/{id?}");

app.Run();
