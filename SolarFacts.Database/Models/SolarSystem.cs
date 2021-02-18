using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SolarFacts.Database.Models
{
    public class SolarSystem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<CelestialBody> Bodies { get; set; }
    }
}
