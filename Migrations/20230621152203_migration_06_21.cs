using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_APARTMENT.Migrations
{
    /// <inheritdoc />
    public partial class migration_06_21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Residents",
                table: "Appartments",
                newName: "ResidentsCount");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_HouseId",
                table: "Appartments",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Houses_HouseId",
                table: "Appartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_Houses_HouseId",
                table: "Appartments");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_HouseId",
                table: "Appartments");

            migrationBuilder.RenameColumn(
                name: "ResidentsCount",
                table: "Appartments",
                newName: "Residents");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
