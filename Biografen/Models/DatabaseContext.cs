using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografen.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Administrator> administrators { get; set; }
        public DbSet<Movie> movies { get; set; } // tabel over Movie hvor at movies er tabellen
        public DbSet<CinemaHall> cinemaHalls { get; set; }
        public DbSet<CreateUser> createUsers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Show> shows { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Billings> billings { get; set; }
        public DbSet<Genre> genres { get; set; }

        //set execution-policy
    }
}
