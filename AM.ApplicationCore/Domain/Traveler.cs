using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveler : Passenger
    {
        //public static Traveler traveller1 = new Traveler { PassportNumber = "4", FirstName = "traveller1", LastName = "traveller1", EmailAddress = "traveller1.traveller1@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "no troubles", Nationality = "American" };
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override void Passengertype()
        {
           Console.WriteLine("im a traveler");
        }
        public override string ToString()
        {
            return "BirthDate" + BirthDate + "PassPort Number" + PassportNumber + "Email Address" + EmailAddress + "FirstName" + fullName.FirstName + "LastName" + fullName.LastName + "TelNumber" + TelNumber + "HealthInfo" + HealthInformation + "Nationality " + Nationality;
        }
    }
}
