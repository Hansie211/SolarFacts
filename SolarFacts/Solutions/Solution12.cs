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
    // Toon een lijst met het totaalaantal zonnen, planeten, dwergplaneten en manen bij elkaar opgeteld 

    [SolutionIndex( 12 )]
    [SolutionDescription( "Get the sums of the total stars, planets, dwarfplanets and moons." )]
    public class Solution12 : SolutionBase<Solution12.SolutionResult>
    {
        public struct SolutionResult
        {
            public int StarCount { get; }
            public int PlanetCount { get; }
            public int DwarfPlanetCount { get; }
            public int MoonCount { get; }

            public SolutionResult( int starCount, int planetCount, int dwarfPlanetCount, int moonCount )
            {
                StarCount       = starCount;
                PlanetCount     = planetCount;
                DwarfPlanetCount = dwarfPlanetCount;
                MoonCount       = moonCount;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine( $"Stars: { StarCount }" );
                sb.AppendLine( $"Planets: { PlanetCount }" );
                sb.AppendLine( $"Dwarfs: { DwarfPlanetCount }" );
                sb.AppendLine( $"Moons: { MoonCount }" );

                return sb.ToString();
            }
        }

        public override string DisplayResult( SolutionResult result )
        {
            return result.ToString();
        }

        public override SolutionResult GetSolutionResult( SolarSystem solarSystem )
        {
            return new SolutionResult( solarSystem.GetStars().Count(), solarSystem.GetPlanets( PlanetClass.RegularPlanet ).Count(), solarSystem.GetPlanets( PlanetClass.DwarfPlanet ).Count(), solarSystem.GetPlanets().Sum( x => x.MoonCount ) );
        }
    }
}
