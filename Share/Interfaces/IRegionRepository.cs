using Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Interfaces
{
    public interface IRegionRepository
    {
        Region AddRegion(Region region);
        Region GetRegionById(int id);
        Region GetRegionByName(string name);
    }
}
