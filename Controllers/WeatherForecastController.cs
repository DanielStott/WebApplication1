using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace WebApplication1.Controllers;

[ApiController]
[Route("WeatherForecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherRepository _weatherRepository;
    private readonly IClock _clockTime;
    private readonly IMapper _mapper;
    
    public WeatherForecastController(IWeatherRepository weatherRepository, IClock clockTime, IMapper mapper)
    {
        _weatherRepository = weatherRepository;
        _clockTime = clockTime;
        _mapper = mapper;
    }
    

    [HttpGet("{city}")]
    public ActionResult<WeatherForecastViewModel> Get(string city)
    {
        var weather = _weatherRepository.GetWeather(city);
        
        var weatherForecastViewmodel = _mapper.Map<WeatherForecastViewModel>(weather);

        return weatherForecastViewmodel;
    }
    
    [HttpPost]
    public ActionResult<WeatherForecastViewModel> Create([FromBody] WeatherForecast weatherForecast)
    {
        var time = _clockTime.GetCurrentInstant();

        weatherForecast.SetTime(time);
        
        _weatherRepository.AddWeather(weatherForecast);

        var weatherForecastViewmodel = _mapper.Map<WeatherForecastViewModel>(weatherForecast);
        
        return weatherForecastViewmodel;
    }

    [HttpDelete("{city}")]
    public ActionResult Delete(string city)
    {
        _weatherRepository.RemoveCity(city);
        return Ok();
    }

    [HttpPut]
    public ActionResult<WeatherForecastViewModel> Put([FromBody] WeatherForecast weatherForecast)
    {
        _weatherRepository.Update(weatherForecast);
        
        var weatherForecastViewmodel = _mapper.Map<WeatherForecastViewModel>(weatherForecast);
        
        return weatherForecastViewmodel;
    }
}