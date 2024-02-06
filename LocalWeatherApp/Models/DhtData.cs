namespace LocalWeatherApp.Models;

public class DhtData
{
    public string? Id { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
    public DateTime Timestamp { get; set; }
}