using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FkCustPayement : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Coaches",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Coaches",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Coaches",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "customerPerson_Id",
                table: "CustomerPayements",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
