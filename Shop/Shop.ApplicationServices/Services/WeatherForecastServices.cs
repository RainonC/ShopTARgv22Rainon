using Nancy.Json;
using ShopCore.Dto.OpenWeatherDtos;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpenWeather = "28ec33b097676366ceeb1f55bfead65e";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";

            using (WebClient client = new WebClient()) 
            {
                string json = client.DownloadString(url);
                OpenWeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<OpenWeatherResponseRootDto>(json);

                dto.City = weatherResult.Name;
                dto.Temp = weatherResult.Main.Temp;
                dto.feels_like = weatherResult.Main.FeelsLike;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weathers[0].Description;

            }


            return dto;
        }
    }
}
