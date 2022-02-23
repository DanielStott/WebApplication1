using NodaTime;

namespace WebApplication1;

public class WeatherRepository : IWeatherRepository
{
    private static Dictionary<string, WeatherForecast> _forecasts = new ();

    public WeatherForecast GetWeather(string city)
    {
        if (_forecasts.ContainsKey(city))
            return _forecasts[city];

        return new WeatherForecast();
    } 
    
    public void AddWeather(WeatherForecast weather)
    {
        if (_forecasts.ContainsKey(weather.City))
        {
            _forecasts[weather.City] = weather;
            return;
        }
        
        _forecasts.Add(weather.City, weather); 
    }

    public void RemoveCity(string city)
    {
        _forecasts.Remove(city);
    }

    public void Update(WeatherForecast weather)
    {
        if (_forecasts.ContainsKey(weather.City))
            _forecasts[weather.City] = weather;
        
        
    }
}

public interface IWeatherRepository
{
    public WeatherForecast GetWeather(string city);
    public void AddWeather(WeatherForecast weather);

    public void RemoveCity(string city);

    public void Update(WeatherForecast weather);
}