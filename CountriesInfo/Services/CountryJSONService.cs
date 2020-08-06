using CountriesInfo.Interfaces;
using Newtonsoft.Json.Linq;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesInfo.Services
{
    public class CountryJSONService : ICountryJSONService
    {
        public IEnumerable<CountryDTO> GetCountriesFromJSON(string content)
        {
            IEnumerable<CountryDTO> countries = new List<CountryDTO>();

            JArray jArray = JArray.Parse(content);
            foreach(JToken jToken in jArray)
            {
                CountryDTO country = new CountryDTO();
                country.Name = (string)jToken["name"];
                country.Capital = (string)jToken["capital"];
                country.Population = (int)jToken["population"];
                country.Region = (string)jToken["region"];
                country.Area = (double)jToken["area"];
                country.Code = (string)jToken["numericCode"];
                countries = countries.Append(country);
            }

            return countries;

        }

    }
}
