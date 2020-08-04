using Share.Interfaces;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _dbContext;
        public RegionRepository(Context context)
        {
            _dbContext = context;
        }

        public Region AddRegion(Region region)
        {
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();
            return region;
        }

        public Region GetRegionById(int id)
        {
            return _dbContext.Regions.Find(id);
        }

        public Region GetRegionByName(string name)
        {
            return _dbContext.Regions.FirstOrDefault(r => r.Name == name);
        }
    }
}
