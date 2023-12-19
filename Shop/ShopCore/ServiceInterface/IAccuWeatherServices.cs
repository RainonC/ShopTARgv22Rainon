using Shop.Core.Dto.AccuWeather;

using ShopCore.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopCore.ServiceInterface
{
    public interface IAccuWeatherServices
    {
        Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);
        
    }
}
