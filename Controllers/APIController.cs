using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Liberation.Models;
using System.Diagnostics;

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
        public async Task<IActionResult> Index()
        {
            var data = await _myApiService.GetApiDataAsync();
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
        return StatusCode(500); // Internal Server Error
    }
}
    }
}
