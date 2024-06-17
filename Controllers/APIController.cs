using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Liberation.Controllers
{
public class APIController : Controller
    {
        private readonly IMyApiService _myApiService;

        public APIController(IMyApiService myApiService)
        {
            _myApiService = myApiService;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var data = await _myApiService.GetApiDataAsync();
            return View(data);
        }

        // POST: Home/Create
        [HttpPost]
        public async Task<IActionResult> Create(MyApiRequest request)
        {
            var result = await _myApiService.CreateDataAsync(request);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }
    }
}