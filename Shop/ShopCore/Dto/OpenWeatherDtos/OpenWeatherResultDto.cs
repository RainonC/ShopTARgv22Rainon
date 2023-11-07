using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto.OpenWeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string City { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public int WeatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Base { get; set; }
        public double Temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }
        public double WindDeg { get; set; }
        public int CloudsAll { get; set; }
        public int dt { get; set; }
        public int SysType { get; set; }
        public int SysId { get; set; }
        public string SysCountry { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public int TimeZone { get; set; }
        public int TimeInt { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

    }
}
