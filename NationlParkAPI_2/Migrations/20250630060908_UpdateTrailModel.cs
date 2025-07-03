using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationlParkAPI_2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trails_NationalParks_NationlParkId",
                table: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_NationlParkId",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "NationlParkId",
                table: "Trails");

            migrationBuilder.AlterColumn<double>(
                name: "Elevation",
                table: "Trails",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Trails",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_NationalParkId",
                table: "Trails",
                column: "NationalParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_NationalParks_NationalParkId",
                table: "Trails",
                column: "NationalParkId",
                principalTable: "NationalParks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trails_NationalParks_NationalParkId",
                table: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_NationalParkId",
                table: "Trails");

            migrationBuilder.AlterColumn<string>(
                name: "Elevation",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Distance",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "NationlParkId",
                table: "Trails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trails_NationlParkId",
                table: "Trails",
                column: "NationlParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_NationalParks_NationlParkId",
                table: "Trails",
                column: "NationlParkId",
                principalTable: "NationalParks",
                principalColumn: "Id");
        }
    }
}
