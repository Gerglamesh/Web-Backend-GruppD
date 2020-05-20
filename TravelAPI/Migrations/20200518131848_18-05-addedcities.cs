using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class _1805addedcities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TravelRestrictions",
                keyColumn: "TravelRestrictionId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "Population",
                value: 4221532);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { 23, 8, "Christchurch", 381500 },
                    { 22, 8, "Auckland", 1657000 },
                    { 21, 7, "Rio de Janeiro", 13458075 },
                    { 20, 7, "São Paulo", 21846507 },
                    { 19, 7, "Brasilia", 4645943 },
                    { 18, 6, "Montreal", 1780000 },
                    { 17, 6, "Toronto", 2930000 },
                    { 16, 6, "Ottawa", 994837 },
                    { 15, 5, "Oistins", 2285 },
                    { 14, 5, "Speightstown", 3634 },
                    { 13, 5, "Bridgetown", 110000 },
                    { 12, 4, "Kira", 317157 },
                    { 11, 4, "Nansana", 365124 },
                    { 10, 4, "Kampala", 1680600 },
                    { 9, 3, "Osaka", 2691000 },
                    { 8, 3, "Yokohama", 3725000 },
                    { 7, 3, "Tokyo", 37435191 },
                    { 24, 8, "Wellington", 212700 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryInfoId", "Name", "TravelRestrictionId" },
                values: new object[] { 2, 2, "Serbia", 1 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 4, 2, "Belgrade", 1397939 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 5, 2, "Novi Sad", 289128 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 6, 2, "Niš", 185987 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "Population",
                value: 4222000);

            migrationBuilder.InsertData(
                table: "TravelRestrictions",
                columns: new[] { "TravelRestrictionId", "IsCitizenshipAllowed", "IsFamilyVisitAllowed", "IsImmigrationAllowed", "IsTourismAllowed", "IsVisaNeeded", "IsWorkTravelAllowed", "RiskLevel" },
                values: new object[] { 2, true, true, true, false, true, true, 1 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                column: "TravelRestrictionId",
                value: 2);
        }
    }
}
