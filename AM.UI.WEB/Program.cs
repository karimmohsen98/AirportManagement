using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Service;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMvc();

//Dep Injection 

builder.Services.AddDbContext<DbContext, AMContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceFlight,ServiceFlight>();
builder.Services.AddScoped<IServicePlane, ServicePlane>();
builder.Services.AddScoped<IServiceTicket, ServiceTicket>();
builder.Services.AddScoped<IServicePassenger, ServicePassenger>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Plane}/{action=Index}/{id?}");

app.Run();
