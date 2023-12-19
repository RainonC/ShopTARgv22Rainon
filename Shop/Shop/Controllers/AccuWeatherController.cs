using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto.AccuWeather;
using Shop.Models.AccuWeathers;
using ShopCore.ServiceInterface;


namespace Shop.Controllers
{
    public class AccuWeatherController : Controller
    {
        private readonly IAccuWeatherServices _accuweatherServices;


        public AccuWeatherController(IAccuWeatherServices accuWeatherServices)
        {
            _accuweatherServices = accuWeatherServices;
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeather", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {

            AccuWeatherResultDto dto = new AccuWeatherResultDto();


            dto.City = city;

            _accuweatherServices.AccuWeatherResult(dto);



            AccuWeatherViewModel vm = new AccuWeatherViewModel
            {

                City = dto.City,

                Minimum = dto.Minimum,
                Maximum = dto.Maximum,
                Link = dto.Link,

            };


            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }

}
