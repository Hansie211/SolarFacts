using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarFacts.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CelestialBody",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Diameter = table.Column<double>(type: "REAL", nullable: false),
                    SurfaceTempLow = table.Column<double>(type: "REAL", nullable: false),
                    SurfaceTempHigh = table.Column<double>(type: "REAL", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SolarSystemID = table.Column<int>(type: "INTEGER", nullable: true),
                    PlanetClass = table.Column<int>(type: "INTEGER", nullable: true),
                    MoonCount = table.Column<int>(type: "INTEGER", nullable: true),
                    OrbitDistance = table.Column<double>(type: "REAL", nullable: true),
                    OrbitPeriod = table.Column<double>(type: "REAL", nullable: true),
                    CoreTemp = table.Column<double>(type: "REAL", nullable: true),
                    Age = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialBody", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CelestialBody_SolarSystems_SolarSystemID",
                        column: x => x.SolarSystemID,
                        principalTable: "SolarSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialBody_SolarSystemID",
                table: "CelestialBody",
                column: "SolarSystemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialBody");

            migrationBuilder.DropTable(
                name: "SolarSystems");
        }
    }
}
