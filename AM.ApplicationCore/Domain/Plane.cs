using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{

    public class Plane
    {
        //public static Plane BoingPlane = new Plane { planeType = PlaneType.Boing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };
        /*public Plane()
        {
        }

        public Plane(int capacity, DateTime manufactureDate, string planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }*/

        public virtual ICollection<Flight> Flights { get; set; }// added for test
                                                                // public virtual Flight Flights { get; set; }
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType Planetype { get; set; }
        [NotMapped]
        public int nbrVols { get; set; }
        public override string ToString()
        {
            return "Flight" + Flights + "Capacity" + Capacity + "ManufactureDate" + ManufactureDate + "PlaneId" + PlaneId + "PlaneType" + Planetype;
        }
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }

        
    }
    public enum PlaneType
    {
    Boing,
    Airbus
    }
}
