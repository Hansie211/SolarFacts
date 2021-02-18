using System;
using System.Collections.Generic;
using System.Text;

namespace SolarFacts.Database.Models
{
    public class Star : CelestialBody
    {
        public double CoreTemp { get; set; }
        public double Age { get; set; }
    }
}
