using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Business.Interfaces;
using TestTask.Business.Mapper;
using TestTask.Business.Services;
using TestTask.Data;
using TestTask.Data.Interfaces;
using TestTask.Data.Repositories;
using TestTask.Mapper;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IUserService, UserService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
    mc.AddProfile(new MapperProfileData());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
