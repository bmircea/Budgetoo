using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgetoo.Data.Migrations
{
    public partial class Financial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    SalaryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    DueTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyDebt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    DueTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyDebt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyMandatoryExpense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyMandatoryExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPersonalExpense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPersonalExpense", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialResource");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "MonthlyDebt");

            migrationBuilder.DropTable(
                name: "MonthlyMandatoryExpense");

            migrationBuilder.DropTable(
                name: "MonthlyPersonalExpense");
        }
    }
}
