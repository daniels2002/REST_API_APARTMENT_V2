using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_APARTMENT.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
