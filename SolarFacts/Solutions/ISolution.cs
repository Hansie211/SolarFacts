using SolarFacts.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarFacts.Solutions
{
    public interface ISolution
    {
        public int Index { get; }
        public string Description { get; }

        public abstract object GetSolutionResult( SolarSystem solarSystem );
        public abstract string DisplayResult( object result );
        public bool IsCorrectResult( SolarSystem solarSystem, object expectedResult );

        public static IEnumerable<ISolution> GetSolutions()
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where( t => typeof(ISolution).IsAssignableFrom(t) && !t.IsAbstract );
            return types.Select( t => Activator.CreateInstance( t ) ).Cast<ISolution>().OrderBy( x => x.Index );
        }
    }
}
