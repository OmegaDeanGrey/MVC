using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Liberation.Models
{
    public interface IMyApiService
    {
        Task<PokemonApiResponse> GetApiDataAsync(string url = "https://pokeapi.co/api/v2/pokemon?limit=25&offset=25");
        Task<PokemonDetail> GetPokemonByNameAsync(string name);

    }

    public class MyApiService : IMyApiService
    {
        private readonly HttpClient _httpClient;

        public MyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonApiResponse> GetApiDataAsync(string url = "https://pokeapi.co/api/v2/pokemon?limit=25&offset=25")
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<PokemonApiResponse>(responseContent);


            return apiResponse;
        }
         public async Task<PokemonDetail> GetPokemonByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pokemonDetail = JsonConvert.DeserializeObject<PokemonDetail>(content);
                return pokemonDetail;
            }
            return null;
        }
    }

    public class PokemonApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; } = string.Empty;
        public string Previous { get; set; } = string.Empty;
        public List<PokemonResult> Results { get; set; }  = new List<PokemonResult>();
    }

    public class PokemonResult
    {
        public string Name { get; set; } = string.Empty; 
        public string Url { get; set; } = string.Empty; 
    }

  
}
