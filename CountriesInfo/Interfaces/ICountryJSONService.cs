using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesInfo.Interfaces
{
    public interface ICountryJSONService
    {
        public IEnumerable<CountryDTO> GetCountriesFromJSON(string content);
    }
}
