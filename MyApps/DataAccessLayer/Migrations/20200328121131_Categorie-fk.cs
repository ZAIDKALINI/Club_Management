using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Categoriefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Category_Expenses_categoryId_Category",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_categoryId_Category",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "categoryId_Category",
                table: "Expenses");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Id_Category",
                table: "Expenses",
                column: "Id_Category");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Category_Expenses_Id_Category",
                table: "Expenses",
                column: "Id_Category",
                principalTable: "Category_Expenses",
                principalColumn: "Id_Category",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Category_Expenses_Id_Category",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_Id_Category",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "categoryId_Category",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_categoryId_Category",
                table: "Expenses",
                column: "categoryId_Category");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Category_Expenses_categoryId_Category",
                table: "Expenses",
                column: "categoryId_Category",
                principalTable: "Category_Expenses",
                principalColumn: "Id_Category",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
