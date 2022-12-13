using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
       //public static Flight flight1 = new Flight { FlightDate = new DateTime(2022, 01, 01, 15, 10, 10), Destination = "Paris", EffectiveArrival = new DateTime(2022, 01, 01, 17, 10, 10), EstimatedDuration = 110 
       //, Plane = Airbus };

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
       //public virtual ICollection<Plane> Planes { get; set; }
        public int planeId { get; set; }
        [ForeignKey("planeId")]
        public virtual Plane Planess { get; set; } // added for test
        public String airLine { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }

        public override string ToString()
        {
            return "Destination : " + Destination + "Departure : " +Departure+ "FlightDate : " +FlightDate+ "FlightId" +FlightId+ "EffectiveArrival" +EffectiveArrival+ "EstimatedDuraion"+EstimatedDuration+"PlaneType"+Planess + "airLine" + airLine;
        }
    }

}
