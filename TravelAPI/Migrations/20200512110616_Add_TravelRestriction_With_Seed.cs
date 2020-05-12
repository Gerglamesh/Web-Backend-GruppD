using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Add_TravelRestriction_With_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelRestrictions_Countries_CountryId",
                table: "TravelRestrictions");

            migrationBuilder.DropIndex(
                name: "IX_TravelRestrictions_CountryId",
                table: "TravelRestrictions");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "TravelRestrictions");

            migrationBuilder.AddColumn<int>(
                name: "TravelRestrictionId",
                table: "Countries",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1,
                column: "TravelRestrictionId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TravelRestrictionId",
                table: "Countries",
                column: "TravelRestrictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries",
                column: "TravelRestrictionId",
                principalTable: "TravelRestrictions",
                principalColumn: "TravelRestrictionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_TravelRestrictionId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "TravelRestrictionId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "TravelRestrictions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 1,
                column: "CountryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TravelRestrictions_CountryId",
                table: "TravelRestrictions",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRestrictions_Countries_CountryId",
                table: "TravelRestrictions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
