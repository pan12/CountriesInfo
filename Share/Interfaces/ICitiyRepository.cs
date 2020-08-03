using Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Interfaces
{
    public interface ICitiyRepository
    {
        City AddCity(City city);
        City GetCityById(int id);
        City GetCityByName(string name);
    }
}
