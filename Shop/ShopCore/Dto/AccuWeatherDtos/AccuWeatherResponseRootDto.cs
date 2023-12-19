
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Core.Dto.AccuWeather
{
    public class AccuWeatherResponseRoot
    {
        [JsonPropertyName("Headline")]
        public Headline Headline { get; set; }

        [JsonPropertyName("DailyForecasts")]
        public List<DailyForecast> DailyForecasts { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}