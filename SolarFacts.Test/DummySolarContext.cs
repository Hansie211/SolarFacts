using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SolarFacts.Database;
using SolarFacts.Database.Models;
using SolarFacts.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SolarFacts.Test
{
    public class DummySolarContext : DbContext, ISolarContext
    {
        private static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        #region Test data
        public static Planet PlanetA => new Planet() {
            ID              = 200,

            Name            = "PlanetA",
            PlanetClass     = PlanetClass.RegularPlanet,
            Diameter        = 2000,
            MoonCount       = 2000,
            OrbitDistance   = 2000,
            OrbitPeriod     = 2000,
            SurfaceTempLow  = 2000,
            SurfaceTempHigh = 2100,
        };

        public static Planet PlanetB => new Planet() {
            ID              = 300,

            Name            = "laneBBBB",
            PlanetClass     = PlanetClass.RegularPlanet,
            Diameter        = 2500,
            MoonCount       = 2500,
            OrbitDistance   = 2500,
            OrbitPeriod     = 2500,
            SurfaceTempLow  = 2500,
            SurfaceTempHigh = 2600,
        };

        public static Planet PlanetC => new Planet() {
            ID              = 400,

            Name            = "PlanetCCC",
            PlanetClass     = PlanetClass.RegularPlanet,
            Diameter        = 2501,
            MoonCount       = 0,
            OrbitDistance   = 2501,
            OrbitPeriod     = 2501,
            SurfaceTempLow  = -100,
            SurfaceTempHigh = -99,
        };

        public static Planet PlanetD => new Planet() {
            ID              = 500,

            Name            = "PlanetD(Dwarf)",
            PlanetClass     = PlanetClass.DwarfPlanet,
            Diameter        = 200,
            MoonCount       = 200,
            OrbitDistance   = 200,
            OrbitPeriod     = 200,
            SurfaceTempLow  = 200,
            SurfaceTempHigh = null,
        };

        public static Planet PlanetE => new Planet() {
            ID              = 600,

            Name            = "PlanetEE(Dwarf)",
            PlanetClass     = PlanetClass.DwarfPlanet,
            Diameter        = 300,
            MoonCount       = 1,
            OrbitDistance   = 300,
            OrbitPeriod     = 300,
            SurfaceTempLow  = -300,
            SurfaceTempHigh = null,
        };

        public static Star StarA => new Star() {
            ID              = 1,
            Name            = "StarA",
            Age             = 150,
            CoreTemp        = 1500,
            Diameter        = 1500,
            SurfaceTempLow  = 1500,
            SurfaceTempHigh = 1600,
        };

        public static SolarSystem DummySolarSystem => new SolarSystem {
            ID = 0,
            Name = "Test",
            Bodies = new Collection<CelestialBody>() {
                StarA,

                PlanetA,
                PlanetB,
                PlanetC,
                PlanetD,
                PlanetE,
            },
        };
        #endregion

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseInMemoryDatabase( "db_Solar", InMemoryDatabaseRoot );
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }

        public DbSet<SolarSystem> SolarSystems { get; set; }
    }
}
