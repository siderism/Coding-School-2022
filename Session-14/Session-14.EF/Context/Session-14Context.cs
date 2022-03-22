using Microsoft.EntityFrameworkCore;
using Session_14.EF.Configuration;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Context
{
    public class Session_14Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ServiceTask> ServiceTasks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionLine> TransactionLines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new EngineerConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTaskConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionLineConfiguration());
            modelBuilder.Entity<Manager>().Ignore(m => m.FullName);
            modelBuilder.Entity<Engineer>().Ignore(e => e.Name);
            modelBuilder.Entity<Customer>().Ignore(c => c.Name);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Session-14;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionBuilder.UseSqlServer(connectionString);
        }
    }
}
