using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugManagementWebApp.Migrations
{
    public partial class updateddrug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugShortName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DrugLongName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DrugDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChemicalAnalysis = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UsageConditionDrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                    table.ForeignKey(
                        name: "FK_Drugs_UsageConditionDrugs_UsageConditionDrugId",
                        column: x => x.UsageConditionDrugId,
                        principalTable: "UsageConditionDrugs",
                        principalColumn: "UsageConditionDrugId",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_Drugs_UsageConditionDrugId",
                table: "Drugs",
                column: "UsageConditionDrugId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNo",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
