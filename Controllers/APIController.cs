using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Liberation.Models;

namespace Liberation.Controllers
{
    public class APIController : Controller
    {
        private readonly IMyApiService _myApiService;
        private readonly HttpClient _httpClient;

        public APIController(IMyApiService myApiService, HttpClient httpClient)
        {
            _myApiService = myApiService;
            _httpClient = httpClient;
        }

        // GET: API/Index
        public async Task<IActionResult> Index(int limit = 25, int offset = 0)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon?limit={limit}&offset={offset}";
            var data = await _myApiService.GetApiDataAsync(url);

            ViewBag.Limit = limit;
            ViewBag.Offset = offset;
            ViewBag.NextOffset = offset + limit;
            ViewBag.PreviousOffset = offset - limit < 0 ? 0 : offset - limit;

            return View(data);
        }

        // GET: API/ById
        public IActionResult ById()
        {
            return View();
        }

        // POST: API/ById
        [HttpPost]
        public async Task<IActionResult> ById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var pokemonDetail = JsonConvert.DeserializeObject<PokemonDetail>(content);

                if (pokemonDetail == null)
                {
                    return NotFound();
                }

                return View(pokemonDetail);
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, ex); // Internal Server Error
            }
        }

        // POST: API/ByName
        [HttpPost]
        public async Task<IActionResult> ByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Pokemon name is required.");
            }

            var pokemonDetails = await _myApiService.GetPokemonByNameAsync(name.Trim());
            if (pokemonDetails == null)
            {
                return NotFound();
            }
            Console.WriteLine(JsonConvert.SerializeObject(pokemonDetails));

            // Pass the front_default sprite URL to the view
        ViewData["FrontDefaultSprite"] = pokemonDetails.PokemonSprites.Front_default;

            return View("ByName", pokemonDetails);
        }
    }
}
