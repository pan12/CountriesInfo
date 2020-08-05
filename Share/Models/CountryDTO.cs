using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Models
{
    public class CountryDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }

        public override bool Equals(object obj)
        {
            if (this.Area == ((CountryDTO)obj).Area &&
                this.Capital == ((CountryDTO)obj).Capital &&
                this.Code == ((CountryDTO)obj).Code &&
                this.Name == ((CountryDTO)obj).Name &&
                this.Population == ((CountryDTO)obj).Population &&
                this.Region == ((CountryDTO)obj).Region)
            { return true; }
            else
            { return false; }
        }
    }
}
