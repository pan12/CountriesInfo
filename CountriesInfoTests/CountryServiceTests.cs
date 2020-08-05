using CountriesInfo.Services;
using NUnit.Framework;
using Share.Models;
using Share.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesInfoTests
{
    class CountryServiceTests
    {
        private CountryService _countryService;
        private CountryRepository _countryRepository;
        private CityRepository _cityRepository;
        private RegionRepository _regionRepository;
        
        [SetUp]
        public void Setup()
        {
            _countryService = new CountryService(_countryRepository, _cityRepository, _regionRepository);
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }
    }
}
