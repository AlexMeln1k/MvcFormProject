using Microsoft.EntityFrameworkCore;
using MvcFormProject.Models;

namespace MvcFormProject.OtherClasses
{
    public class MvcProjDbContext : DbContext
    {
        public MvcProjDbContext(DbContextOptions<MvcProjDbContext> options): base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<SalesLogs> SalesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<SalesLogs>().ToTable("SalesLogs");
            base.OnModelCreating(modelBuilder);
        }
    }
}
