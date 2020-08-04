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

        public async Task<IEnumerable<Country>> GetCountriesFromAPIAsync(string name)
        {
            string uri = $"https://restcountries.eu/rest/v2/name/{name}";

            IEnumerable<Country> countries = new List<Country>();
            try
            {
                using var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();

                content = content.Trim('[', ']');
                string[] countriesJSON = content.Split("{\"name\"", StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in countriesJSON)
                {
                    var str = String.Concat("{\"name\"", s);
                    str = str.Trim(',');
                    Country country = new Country
                    {
                        Capital = new City(),
                        Region = new Region()
                    };

                    JObject jObject = JObject.Parse(str);
                    country.Name = (string)jObject["name"];
                    country.Capital.Name = (string)jObject["capital"];
                    country.Population = (int)jObject["population"];
                    country.Region.Name = (string)jObject["region"];
                    country.Area = (double)jObject["area"];
                    country.Code = (string)jObject["numericCode"];

                    countries = countries.Append(country);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return countries;
        }
    }
}
