using Entities;
using Entities.Expenses;
using Entities.Portfolio;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class App_Context:IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<UserCutomer>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Customer>().Property(x => x.Person_Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<CustomerPayement>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Coach>().Property(x => x.Person_Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Category_expense>().Property(x => x.Id_Category).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Expense>().Property(x => x.Id_Expense).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Portfolio>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                
            }
        }
        public App_Context(DbContextOptions Options) : base(Options)
        {
          
        }
        

        public override Int32 SaveChanges()
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayement> CustomerPayements { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }

        public virtual DbSet<Category_expense> Category_Expenses { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
  
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<UserCutomer> userCutomers { get; set; }
   



    }
} 
