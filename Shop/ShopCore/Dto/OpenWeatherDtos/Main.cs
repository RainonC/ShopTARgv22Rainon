using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feelslike")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("tempmin")]
        public double TempMin { get; set; }

        [JsonPropertyName("tempmax")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sealvl")]
        public int SeaLvl { get; set; }

        [JsonPropertyName("grndlvl")]
        public int GrndLvl { get; set; }


    }
}