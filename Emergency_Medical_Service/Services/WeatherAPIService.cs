using Emergency_Medical_Service.Models;

namespace Emergency_Medical_Service.Services;

public class WeatherAPIService
{
    private readonly HttpClient _client;
    private readonly ILogger<WeatherAPIService> _logger;

    public WeatherAPIService(ILogger<WeatherAPIService> logger)
    {
        _client = new();

        _logger = logger;
    }

    private const string API_V1 = "https://goweather.herokuapp.com/weather/";

    public async Task<WeatherModel> Weather(string city)
    {
        city = "Hradec";

        try
        {
            return await _client.GetFromJsonAsync<WeatherModel>($"{API_V1}{city}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR: " + ex.Message);
        }

        return default;
    }
}