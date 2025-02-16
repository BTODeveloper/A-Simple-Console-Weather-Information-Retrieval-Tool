using Newtonsoft.Json.Linq;
using RestSharp;

public class WeatherService
{
    private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";

    public async Task<WeatherInfo> GetWeatherAsync(double latitude, double longitude)
    {
        var client = new RestClient(BaseUrl);
        var request = new RestRequest($"?latitude={latitude}&longitude={longitude}&current_weather=true", Method.Get);
        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var json = JObject.Parse(response.Content);
            return new WeatherInfo
            {
                Temperature = json["current_weather"]["temperature"].Value<double>(),
                WindSpeed = json["current_weather"]["windspeed"].Value<double>(),
                WeatherCode = json["current_weather"]["weathercode"].Value<int>()
            };
        }

        throw new Exception($"Error fetching weather data: {response.ErrorMessage}");
    }
}