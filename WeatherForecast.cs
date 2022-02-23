using NodaTime;

namespace WebApplication1;

public class WeatherForecast
{
    public string City { get; set; }

    public Instant Date { get; private set; }
    
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    public string? Summary { get; set; }
    
    public void SetTime(Instant Time)
    {
        Date = Time;
    }
}