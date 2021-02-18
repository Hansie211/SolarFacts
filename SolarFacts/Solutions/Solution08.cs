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
    // Tel het totaalaantal manen van het zonnestelsel

    [SolutionIndex( 8 )]
    [SolutionDescription( "Count the total amount of moons." )]
    public class Solution08 : SolutionBase<int>
    {
        public override string DisplayResult( int result )
        {
            return result.ToString();
        }

        public override int GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets().Sum( p => p.MoonCount );
        }
    }
}
