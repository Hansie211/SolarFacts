using SolarFacts.Database.Models;
using SolarFacts.Solutions.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SolarFacts.Solutions
{
    public abstract class SolutionBase<TSolutionResult> : ISolution
    {
        public int Index => GetAttribute<SolutionIndexAttribute>()?.Index ?? -1;
        public string Description => GetAttribute<SolutionDescriptionAttribute>()?.Description ?? "[UNKNOWN]";

        object ISolution.GetSolutionResult( SolarSystem solarSystem )                       => GetSolutionResult( solarSystem );
        string ISolution.DisplayResult( object result )                                     => DisplayResult( (TSolutionResult)result );
        bool ISolution.IsCorrectResult( SolarSystem solarSystem, object expectedResult )    => IsCorrectResult( solarSystem, (TSolutionResult)expectedResult );

        public abstract TSolutionResult GetSolutionResult( SolarSystem solarSystem );
        public abstract string DisplayResult( TSolutionResult result );

        private TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute
        {
            return this.GetType().GetCustomAttribute<TAttribute>( false );
        }

        private static bool EqualEnumerable( IEnumerable A, IEnumerable B )
        {
            if ( A is null )
                return B is null;

            var enumA = A.GetEnumerator();
            var enumB = B.GetEnumerator();

            while ( enumA.MoveNext() )
            {
                if ( !enumB.MoveNext() )
                {
                    return false;
                }

                var objectA = enumA.Current;
                var objectB = enumB.Current;

                if ( objectA is IEnumerable )
                {
                    if ( !EqualEnumerable( objectA as IEnumerable, objectB as IEnumerable ) )
                        return false;
                }
                else
                {
                    if ( !objectA.Equals( objectB ) )
                        return false;
                }
            }

            return !enumB.MoveNext();
        }

        public virtual bool IsCorrectResult( SolarSystem solarSystem, TSolutionResult expectedResult )
        {
            var solutionResult = GetSolutionResult( solarSystem );

            if ( solutionResult is IEnumerable )
            {
                bool result = EqualEnumerable( solutionResult as IEnumerable, expectedResult as IEnumerable );
                return result;
            }
            else
            {
                bool result = solutionResult.Equals( expectedResult );
                return result;
            }
        }
    }
}
