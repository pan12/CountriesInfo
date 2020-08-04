using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesInfo.Interfaces;
using CountriesInfo.Services;
using Microsoft.AspNetCore.Mvc;
using Share.Models;

namespace CountriesInfo.Controllers
{
    public class CountryController : Controller
    {
        readonly CountryAPIService _countryAPIService;
        readonly ICountryService _countryService;
        public CountryController(CountryAPIService countryAPIService)
        {
            _countryAPIService = countryAPIService;
        }

        [HttpGet]
        public async Task<IActionResult> FindCountry(string name)
        {
            ViewBag.Countries = await _countryAPIService.GetCountriesFromAPIAsync(name);
            return View();
        }

        [HttpPost]
        public IActionResult SaveCountry(Country country)
        {
            _countryService.SaveCountry(country);
            return View();
        }
    }
}
