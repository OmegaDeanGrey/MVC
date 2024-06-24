using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Liberation.Models
{
    public interface IMyApiService
    {
        Task<PokemonApiResponse> GetApiDataAsync(string url = "https://pokeapi.co/api/v2/pokemon?limit=25");
    }

    public class MyApiService : IMyApiService
    {
        private readonly HttpClient _httpClient;

        public MyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonApiResponse> GetApiDataAsync(string url = "https://pokeapi.co/api/v2/pokemon?limit=25")
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<PokemonApiResponse>(responseContent);

            return apiResponse;
        }
    }

    public class PokemonApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResult> Results { get; set; }
    }

    public class PokemonResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
