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


        public Country SaveCountry(CountryDTO countryDTO)
        {
            Country country = new Country
            {
                Name = countryDTO.Name,
                Code = countryDTO.Code,
                Area = countryDTO.Area,
                Population = countryDTO.Population,

                Capital = new City { Name = countryDTO.Capital },
                Region = new Region { Name = countryDTO.Region }
            };
            var capital = FindCityInDB(country.Capital.Name);
            if (capital == null)
                capital = _cityRepository.AddCity(country.Capital);
            country.CapitalId = capital.Id;
            country.Capital = capital;

            var region = FindRegionInDB(country.Region.Name);
            if (region == null)
                region = _regionRepository.AddRegion(country.Region);
            country.RegionId = region.Id;
            country.Region = region;

            var countryInDB = FindCountryInDB(country.Code);
            if(countryInDB == null)
            {
                return _countryRepository.AddCountry(country);
            }
            else
            {
                return _countryRepository.UpdateCountry(countryInDB);
            }

        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            var countries = _countryRepository.GetAllCountries().ToList();
            IEnumerable<CountryDTO> countriesDTO = new List<CountryDTO>();
            foreach (Country country in countries)
            {
                country.Capital = _cityRepository.GetCityById(country.CapitalId);
                country.Region = _regionRepository.GetRegionById(country.RegionId);
                countriesDTO = countriesDTO.Append(country.Map());
            }
            return countriesDTO;
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
