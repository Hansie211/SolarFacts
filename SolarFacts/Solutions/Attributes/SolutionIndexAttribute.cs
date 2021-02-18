using System;
using System.Collections.Generic;
using System.Text;

namespace SolarFacts.Solutions.Attributes
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public class SolutionIndexAttribute : Attribute
    {
        public int Index { get; }

        public SolutionIndexAttribute( int index )
        {
            Index       = index;
        }
    }
}
