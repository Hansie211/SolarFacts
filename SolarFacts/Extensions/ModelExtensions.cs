using SolarFacts.Database.Models;
using SolarFacts.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarFacts.Extensions
{
    public static class ModelExtensions
    {
        public static double MaxSurfaceTemp( this CelestialBody body ) => body.SurfaceTempHigh ?? body.SurfaceTempLow;
        public static double AverageSurfaceTemp( this CelestialBody body ) => ( body.SurfaceTempLow + body.MaxSurfaceTemp() ) / 2;

        public static IEnumerable<Star> GetStars( this SolarSystem solarSystem ) => solarSystem.Bodies.Where( x => x is Star ).Cast<Star>();
        public static IEnumerable<Planet> GetPlanets( this SolarSystem solarSystem ) => solarSystem.Bodies.Where( x => x is Planet ).Cast<Planet>();
        public static IEnumerable<Planet> GetPlanets( this SolarSystem solarSystem, PlanetClass planetClass ) => solarSystem.GetPlanets().Where( planet => planet.PlanetClass == planetClass );

    }
}
