using Microsoft.EntityFrameworkCore;
using PavilionKyrpton.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.DatabaseConnection
{
    public class DbConnection : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)          
          => options.UseSqlite(ConfigurationManager.ConnectionStrings["database"].ConnectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        // => options.UseSqlite(@"Data Source=C:\Pavilion\capacitymgt.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnagasFile>()
                .HasOne(p => p.File)
                .WithMany(b => b.EnagasFiles)
                .HasForeignKey(p => p.FileId)
                .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<PrismaAuctionFile>()
              .HasOne(p => p.File)
              .WithMany(b => b.PrismaAuctionContracts)
              .HasForeignKey(p => p.FileId)
              .HasPrincipalKey(b => b.Id);

            modelBuilder.Entity<CapacityContract>()
                .HasKey(p => p.CapacityContractId);
        }

        public DbSet<User> Users { get; set; }
         
        public DbSet<FileClass> Files { get; set; }

        public DbSet<EnagasFile> EnagasFiles { get; set; }

        public DbSet<PrismaAuctionFile> prismaAuctionContracts { get; set; }

        public DbSet<CapacityContract> CapacityContracts { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
