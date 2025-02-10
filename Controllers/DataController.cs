using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Liberation.Models;

namespace Liberation.Controllers;

public class DataController : Controller
{

        public IActionResult Analyze()
    {
        return View();
    }


        public IActionResult DataPing()
    {
        return View();
    }
}