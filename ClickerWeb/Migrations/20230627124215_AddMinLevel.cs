using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickerWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddMinLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinExp",
                table: "LevelRules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinExp",
                table: "LevelRules");
        }
    }
}
