﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(App_Context))]
    [Migration("20200308005310_updateExp2")]
    partial class updateExp2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Coach", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInscri")
                        .HasColumnType("datetime2");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person_Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("Entities.CoachPayement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachPerson_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Payement_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Person_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachPerson_Id");

                    b.ToTable("CoachPayements");
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInscri")
                        .HasColumnType("datetime2");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Person_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.CustomerPayement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Payement_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Person_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("customerPerson_Id")
                        .HasColumnType("int");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("customerPerson_Id");

                    b.ToTable("CustomerPayements");
                });

            modelBuilder.Entity("Entities.Expenses.Category_expense", b =>
                {
                    b.Property<int>("Id_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name_Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Category");

                    b.ToTable("Category_Expenses");
                });

            modelBuilder.Entity("Entities.Expenses.Expense", b =>
                {
                    b.Property<int>("Id_Expense")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Category")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("categoryId_Category")
                        .HasColumnType("int");

                    b.HasKey("Id_Expense");

                    b.HasIndex("categoryId_Category");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Entities.CoachPayement", b =>
                {
                    b.HasOne("Entities.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachPerson_Id");
                });

            modelBuilder.Entity("Entities.CustomerPayement", b =>
                {
                    b.HasOne("Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerPerson_Id");
                });

            modelBuilder.Entity("Entities.Expenses.Expense", b =>
                {
                    b.HasOne("Entities.Expenses.Category_expense", "category")
                        .WithMany()
                        .HasForeignKey("categoryId_Category");
                });
#pragma warning restore 612, 618
        }
    }
}
