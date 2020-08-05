using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Share.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }

        public Region()
        {
            Countries = new List<Country>();
        }
    }


}
