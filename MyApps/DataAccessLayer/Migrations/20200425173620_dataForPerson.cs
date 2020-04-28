using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class dataForPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ref",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Ref",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Coaches");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genre",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Coaches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Coaches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Coaches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genre",
                table: "Coaches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Coaches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Coaches");

            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
