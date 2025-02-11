using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Liberation.Models;

namespace Liberation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

        public IActionResult Index()
    {
        return View();
    }

    public IActionResult Notes()
    {
        return View();
    }

    public IActionResult Liberation()
    {
        return View(); 
    }

       public IActionResult Auth()
    {
        return View(); 
    }

           public IActionResult API()
    {
        return View();
    }

     public IActionResult Audible()
    {
        return View();
    }

               public IActionResult Lingual()
    {
        return View();
    }

                   public IActionResult Data()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
