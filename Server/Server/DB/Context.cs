using System.Data.Entity;
using Server.Models;
using Server.Helper;

namespace Server.DB
{
    public class Context : DbContext
    {
        public Context() : base("EhecDB") { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Salutation> Salutations{ get; set; }
        public DbSet<Strain> Strains { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FoodPlace> FoodPlaces { get; set; }
        public DbSet<PatientAtFoodPlace> PatientAtFoodPlaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salutation>()
                .Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<Strain>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<Gender>()
                .Property(g => g.Name)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<City>()
                .Property(c => c.ZipCode)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<City>()
               .HasRequired(c => c.Country)
               .WithMany()
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .Property(e => e.Date)
                .IsRequired();

            modelBuilder.Entity<Exam>()
                .Property(e => e.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Exam>()
                .HasRequired(e => e.Doctor)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .HasRequired(e => e.Patient);

            modelBuilder.Entity<Exam>()
                .HasRequired(e => e.Strain);

            modelBuilder.Entity<PatientAtFoodPlace>()
                .HasKey(pf => new { pf.PatientID, pf.FoodPlaceID });

            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

             modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

              modelBuilder.Entity<Person>()
                .Property(p => p.StreetName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .HasRequired(p => p.Gender);

            modelBuilder.Entity<Person>()
                .HasRequired(p => p.City)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany<PatientAtFoodPlace>(p => p.PatientAtFoodPlaces)
                .WithRequired()
                .HasForeignKey(p => p.PatientID);

            modelBuilder.Entity<FoodPlace>()
                .Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnique();

            modelBuilder.Entity<FoodPlace>()
                .Property(f => f.Streetname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<FoodPlace>()
                .Property(f => f.Streetnumber)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<FoodPlace>()
                .Property(f => f.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<FoodPlace>()
                .HasRequired(f => f.City)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodPlace>()
                .HasMany<PatientAtFoodPlace>(f => f.PatientAtFoodPlaces)
                .WithRequired()
                .HasForeignKey(f => f.FoodPlaceID);
        }
    }
}