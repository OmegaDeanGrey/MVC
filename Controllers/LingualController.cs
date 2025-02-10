using Liberation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Liberation.Controllers
{
    public class LingualController : Controller
    {
        public IActionResult Python()
        {
            return View();
        }

        public IActionResult JS()
        {
            return View();
        }

            public IActionResult CSharp()
        {
            return View();
        }

            public IActionResult Typescript()
        {
            return View();
        }
    }}