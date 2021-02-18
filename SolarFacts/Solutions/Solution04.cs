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
    // Zoek de planeten waar een ‘p’ en een ‘t’ in de naam zit

    [SolutionIndex( 4 )]
    [SolutionDescription( "Planets with 'p' or 't' in the name." )]
    public class Solution04 : SolutionBase<IEnumerable<Planet>>
    {
        public override string DisplayResult( IEnumerable<Planet> result )
        {
            return string.Join( ',', result );
        }

        public override IEnumerable<Planet> GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets( PlanetClass.RegularPlanet ).Where( p => p.Name.Contains( 'p', StringComparison.OrdinalIgnoreCase ) || p.Name.Contains( 't', StringComparison.OrdinalIgnoreCase ) );
        }
    }
}
