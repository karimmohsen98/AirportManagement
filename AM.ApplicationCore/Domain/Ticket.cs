using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {

        public int PassengerFK { get; set; }
        public int FlightFK { get; set; }
        public virtual Flight flight { get; set; }
        public virtual Passenger passenger { get; set; }
        public int NumTicket { get; set; }
        public double Prix { get; set; }
        public int Siege { get; set; }
        public Boolean Vip { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
