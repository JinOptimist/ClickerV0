using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickerWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelImageUrl",
                table: "LevelRules",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelImageUrl",
                table: "LevelRules");
        }
    }
}
