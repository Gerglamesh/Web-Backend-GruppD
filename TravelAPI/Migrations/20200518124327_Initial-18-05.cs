using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Initial1805 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryInfo",
                columns: table => new
                {
                    CountryInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Population = table.Column<int>(nullable: false),
                    Governance = table.Column<string>(nullable: true),
                    BNP = table.Column<int>(nullable: false),
                    CapitalCity = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    TimeZone = table.Column<string>(nullable: true),
                    NationalDay = table.Column<string>(nullable: true),
                    RightHandTraffic = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryInfo", x => x.CountryInfoId);
                });

            migrationBuilder.CreateTable(
                name: "TravelRestrictions",
                columns: table => new
                {
                    TravelRestrictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWorkTravelAllowed = table.Column<bool>(nullable: false),
                    IsTourismAllowed = table.Column<bool>(nullable: false),
                    IsImmigrationAllowed = table.Column<bool>(nullable: false),
                    IsCitizenshipAllowed = table.Column<bool>(nullable: false),
                    IsFamilyVisitAllowed = table.Column<bool>(nullable: false),
                    IsVisaNeeded = table.Column<bool>(nullable: false),
                    RiskLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRestrictions", x => x.TravelRestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryInfoId = table.Column<int>(nullable: false),
                    TravelRestrictionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_CountryInfo_CountryInfoId",
                        column: x => x.CountryInfoId,
                        principalTable: "CountryInfo",
                        principalColumn: "CountryInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_TravelRestrictions_TravelRestrictionId",
                        column: x => x.TravelRestrictionId,
                        principalTable: "TravelRestrictions",
                        principalColumn: "TravelRestrictionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    AttractionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    IsChildFriendly = table.Column<bool>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.AttractionId);
                    table.ForeignKey(
                        name: "FK_Attractions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CountryInfo",
                columns: new[] { "CountryInfoId", "Area", "BNP", "CapitalCity", "Governance", "Language", "NationalDay", "Population", "RightHandTraffic", "TimeZone" },
                values: new object[,]
                {
                    { 1, 65200, 19360, "Kabul", "Islamic Republic", "Dari/Pashtu/Iranian", "19/08", 50000, true, "GMT+4:30" },
                    { 2, 88361, 7246, "Belgrad", "Parliamentary Republic", "Serbian", "15/02", 80000, true, "GMT+2" },
                    { 3, 377918, 39289, "Tokyo", "Constitutional Monarch", "Japanese/Ryukyuan/Ainu/Orok/Evenki/Nivkh", "11/02", 126244, false, "GMT+9" },
                    { 4, 241037, 2746, "Kampala", "Democratic State", "Bantu/Nilotic/Central Sudanic", "18/05", 4272, false, "GMT+3" },
                    { 5, 431, 5145, "Bridgetown", "Monarch", "English/Bajan Dialect", "30/11", 286641, false, "GMT-4" },
                    { 6, 9985000, 1713, "Ottawa", "Constitutional Monarchy", "French/English", "01/07", 3759, true, "GMT-4" },
                    { 7, 8516000, 1869, "Brasília", "Democratic Federal Republic", "Portuguese", "07/09", 2095, true, "GMT-3" },
                    { 8, 268021, 2049, "Wellington", "Unitary parliamentary constitutional monarchy", "Maori/English", "06/02", 4886, false, "GMT+12" }
                });

            migrationBuilder.InsertData(
                table: "TravelRestrictions",
                columns: new[] { "TravelRestrictionId", "IsCitizenshipAllowed", "IsFamilyVisitAllowed", "IsImmigrationAllowed", "IsTourismAllowed", "IsVisaNeeded", "IsWorkTravelAllowed", "RiskLevel" },
                values: new object[,]
                {
                    { 1, true, true, true, false, true, true, 4 },
                    { 2, true, true, true, false, true, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryInfoId", "Name", "TravelRestrictionId" },
                values: new object[,]
                {
                    { 1, 1, "Afghanistan", 1 },
                    { 3, 3, "Japan", 1 },
                    { 4, 4, "Uganda", 1 },
                    { 5, 5, "Barbados", 1 },
                    { 6, 6, "Canada", 1 },
                    { 7, 7, "Brazil", 1 },
                    { 8, 8, "New Zealand", 1 },
                    { 2, 2, "Serbia", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 1, 1, "Kabul", 4222000 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 2, 1, "Balkh", 1382200 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[] { 3, 1, "Kandahar", 614118 });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "AttractionId", "CityId", "Information", "IsChildFriendly", "Location", "Name", "Rating" },
                values: new object[] { 1, 1, "The empty niches of the Buddha statues dominate the Bamiyan valley. Carved in the 6th century, the two statues, standing 38m and 55m respectively, were the tallest standing statues of Buddha ever made.", true, "Bamiyan Valley, west of Kabul", "Buddha Niches", 4 });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "AttractionId", "CityId", "Information", "IsChildFriendly", "Location", "Name", "Rating" },
                values: new object[] { 2, 1, "The Kabul Museum was once one of the greatest museums in the world. Its exhibits, ranging from Hellenistic gold coins to Buddhist statuary and Islamic bronzes, testified to Afghanistan’s location at the crossroads of Asia. After years of abuse during the civil war, help from the international community and the peerless dedication of its staff means the museum is slowly rising from the ashes. The museum opened in 1919, and was almost entirely stocked with items excavated in Afghanistan.", true, "Kabul", "Kabul Museum", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_CityId",
                table: "Attractions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryInfoId",
                table: "Countries",
                column: "CountryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TravelRestrictionId",
                table: "Countries",
                column: "TravelRestrictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountryInfo");

            migrationBuilder.DropTable(
                name: "TravelRestrictions");
        }
    }
}
