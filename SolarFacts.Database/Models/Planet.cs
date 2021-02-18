using SolarFacts.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarFacts.Database.Models
{
    public class Planet : CelestialBody
    {
        public PlanetClass PlanetClass { get; set; }
        public int MoonCount { get; set; }

        public double OrbitDistance { get; set; } 
        public double OrbitPeriod { get; set; }
    }
}
