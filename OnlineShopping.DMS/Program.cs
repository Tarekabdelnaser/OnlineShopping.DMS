
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShopping.DMS.Data;
using OnlineShopping.DMS.Models.ViewModels;
using OnlineShopping.DMS.Repo.Repositories;
using OnlineShopping.DMS.Services.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));

});

builder.Services.AddScoped<IItemRepository, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<ITaxRepository, TaxService>();
builder.Services.AddScoped<ICustomerRepository, CustomerService>();
builder.Services.AddScoped<IDiscount, DiscountService>();
builder.Services.AddScoped<IUnitOfMeasureRepo, UnitOfMeasureService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ShopDbContext>();



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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();




