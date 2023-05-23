namespace Emergency_Medical_Service.Models;

public class WeatherModel
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Forecast
    {
        public int Day { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
    }

    public class Root
    {
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Description { get; set; }
        public List<Forecast> Forecast { get; set; }
    }
}