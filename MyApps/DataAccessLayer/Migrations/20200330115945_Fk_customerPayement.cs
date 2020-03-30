using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Fk_customerPayement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayements_Customers_customerPerson_Id",
                table: "CustomerPayements");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayements_customerPerson_Id",
                table: "CustomerPayements");

            migrationBuilder.DropColumn(
                name: "customerPerson_Id",
                table: "CustomerPayements");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayements_Person_Id",
                table: "CustomerPayements",
                column: "Person_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayements_Customers_Person_Id",
                table: "CustomerPayements",
                column: "Person_Id",
                principalTable: "Customers",
                principalColumn: "Person_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayements_Customers_Person_Id",
                table: "CustomerPayements");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayements_Person_Id",
                table: "CustomerPayements");

            migrationBuilder.AddColumn<int>(
                name: "customerPerson_Id",
                table: "CustomerPayements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayements_customerPerson_Id",
                table: "CustomerPayements",
                column: "customerPerson_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayements_Customers_customerPerson_Id",
                table: "CustomerPayements",
                column: "customerPerson_Id",
                principalTable: "Customers",
                principalColumn: "Person_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
