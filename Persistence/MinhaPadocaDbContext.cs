using Microsoft.EntityFrameworkCore;
using MinhaPadoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Persistence
{
    public class MinhaPadocaDbContext :DbContext
    {
        public MinhaPadocaDbContext(DbContextOptions<MinhaPadocaDbContext> options) : base(options)
        {
        }

        public DbSet<Bakery> Bakeries { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bakery>(p =>
            {
                p.ToTable("Bakery");
                p.HasKey(p => p.Id);
                p.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                p.HasOne(pr => pr.Address)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Address>(a =>
            {
                a.ToTable("Address");
                a.HasKey(ad => ad.Id);
                a.Property(ad => ad.Street)
                    .HasMaxLength(50)
                    .IsRequired(); 
                a.Property(ad => ad.ZipCode)
                    .HasMaxLength(9)
                    .IsRequired();
                a.Property(ad => ad.Complement)
                    .HasMaxLength(50);
                a.Property(ad => ad.Neighborhood)
                    .HasMaxLength(50)
                    .IsRequired();
                a.Property(ad => ad.City)
                    .HasMaxLength(50)
                    .IsRequired();
                a.Property(ad => ad.State)
                    .HasMaxLength(2)
                    .IsRequired();
                a.Property(ad => ad.Number)
                    .IsRequired();
            });
            
        }
    }
}