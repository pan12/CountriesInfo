﻿using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesInfo.Interfaces
{
    public interface ICountryService
    {
        public Country SaveCountry(CountryDTO country);
        public IEnumerable<CountryDTO> GetAllCountries();
    }
}
