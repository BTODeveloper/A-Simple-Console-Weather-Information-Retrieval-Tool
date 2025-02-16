class Program
{
    static async Task Main(string[] args)
    {
        var weatherService = new WeatherService();

        while (true)
        {
            Console.Write("Enter latitude: ");
            var latitudeInput = Console.ReadLine();

            Console.Write("Enter longitude: ");
            var longitudeInput = Console.ReadLine();

            if (double.TryParse(latitudeInput, out double latitude) && double.TryParse(longitudeInput, out double longitude))
            {
                try
                {
                    var weatherInfo = await weatherService.GetWeatherAsync(latitude, longitude);
                    Console.WriteLine($"Weather information for latitude: {latitude}, longitude: {longitude}:");
                    Console.WriteLine($"- Temperature: {weatherInfo.Temperature}°C");
                    Console.WriteLine($"- Wind Speed: {weatherInfo.WindSpeed} m/s");
                    Console.WriteLine($"- Weather Code: {weatherInfo.WeatherCode}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid latitude or longitude. Please try again.");
            }

            Console.WriteLine();
        }
    }
}