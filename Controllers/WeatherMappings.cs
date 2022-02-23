using AutoMapper;

namespace WebApplication1.Controllers;

public class WeatherMappings : Profile
{
    public WeatherMappings()
    {
        CreateMap<WeatherForecast, WeatherForecastViewModel>()
            .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToDateTimeUtc().ToString()));
    }
}