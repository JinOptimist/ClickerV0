using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickerWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddExpForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InitialExp",
                table: "LevelRules",
                newName: "LearningStepSize");

            migrationBuilder.AddColumn<int>(
                name: "Coins",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Exp",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coins",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Exp",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LearningStepSize",
                table: "LevelRules",
                newName: "InitialExp");
        }
    }
}
