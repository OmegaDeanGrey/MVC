using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public interface IMyApiService
{
    Task<MyApiResponse> GetApiDataAsync();
    Task<bool> CreateDataAsync(MyApiRequest request);
}

public class MyApiService : IMyApiService
{
    private readonly HttpClient _httpClient;

    public MyApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MyApiResponse> GetApiDataAsync()
    {
        var response = await _httpClient.GetAsync("https://api.example.com/data");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<MyApiResponse>(responseContent);
    }

    public async Task<bool> CreateDataAsync(MyApiRequest request)
    {
        var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.example.com/data", content);
        return response.IsSuccessStatusCode;
    }
}

public class MyApiResponse
{
    public string Data { get; set; }
}

public class MyApiRequest
{
    public string Data { get; set; }
}
