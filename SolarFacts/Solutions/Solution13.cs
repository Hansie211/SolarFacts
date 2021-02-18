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
    // Toon de twee planeten die het dichts bij elkaar staan (op basis van gemiddelde afstand tot de zon) 

    [SolutionIndex( 13 )]
    [SolutionDescription( "Get the closest two planets, based on the ordbit distance from the sun." )]
    public class Solution13 : SolutionBase<Solution13.SolutionResult>
    {
        public struct SolutionResult
        {
            public Planet PlanetA { get; }
            public Planet PlanetB { get; }

            public double Distance => PlanetB.OrbitDistance - PlanetA.OrbitDistance;

            public SolutionResult( Planet planetA, Planet planetB )
            {
                PlanetA = planetA;
                PlanetB = planetB;
            }
        }

        public override SolutionResult GetSolutionResult( SolarSystem solarSystem )
        {
            var ordered = solarSystem.GetPlanets().OrderBy( p => p.OrbitDistance );

            var distances = ordered.Take( ordered.Count() - 1 ).Select( (planet, index) => {
                var next = ordered.Skip( index + 1 ).First();
                return new SolutionResult( planetA: planet, planetB: next );
            } ).OrderBy( x => x.Distance );

            return distances.First();
        }

        public override string DisplayResult( SolutionResult result )
        {
            return $"{result.PlanetA.Name} -> { result.PlanetB.Name } : { result.Distance }km";
        }
    }
}
