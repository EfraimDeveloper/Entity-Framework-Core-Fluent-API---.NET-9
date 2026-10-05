using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products {  get; set; }

        public DbSet<sector> sectors { get; set; }
        public DbSet<Employee> employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;" +
                    "Database=FluentApidb;" +
                    "Trusted_Connection=True;" +
                    "TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p=> p.Description)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Databuy)
                .HasColumnType("Date");


            //=========client=============

            modelBuilder.Entity<Client>()
                .ToTable("ClientesEspeciais");

            modelBuilder.Entity<Client>()
                .HasKey(c=>c.code);

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.name);

            modelBuilder.Entity<Client>()
                .Property(p=> p.name)
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(p => p.Ativo)
                .HasDefaultValue(0);

            modelBuilder.Entity<Client>()
                .Property(p => p.DateTime)
                .HasColumnType("Date")
                .IsRequired();

            //modelBuilder.Entity<Client>().HasData(

            //    new Client
            //    {
            //        code = 1,
            //        name="Efraim Luis Marcelino",
            //        Email="Efradev@alicesoft",
            //        Ativo=0,
            //        DateTime=new DateTime(2002,01,01)
            //    }

            //    );


            modelBuilder.Entity<sector>()
                .HasMany(f => f.Employees)
                .WithOne(s => s.sector)
                .IsRequired();

        }
    }
}
