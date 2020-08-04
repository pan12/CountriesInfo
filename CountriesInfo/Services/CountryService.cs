using CountriesInfo.Interfaces;
using Share.Interfaces;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesInfo.Services
{
    public class CountryService : ICountryService
    {
        readonly ICountryRepository _countryRepository;
        readonly ICitiyRepository _cityRepository;
        readonly IRegionRepository _regionRepository;

        public CountryService(ICountryRepository countryRepository, 
            ICitiyRepository citiyRepository, IRegionRepository regionRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = citiyRepository;
            _regionRepository = regionRepository;
        }


        public Country SaveCountry(Country country)
        {
            var capital = FindCityInDB(country.Capital.Name);
            if (capital == null)
                capital = _cityRepository.AddCity(country.Capital);
            country.CapitalId = capital.Id;

            var region = FindRegionInDB(country.Region.Name);
            if (region == null)
                region = _regionRepository.AddRegion(country.Region);
            country.RegionId = region.Id;

            country = FindCountryInDB(country.Code);
            if(country == null)
            {
                return _countryRepository.AddCountry(country);
            }
            else
            {
                return _countryRepository.UpdateCountry(country);
            }

        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries().AsEnumerable();
        }

        private City FindCityInDB(string name)
        {
            return _cityRepository.GetCityByName(name);
        }

        private Region FindRegionInDB(string name)
        {
            return _regionRepository.GetRegionByName(name);
        }

        private Country FindCountryInDB(string code)
        {
            return _countryRepository.GetCountries(c => c.Code == code).FirstOrDefault();
        }
    }
}
