using Nancy.Json;
using Shop.Core.Dto.AccuWeather;


using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Shop.ApplicationServices.Services
{
    public class AccuWeatherServices : IAccuWeatherServices
    {
        public async Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto)
        {
            string idAccuWeather = "Nk35AMRFptyxIpYnhcYxpgh0zjG8XgmL";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={idAccuWeather}&q={dto.City}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<AccuWeatherForecastDto> weatherResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherForecastDto>>(json);

                dto.Key = weatherResult[0].Citys[0].Key;
            }

            string idAccuWeather2 = "Nk35AMRFptyxIpYnhcYxpgh0zjG8XgmL";
            string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={idAccuWeather2}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url2);
                AccuWeatherResponseRoot forecastResult = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRoot>(json);

                dto.Minimum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value;
                dto.Maximum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value;
                dto.Link = forecastResult.DailyForecasts.FirstOrDefault().Link;
                dto.Text = forecastResult.Text;

            }

            return dto;
        }
    }

    
}





