using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarFacts.Database.Models;
using SolarFacts.Database.Models.Enums;
using SolarFacts.Solutions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SolarFacts.Test
{
    [TestClass]
    public class SolutionUnitTest
    {

        #region Test data
        private static Planet PlanetA => new Planet() {
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

        private static Planet PlanetB => new Planet() {
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

        private static Planet PlanetC => new Planet() {
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

        private static Planet PlanetD => new Planet() {
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

        private static Planet PlanetE => new Planet() {
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

        private static Star StarA => new Star() {
            ID              = 1,
            Name            = "StarA",
            Age             = 150,
            CoreTemp        = 1500,
            Diameter        = 1500,
            SurfaceTempLow  = 1500,
            SurfaceTempHigh = 1600,
        };

        private static SolarSystem DummySolarSystem => new SolarSystem {
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

        private static void AssertSolution<TSolutionBase, TSolutionResult>( TSolutionResult expectedResult ) where TSolutionBase : SolutionBase<TSolutionResult>
        {
            var solution = (TSolutionBase)Activator.CreateInstance( typeof(TSolutionBase));
            Assert.IsTrue( solution.IsCorrectResult( DummySolarSystem, expectedResult ) );
        }

        [TestMethod]
        public void TestSolution02()
        {
            // Order planets by name
            var expected = new Planet[]{ PlanetB, PlanetA, PlanetC };
            AssertSolution<Solution02, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution03()
        {
            // Planets with temperature above zero
            var expected = new Planet[] { PlanetA, PlanetB };
            AssertSolution<Solution03, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution04()
        {
            // Planets with 'p' or 't' in the name.
            var expected = new Planet[] { PlanetA, PlanetC };
            AssertSolution<Solution04, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution05()
        {
            // Order planets by name-length (desc).
            var expected = new Planet[] { PlanetC, PlanetB, PlanetA };
            AssertSolution<Solution05, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution06()
        {
            // Order planets by distance to sun.
            var expected = new Planet[] { PlanetA, PlanetB, PlanetC };
            AssertSolution<Solution06, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution07()
        {
            // Order all planets by moon-count.
            var expected = new Planet[] { PlanetC, PlanetE, PlanetD, PlanetA, PlanetB };
            AssertSolution<Solution07, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution08()
        {
            // Count the total amount of moons.
            var expected = 4701;
            AssertSolution<Solution08, int>( expected );
        }

        [TestMethod]
        public void TestSolution09()
        {
            // Order (dwarf)planets by diameter.
            var expected = new Planet[] { PlanetD, PlanetE, PlanetA, PlanetB, PlanetC };
            AssertSolution<Solution09, IEnumerable<Planet>>( expected );
        }

        [TestMethod]
        public void TestSolution10()
        {
            // Calculate the average amount of moons of all planets.
            var expected = 4701 / 5d;
            AssertSolution<Solution10, double>( expected );
        }

        [TestMethod]
        public void TestSolution11()
        {
            // Get the average surface temp for planets, dwarfsplanets and suns.
            var expected = new CelestialBody[][] {
                new Star[] { StarA },
                new Planet[] { PlanetC, PlanetA, PlanetB },
                new Planet[] { PlanetE, PlanetD },
                };
            AssertSolution<Solution11, IEnumerable<IEnumerable<CelestialBody>>>( expected );
        }

        [TestMethod]
        public void TestSolution12()
        {
            // Get the sums of the total stars, planets, dwarfplanets and moons.
            var expected = new Solution12.SolutionResult( starCount: 1, planetCount: 3, dwarfPlanetCount: 2, moonCount: 4701 );
            AssertSolution<Solution12, Solution12.SolutionResult>( expected );
        }

        [TestMethod]
        public void TestSolution13()
        {
            // Get the closest two planets, based on the ordbit distance from the sun.
            var expected = new Solution13.SolutionResult( PlanetB, PlanetC );
            AssertSolution<Solution13, Solution13.SolutionResult>( expected );
        }
    }
}
