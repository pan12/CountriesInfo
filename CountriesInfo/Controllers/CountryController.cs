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
        public CountryController(CountryAPIService countryAPIService, ICountryService countryService)
        {
            _countryAPIService = countryAPIService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Find(string name)
        {
            ViewBag.Countries = await _countryAPIService.GetCountriesFromAPIAsync(name);
            return View();
        }

        public IActionResult Saved()
        {
            ViewBag.Countries = _countryService.GetAllCountries();
            return View();
        }

        public IActionResult SaveCountry(CountryDTO country)
        {
            _countryService.SaveCountry(country);
            return Redirect("find");
        }
    }
}
