using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace KariHotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<OddServ> OddServ { get; set; }
        public DbSet<Fines> Fines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<OddServ>().ToTable("OddServ");
            modelBuilder.Entity<Fines>().ToTable("Fines");
        }
    }
}
