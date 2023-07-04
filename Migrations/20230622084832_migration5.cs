using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_APARTMENT.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResidentsCount",
                table: "Appartments",
                newName: "Residents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Residents",
                table: "Appartments",
                newName: "ResidentsCount");
        }
    }
}
