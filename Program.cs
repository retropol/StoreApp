using DataLayer.Abstract;
using DataLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using WebLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConneciton"], b=>b.MigrationsAssembly("WebLayer"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>(); // burayı sor
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseStaticFiles();
app.UseSession();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "products_in_category",
    pattern: "products/{category?}",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "product_details",
    pattern: "{name}",
    defaults: new { controller = "Home", action = "Details" });


app.MapRazorPages();    

app.Run();
