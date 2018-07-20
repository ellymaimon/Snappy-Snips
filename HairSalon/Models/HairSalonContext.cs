using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
    public class HairSalonContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<StylistClient> StylistClients { get; set; }
        public virtual DbSet<StylistSpecialty> StylistSpecialties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=eliran_maimon;uid=root;pwd=root;");
        }
    }
}