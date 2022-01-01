using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Repistory;
using School.Repistory.Interfaces;
using School.Services;
using School.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcSchoolContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcSchoolContext")));

//add repistories
builder.Services.AddTransient<IClassRepository, ClassRepository>();


//add services
builder.Services.AddTransient<IClassService, ClassService>();



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
