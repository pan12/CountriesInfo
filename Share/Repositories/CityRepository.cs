using Share.Interfaces;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Repositories
{
    public class CityRepository : ICitiyRepository
    {
        private Context _dbContext;
        public CityRepository(Context context)
        {
            _dbContext = context;
        }

        public City AddCity(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();
            return city;
        }

        public City GetCityById(int id)
        {
            return _dbContext.Cities.Find(id);
        }

        public City GetCityByName(string name)
        {
            return _dbContext.Cities.FirstOrDefault(c => c.Name == name);
        }
    }
}
