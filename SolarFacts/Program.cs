using Microsoft.EntityFrameworkCore;
using SolarFacts.Database.Models;
using SolarFacts.Database.Models.Enums;
using SolarFacts.Extensions;
using SolarFacts.Solutions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SolarFacts
{
    class Program
    {

        static void Main( string[] args )
        {
            var solutions = ISolution.GetSolutions().ToList();

            using ( var context = new Database.SolarContext() )
            {
                context.Seed();

                foreach ( var solarSystem in context.SolarSystems.ToList()  )
                {
                    Console.WriteLine( $"For solarsystem '{solarSystem.Name}': " );
                    Console.WriteLine();

                    foreach ( var solution in solutions )
                    {
                        Console.WriteLine( solution.Description );
                        var result = solution.GetSolutionResult( solarSystem );
                        Console.WriteLine( solution.DisplayResult( result ).TrimEnd() );

                        Console.WriteLine();
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
