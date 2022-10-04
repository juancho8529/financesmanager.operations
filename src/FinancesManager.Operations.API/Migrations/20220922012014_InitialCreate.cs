using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesManager.Operations.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Earning = table.Column<bool>(type: "bit", nullable: false),
                    EffectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ammount = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
