 using Entities;
using Entities.Expenses;
using Entities.StatisticRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class App_Context:DbContext
    {
        public App_Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;DataBase=GymDB;Integrated Security=True");
           
        }
        //public App_Context(DbContextOptions Options) :base(Options)
        //{

        //}
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayement> CustomerPayements { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<CoachPayement> CoachPayements { get; set; }
        public virtual DbSet<Category_expense> Category_Expenses { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Assurance> Assurances { get; set; }
        public virtual DbSet<TypeAssurance> TypeAssurances { get; set; }
    
        
    }
} 
