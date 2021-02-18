using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SolarFacts.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SolarFacts.Database
{
    public class SolarContext : DbContext
    {
        private static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseInMemoryDatabase( "db_Solar", InMemoryDatabaseRoot );
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.Entity<Planet>();
            builder.Entity<Star>();

            base.OnModelCreating( builder );
        }

        public void Seed()
        {
            this.Database.EnsureCreated();

            if ( this.SolarSystems.Any() )
            {
                return;
            }

            var solarSystem     = new SolarSystem();
            solarSystem.Name    = "The Solarsystem";
            solarSystem.Bodies  = new Collection<CelestialBody> {
                new Star() {
                    Name = "Sun",
                    Age             = 4_600_000_000,
                    CoreTemp        = 15_000_000,
                    Diameter        = 1_392_684,
                    SurfaceTempLow  = 5_500,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Mercury",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 4_879,
                    MoonCount       = 0,
                    OrbitDistance   = 57_900_000,
                    OrbitPeriod     = 88.0,
                    SurfaceTempLow  = -173,
                    SurfaceTempHigh = 427,
                },

                new Planet() {
                    Name            = "Venus",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 12_104,
                    MoonCount       = 0,
                    OrbitDistance   = 108_200_000,
                    OrbitPeriod     = 224.7,
                    SurfaceTempLow  = 462,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Earth",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 12_756,
                    MoonCount       = 1,
                    OrbitDistance   = 149_600_000,
                    OrbitPeriod     = 365.2,
                    SurfaceTempLow  = -88,
                    SurfaceTempHigh = 58,
                },

                new Planet() {
                    Name            = "Mars",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 6_805,
                    MoonCount       = 2,
                    OrbitDistance   = 227_900_000,
                    OrbitPeriod     = Planet.YearToDays(1.9),
                    SurfaceTempLow  = -63,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Ceres",
                    PlanetClass     = Models.Enums.PlanetClass.DwarfPlanet,
                    Diameter        = 950,
                    MoonCount       = 0,
                    OrbitDistance   = 413_700_000,
                    OrbitPeriod     = Planet.YearToDays(4.6),
                    SurfaceTempLow  = -105,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Jupiter",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 142_984,
                    MoonCount       = 67,
                    OrbitDistance   = 778_300_000,
                    OrbitPeriod     = Planet.YearToDays( 11.9 ),
                    SurfaceTempLow  = -108,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Saturn",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 120_536,
                    MoonCount       = 62,
                    OrbitDistance   = 1_400_000_000,
                    OrbitPeriod     = Planet.YearToDays( 29.5 ),
                    SurfaceTempLow  = -139,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Uranus",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 51_118,
                    MoonCount       = 27,
                    OrbitDistance   = 2_900_000_000,
                    OrbitPeriod     = Planet.YearToDays( 84.0 ),
                    SurfaceTempLow  = -197,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Neptune",
                    PlanetClass     = Models.Enums.PlanetClass.RegularPlanet,
                    Diameter        = 49_528,
                    MoonCount       = 14,
                    OrbitDistance   = 4_500_000_000,
                    OrbitPeriod     = Planet.YearToDays( 164.8 ),
                    SurfaceTempLow  = -201,
                    SurfaceTempHigh = null,
                },

                new Planet() {
                    Name            = "Pluto",
                    PlanetClass     = Models.Enums.PlanetClass.DwarfPlanet,
                    Diameter        = 2_306,
                    MoonCount       = 5,
                    OrbitDistance   = 5_900_000_000,
                    OrbitPeriod     = Planet.YearToDays( 246.0 ),
                    SurfaceTempLow  = -229,
                    SurfaceTempHigh = null,
                },
            };

            SolarSystems.Add( solarSystem );
            SaveChanges();
        }

        public DbSet<SolarSystem> SolarSystems { get; set; }
    }
}
