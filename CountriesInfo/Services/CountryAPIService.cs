using Newtonsoft.Json.Linq;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesInfo.Services
{
    public class CountryAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<CountryDTO>> GetCountriesFromAPIAsync(string name)
        {
            string uri = $"https://restcountries.eu/rest/v2/name/{name}";

            try
            {
                using var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();
                return GetCountriesFromJSON(content);
            }
            catch (Exception)
            {
                return null;
            }
        }


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
