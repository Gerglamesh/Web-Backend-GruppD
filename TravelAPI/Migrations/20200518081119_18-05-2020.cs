using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class _18052020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryInfo_CountryInfoId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "TravelRestrictionId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryInfoId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Attractions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "Population",
                value: 4222000);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "Population",
                value: 1382200);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "Population",
                value: 614118);

            migrationBuilder.UpdateData(
                table: "CountryInfo",
                keyColumn: "CountryInfoId",
                keyValue: 1,
                columns: new[] { "Area", "Population" },
                values: new object[] { 65200, 50000 });

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryInfo_CountryInfoId",
                table: "Countries",
                column: "CountryInfoId",
                principalTable: "CountryInfo",
                principalColumn: "CountryInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries",
                column: "TravelRestrictionId",
                principalTable: "TravelRestrictions",
                principalColumn: "TravelRestrictionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryInfo_CountryInfoId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "TravelRestrictionId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryInfoId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Attractions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "CountryInfo",
                keyColumn: "CountryInfoId",
                keyValue: 1,
                columns: new[] { "Area", "Population" },
                values: new object[] { 652000237, 50000000 });

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryInfo_CountryInfoId",
                table: "Countries",
                column: "CountryInfoId",
                principalTable: "CountryInfo",
                principalColumn: "CountryInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                table: "Countries",
                column: "TravelRestrictionId",
                principalTable: "TravelRestrictions",
                principalColumn: "TravelRestrictionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
