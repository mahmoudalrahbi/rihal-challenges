using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Repistory;
using School.Repistory.Interfaces;
using School.Services;
using School.Services.Interfaces;
using School.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcSchoolContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcSchoolContext")));

//add repistories layer
builder.Services.AddTransient<IClassRepository, ClassRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();


//add services layer
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStatisticsService, StatisticsService>();
builder.Services.AddTransient<ISeedDataService, SeedDataService>();

//add DataSeeder 
builder.Services.AddTransient<DataSeeder>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

SeedData(app);


//Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}



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
