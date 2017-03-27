using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.DatabaseContext {
    public class VANContext : DbContext {

        public VANContext() : base("Name=DBConnectionString") {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FrequentlyOpen> FrequentlyOpens { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<OpenHoursException> OpenHoursExceptions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Typ> Typs { get; set; }

    }
}