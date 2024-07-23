using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoCyclePoland.Migrations
{
    /// <inheritdoc />
    public partial class test123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motocycles_Brands_BrandId",
                table: "Motocycles");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Motocycles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motocycles_Brands_BrandId",
                table: "Motocycles",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motocycles_Brands_BrandId",
                table: "Motocycles");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Motocycles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Motocycles_Brands_BrandId",
                table: "Motocycles",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
