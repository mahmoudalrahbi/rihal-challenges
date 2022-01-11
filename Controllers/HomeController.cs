using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services.Interfaces;

namespace School.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStatisticsService _statisticsService ;


    public HomeController(ILogger<HomeController> logger, IStatisticsService statisticsService)
    {
        _logger = logger;
        _statisticsService = statisticsService;
    }

    public async Task<IActionResult> Index()
    {
       
        var sCounties = await _statisticsService.getStudetnsPerCountry();
        var sClass = await _statisticsService.getStudentsPerClassAsync();


        HomeSatatisticsViewModel viewModel = new HomeSatatisticsViewModel();
        viewModel.studentsPerCountries = sCounties;
        viewModel.studentsPerClasses = sClass;

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
