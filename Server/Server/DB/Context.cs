using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Server.Models;

namespace Server.DB
{
    public class Context : DbContext
    {
        public Context() : base("EhecDB") { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Salutation> Salutations{ get; set; }
        public DbSet<Strain> Strains { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}