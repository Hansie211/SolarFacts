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
    // Toon een lijst van (dwerg)planeten gesorteerd op diameter 

    [SolutionIndex( 9 )]
    [SolutionDescription( "Order (dwarf)planets by diameter." )]
    public class Solution09 : SolutionBase<IEnumerable<Planet>>
    {
        public override string DisplayResult( IEnumerable<Planet> result )
        {
            return string.Join( ',', result );
        }

        public override IEnumerable<Planet> GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets().OrderBy( p => p.Diameter );
        }
    }
}
