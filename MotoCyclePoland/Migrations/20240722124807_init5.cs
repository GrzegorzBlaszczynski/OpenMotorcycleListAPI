using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorCyclePoland.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motocycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: false),
                    StartProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndProduction = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motocycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motocycles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motocycles_BrandId",
                table: "Motocycles",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motocycles");
        }
    }
}
