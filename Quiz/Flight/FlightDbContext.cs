using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    class FlightDbContext : DbContext
    {
        public FlightDbContext() : base("name=FlightDbContext") { }
        public virtual DbSet<Flightt> Flights { get; set; }
    }
}
