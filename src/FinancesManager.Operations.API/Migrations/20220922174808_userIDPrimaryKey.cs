using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesManager.Operations.API.Migrations
{
    public partial class userIDPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Operations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Operations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "UserId");
        }
    }
}
