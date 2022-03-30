using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugManagementWebApp.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AntiAllergicDrug",
                table: "AntiAllergicDrug");

            migrationBuilder.RenameTable(
                name: "AntiAllergicDrug",
                newName: "AntiAllergicDrugs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AntiAllergicDrugs",
                table: "AntiAllergicDrugs",
                column: "AntiAllergicDrugId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AntiAllergicDrugs",
                table: "AntiAllergicDrugs");

            migrationBuilder.RenameTable(
                name: "AntiAllergicDrugs",
                newName: "AntiAllergicDrug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AntiAllergicDrug",
                table: "AntiAllergicDrug",
                column: "AntiAllergicDrugId");
        }
    }
}
