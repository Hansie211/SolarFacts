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
    // Toon een lijst van planeten aflopend gesorteerd op de lengte van de naam

    [SolutionIndex( 5 )]
    [SolutionDescription( "Order by name-length (desc)." )]
    public class Solution05 : SolutionBase<IEnumerable<Planet>>
    {
        public override string DisplayResult( IEnumerable<Planet> result )
        {
            return string.Join( ',', result );
        }

        public override IEnumerable<Planet> GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets( PlanetClass.RegularPlanet ).OrderByDescending( p => p.Name.Length );
        }
    }
}
