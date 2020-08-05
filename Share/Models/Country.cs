using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Share.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }

        public int CapitalId { get; set; }
        [ForeignKey("CapitalId")]
        public City Capital { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }



        public CountryDTO Map()
        {
            return new CountryDTO
            {
                Name = this.Name,
                Code = this.Code,
                Area = this.Area,
                Population = this.Population,
                Capital = this.Capital.Name,
                Region = this.Region.Name
            };
        }
    }
}
