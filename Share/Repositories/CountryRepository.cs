using Share.Interfaces;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Share.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private Context _dbContext;
        public CountryRepository(Context context)
        {
            _dbContext = context;
        }

        public Country AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return country;
        }

        public Country UpdateCountry(Country country)
        {
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
            return country;
        }
        public IQueryable<Country> GetCountries(Expression<Func<Country, bool>> predicate)
        {
            return _dbContext.Countries.Where(predicate);
        }

        public IQueryable<Country> GetAllCountries()
        {
            return _dbContext.Countries;
        }
    }
}
