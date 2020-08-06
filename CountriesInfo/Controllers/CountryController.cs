using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CountriesInfo.Interfaces;
using CountriesInfo.Services;
using Microsoft.AspNetCore.Mvc;
using Share.Models;

namespace CountriesInfo.Controllers
{
    public class CountryController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        readonly ICountryJSONService _countryJSONService;
        readonly ICountryService _countryService;
        public CountryController(ICountryJSONService countryJSONService, ICountryService countryService, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _countryJSONService = countryJSONService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Find(string name)
        {
            string uri = $"https://restcountries.eu/rest/v2/name/{name}";

            try
            {
                using var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();
                ViewBag.Countries = _countryJSONService.GetCountriesFromJSON(content);
            }
            catch (Exception)
            {
            }
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
