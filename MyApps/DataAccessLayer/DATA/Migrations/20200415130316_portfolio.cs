using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class portfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "CustomerPayements");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "CustomerPayements");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "CustomerPayements");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "CoachPayements");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "CoachPayements");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "CoachPayements");

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Profil = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "CustomerPayements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "CustomerPayements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "CustomerPayements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "CoachPayements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "CoachPayements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "CoachPayements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
