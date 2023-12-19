using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Shop.Core.Dto.AccuWeather
{
    public class AccuWeatherResultDto
    {


        public string City { get; set; }
        public string Key { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string Link { get; set; }

        public string Text { get; set; }




    }



}
