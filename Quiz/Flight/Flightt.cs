using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    public class Flightt
    {
        [Key]
        public long Id { get; set; }

        public DateTime OnDay { get; set; }

        [MaxLength(15)]
        public string FromCode { get; set; }

        [MaxLength(15)]
        public string ToCode { get; set; }

        // public FlyingType Type { get; set; }
        public string Type { get; set; }

        public int Passengers { get; set; }

        public override string ToString()
        {
            return string.Format("Flight #{0} on {1}, from {2} to {3}, flying type: {4}, number of passenger: {5}", Id, OnDay, FromCode, ToCode, Type, Passengers);
            // return base.ToString();
        }
    }
}
