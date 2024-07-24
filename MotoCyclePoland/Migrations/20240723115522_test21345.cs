using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorCyclePoland.Migrations
{
    /// <inheritdoc />
    public partial class test21345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motocycles",
                keyColumn: "Id",
                keyValue: 729,
                column: "Name",
                value: "Z1000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motocycles",
                keyColumn: "Id",
                keyValue: 729,
                column: "Name",
                value: "Z1000 1000");
        }
    }
}
