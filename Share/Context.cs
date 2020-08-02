using Microsoft.EntityFrameworkCore;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share
{
    public class Context : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public Context(DbContextOptions<Context> options) : base (options)
        {
        }
    }
}
