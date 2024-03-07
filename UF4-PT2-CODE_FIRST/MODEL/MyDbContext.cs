using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UF4_PT2_CODE_FIRST.MODEL;

namespace UF4_PT2_CODE_FIRST
{
    public class MyDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;Database=shop;Uid=root;Pwd=\"\"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeCode);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Reports)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.SalesRep)
                .WithMany(e => e.Customers)
                .HasForeignKey(c => c.SalesRepEmployeeNumber);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerNumberId);

            modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderNumber, od.ProductCode });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderNumber);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductCode);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductLineNavigation)
                .WithMany(pl => pl.Products)
                .HasForeignKey(p => p.ProductLineId);

            modelBuilder.Entity<Payment>()
                .HasKey(p => new { p.CustomerNumber, p.CheckNumber });

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerNumber);
        }
    }

}
