using SolarFacts.Database.Models;
using SolarFacts.Database.Models.Enums;
using SolarFacts.Extensions;
using SolarFacts.Solutions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarFacts.Solutions
{
    // Toon een lijst van planeten oplopend gesorteerd op basis van gemiddelde afstand tot de zon

    [SolutionIndex( 6 )]
    [SolutionDescription( "Order by distance to sun." )]
    public class Solution06 : SolutionBase<IEnumerable<Planet>>
    {
        public override string DisplayResult( IEnumerable<Planet> result )
        {
            return string.Join( ',', result );
        }

        public override IEnumerable<Planet> GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets( PlanetClass.RegularPlanet ).OrderBy( p => p.OrbitDistance );
        }
    }
}
