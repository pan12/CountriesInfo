using CountriesInfo.Services;
using NUnit.Framework;
using Share.Models;
using Share.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountriesInfoTests
{
    class CountryAPIServiceTests
    {
        private CountryAPIService _countryService;
        public IHttpClientFactory _httpClientFactory;

        CountryDTO _testCountryDTO = new CountryDTO
        {
            Name = "Russian Federation",
            Capital = "Moscow",
            Region = "Europe",
            Population = 146599183,
            Area = 17124442,
            Code = "643"
        };

        [SetUp]
        public void Setup()
        {
            _countryService = new CountryAPIService(_httpClientFactory);
        }

        [Test]
        public void GetFromJSON()
        {
            var countries = _countryService.GetCountriesFromJSON
                (File.ReadAllText(@"C:\Users\pan12\source\repos\CountriesInfo\CountriesInfoTests\CountriesJSON.txt"));
            var country = countries.FirstOrDefault();
            Assert.IsTrue
                (_testCountryDTO.Area == country.Area &&
                _testCountryDTO.Capital == country.Capital &&
                _testCountryDTO.Code == country.Code &&
                _testCountryDTO.Name == country.Name &&
                _testCountryDTO.Population == country.Population &&
                _testCountryDTO.Region == country.Region
                );
        }
    }
}
