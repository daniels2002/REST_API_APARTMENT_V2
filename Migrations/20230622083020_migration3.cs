using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_APARTMENT.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Appartments_AppartmentId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_AppartmentId",
                table: "Residents");

            migrationBuilder.RenameColumn(
                name: "ResidentsCount",
                table: "Appartments",
                newName: "Residents");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Birth_time",
                table: "Residents",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Residents",
                table: "Appartments",
                newName: "ResidentsCount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birth_time",
                table: "Residents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_AppartmentId",
                table: "Residents",
                column: "AppartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Appartments_AppartmentId",
                table: "Residents",
                column: "AppartmentId",
                principalTable: "Appartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
