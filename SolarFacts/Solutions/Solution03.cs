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
    // Toon een lijst van planeten waarvan de temperatuur boven nul kan zijn
    
    [SolutionIndex( 3 )]
    [SolutionDescription( "Temperature above zero." )]
    public class Solution03 : SolutionBase<IEnumerable<Planet>>
    {
        public override string DisplayResult( IEnumerable<Planet> result )
        {
            return string.Join( ',', result );
        }

        public override IEnumerable<Planet> GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets( PlanetClass.RegularPlanet ).Where( p => p.MaxSurfaceTemp() > 0 );
        }
    }
}
