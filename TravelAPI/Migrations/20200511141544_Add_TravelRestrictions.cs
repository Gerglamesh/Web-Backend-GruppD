using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Add_TravelRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    RiskLevel = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRestrictions", x => x.TravelRestrictionId);
                    table.ForeignKey(
                        name: "FK_TravelRestrictions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TravelRestrictions",
                columns: new[] { "TravelRestrictionId", "CountryId", "IsCitizenshipAllowed", "IsFamilyVisitAllowed", "IsImmigrationAllowed", "IsTourismAllowed", "IsVisaNeeded", "IsWorkTravelAllowed", "RiskLevel" },
                values: new object[] { 1, 1, true, true, true, false, true, true, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_TravelRestrictions_CountryId",
                table: "TravelRestrictions",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelRestrictions");
        }
    }
}
