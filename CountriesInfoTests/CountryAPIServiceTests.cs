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
        CountryDTO _testThreeCountryDTO = new CountryDTO
        {
            Name = "Guatemala",
            Capital = "Guatemala City",
            Region = "Americas",
            Population = 16176133,
            Area = 108889,
            Code = "320"
        };


        [SetUp]
        public void Setup()
        {
            _countryService = new CountryAPIService(_httpClientFactory);
        }

        [Test]
        public void GetFromJSONOneCountry()
        {
            var countries = _countryService.GetCountriesFromJSON
                (File.ReadAllText(@"C:\Users\pan12\source\repos\CountriesInfo\CountriesInfoTests\CountriesJSON.txt"));
            Assert.IsTrue(countries.Count() == 1);
            Assert.AreEqual(_testCountryDTO, countries.FirstOrDefault());
        }

        [Test]
        public void GetFromJSONThreeCountry()
        {
            var countries = _countryService.GetCountriesFromJSON
                (File.ReadAllText(@"C:\Users\pan12\source\repos\CountriesInfo\CountriesInfoTests\ThreeCountriesJSON.txt"));
            Assert.IsTrue(countries.Count() == 3);
            Assert.AreEqual(_testThreeCountryDTO, countries.FirstOrDefault());
        }

        [Test]
        public void GetFromJSONEmpty()
        {
            var countries = _countryService.GetCountriesFromJSON("[]");
            Assert.IsTrue(countries.Count()==0);
        }
    }
}
