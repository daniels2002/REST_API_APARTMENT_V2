using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_APARTMENT.Migrations
{
    /// <inheritdoc />
    public partial class migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Appartments");

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
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birth_time",
                table: "Residents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Residents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Appartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
