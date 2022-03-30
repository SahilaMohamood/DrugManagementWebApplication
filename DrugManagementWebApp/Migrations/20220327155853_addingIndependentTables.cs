using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugManagementWebApp.Migrations
{
    public partial class addingIndependentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergicSymptoms",
                columns: table => new
                {
                    AllergicSymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllSymName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AllSymDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergicSymptoms", x => x.AllergicSymptomId);
                });

            migrationBuilder.CreateTable(
                name: "AntiAllergicDrug",
                columns: table => new
                {
                    AntiAllergicDrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntiAllDrugShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AntiAllDrugLongName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AntiAllDrugDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiAllergicDrug", x => x.AntiAllergicDrugId);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDetails",
                columns: table => new
                {
                    ConditionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ConditionDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDetails", x => x.ConditionDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "ReactionAgents",
                columns: table => new
                {
                    ReactionAgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactAgentShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ReactAgentLongName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ReactAgentDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionAgents", x => x.ReactionAgentId);
                });

            migrationBuilder.CreateTable(
                name: "UsageConditionDrugs",
                columns: table => new
                {
                    UsageConditionDrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondtnDescription = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CondtnDetails = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageConditionDrugs", x => x.UsageConditionDrugId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergicSymptoms");

            migrationBuilder.DropTable(
                name: "AntiAllergicDrug");

            migrationBuilder.DropTable(
                name: "ConditionDetails");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ReactionAgents");

            migrationBuilder.DropTable(
                name: "UsageConditionDrugs");
        }
    }
}
