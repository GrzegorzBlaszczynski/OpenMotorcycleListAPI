using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorCyclePoland.Migrations
{
    /// <inheritdoc />
    public partial class test16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Motocycles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Motocycles");
        }
    }
}
