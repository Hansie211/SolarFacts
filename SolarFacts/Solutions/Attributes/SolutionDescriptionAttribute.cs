using System;
using System.Collections.Generic;
using System.Text;

namespace SolarFacts.Solutions.Attributes
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public class SolutionDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public SolutionDescriptionAttribute( string description )
        {
            Description = description;
        }
    }
}
