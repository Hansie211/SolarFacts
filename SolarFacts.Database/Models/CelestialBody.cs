using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolarFacts.Database.Models
{
    public abstract class CelestialBody
    {
        public const double DAYS_PER_YEAR = 365.2;
        public static double YearToDays( double years ) => DAYS_PER_YEAR * years;

        public int ID { get; set; }
        public string Name { get; set; }

        public double Diameter { get; set; }

        public double SurfaceTempLow { get; set; }
        public double? SurfaceTempHigh { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals( object obj )
        {
            if ( !( obj is CelestialBody other ) )
                return false;

            return other.ID.Equals( ID );
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( ID, Name, Diameter, SurfaceTempLow, SurfaceTempHigh );
        }
    }
}
