using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Share.Interfaces
{
    public interface ICountryRepository
    {
        Country AddCountry(Country country);
        IQueryable<Country> GetCountries(Expression<Func<Country, bool>> predicate);
    }
}
