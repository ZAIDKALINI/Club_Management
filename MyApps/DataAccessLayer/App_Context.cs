using Entities;
using Entities.Expenses;
using Entities.Portfolio;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class App_Context:IdentityDbContext<ApplicationUser>
    {
        //public App_Context()
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;DataBase=GymDB;Integrated Security=True");
        //}
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
        public virtual DbSet<CoachPayement> CoachPayements { get; set; }
        public virtual DbSet<Category_expense> Category_Expenses { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Assurance> Assurances { get; set; }
        public virtual DbSet<TypeAssurance> TypeAssurances { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Owner> Owner { get; set; }
   



    }
} 
