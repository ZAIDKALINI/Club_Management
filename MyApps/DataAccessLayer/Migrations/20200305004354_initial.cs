using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Person_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    DateInscri = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Person_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Person_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    DateInscri = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Person_Id);
                });

            migrationBuilder.CreateTable(
                name: "CoachPayements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Payement_date = table.Column<DateTime>(nullable: false),
                    Person_Id = table.Column<int>(nullable: false),
                    CoachPerson_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachPayements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoachPayements_Coaches_CoachPerson_Id",
                        column: x => x.CoachPerson_Id,
                        principalTable: "Coaches",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPayements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Payement_date = table.Column<DateTime>(nullable: false),
                    Person_Id = table.Column<int>(nullable: false),
                    customerPerson_Id = table.Column<int>(nullable: true),
                    duration = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPayements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPayements_Customers_customerPerson_Id",
                        column: x => x.customerPerson_Id,
                        principalTable: "Customers",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachPayements_CoachPerson_Id",
                table: "CoachPayements",
                column: "CoachPerson_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayements_customerPerson_Id",
                table: "CustomerPayements",
                column: "customerPerson_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachPayements");

            migrationBuilder.DropTable(
                name: "CustomerPayements");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
