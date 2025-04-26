using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarTools.Migrations
{
    /// <inheritdoc />
    public partial class minimalapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "tools");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "tools");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "tools");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
