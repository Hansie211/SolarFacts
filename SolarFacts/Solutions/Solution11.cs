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
    // Toon de gemiddelde oppervlakte temperaturen van de dwerg planeten, van de planeten en de zon en toon deze in een lijst van drie regels.

    [SolutionIndex( 11 )]
    [SolutionDescription( "Order planets, dwarfsplanets and suns by the average surface temp" )]
    public class Solution11 : SolutionBase<IEnumerable<IEnumerable<CelestialBody>>>
    {
        public override string DisplayResult( IEnumerable<IEnumerable<CelestialBody>> result )
        {
            StringBuilder sb =  new StringBuilder();
            foreach ( var line in result )
            {
                sb.AppendLine( string.Join( ',', line.Select( p => $"{p.Name}: {p.AverageSurfaceTemp()}°C" ) ) );
            }

            return sb.ToString();
        }

        public override IEnumerable<IEnumerable<CelestialBody>> GetSolutionResult( SolarSystem solarSystem )
        {
            foreach ( var group in solarSystem.Bodies.GroupBy( x => ( x as Planet )?.PlanetClass ) )
            {
                yield return group.OrderBy( x => x.AverageSurfaceTemp() );
            }
        }
    }
}
