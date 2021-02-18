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
    // Bereken het gemiddelde aantal manen per (dwerg)planeet
    [SolutionIndex( 10 )]
    [SolutionDescription( "Calculate the average amount of moons of all planets." )]
    public class Solution10 : SolutionBase<double>
    {
        public override string DisplayResult( double result )
        {
            return result.ToString();
        }

        public override double GetSolutionResult( SolarSystem solarSystem )
        {
            return solarSystem.GetPlanets().Average( p => p.MoonCount );
        }
    }
}
