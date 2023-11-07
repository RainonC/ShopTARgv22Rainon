using ShopCore.Dto.OpenWeatherDtos;


namespace ShopCore.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
