using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.Common;
using System.Text.RegularExpressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.Security.Cryptography;

namespace AM.ApplicationCore.Service
{
    public class ServiceFlight : IServiceFlight
    {
        
        public List<Flight> Flights { get; set; }// = new List<Flight>();
        //public List<Flight> Flights = new List<Flight>();


        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> list = new List<DateTime>();

            foreach (Flight f in Flights)
            {
                if (f.Destination.Equals(destination))
                {
                    list.Add(f.FlightDate);
                }
            }
            return list;
        }
        /*public List<DateTime> GetFlightDates2(string destination)
        {
            List<DateTime> list = new List<DateTime>();
            foreach (Flight f in Flights)
            {
                if (f.Destination.Equals(destination))
                {
                    list.Add(f.FlightDate);
                }

            }
            return list;


        }
        */
        public void GetFlights(string filterType, string filterValue) //destination //flightdate //effectivearrival
        {   //List<Flight> list = new List<Flight>();
            //string destination = filterType;
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination == filterValue)
                            Console.WriteLine(f.ToString());
                    }

                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f.ToString());
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f.ToString());
                    }
                    break;
                default:
                    Console.WriteLine(Flights.ToString());
                    break;
            }


        }
        public void GetFlightsDate(string destination) //lambda expression
        {
            IEnumerable<Flight> flightQuery = (from f in Flights
                                               where (f.Destination == destination)
                                               select f);
            foreach (Flight f in flightQuery)
            {
                Console.WriteLine($"Flight {f.FlightDate}");
            }
        }

        public void GetFlightsDateOld(string destination)
        {
            var Query = from f in Flights where (f.Destination == destination) select f;
            foreach (var f in Query)
            {
                Console.WriteLine($"Flight {f.FlightDate}");
            }
        }
        public void ShowflightDetail(Plane plane)
        {

            // sans experession lambda 
            var Querry = from F in Flights
                         where F.Planess == plane
                         select new
                         {
                             F.Destination,
                             F.FlightDate
                         };
            foreach (var F in Querry)
            {
                Console.WriteLine("Distination = " + F.Destination, " FlightDate =  " + F.FlightDate);
            }
        }

            public void showFLightDetailsLambda(Plane p)
        {

            var q2 = Flights
                .Where(f => f.Planess == p)
                .Select(f => new { f.FlightDate, f.Destination });


            foreach (var Fl in Flights)
            {
                Console.WriteLine("Flight =" + Fl.Destination + "Date" + Fl.FlightDate);
            }


        }

        public int programmedFlightCounter(DateTime startDate)
        {
            var q = from f in Flights where (DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7) select f;

            return q.Count();


        }


        public double DurationAverage(string destination)
        {
            var requete =
                from flight in Flights
                where (flight.Destination == destination)
                select flight.EstimatedDuration;
            return requete.Average();
        }
        public List<Flight> OrderedDurationFlights()
        {
            var requete =
                from flight in Flights
                orderby flight.EstimatedDuration descending
                select flight;
            return requete.ToList();
        }

        //To.List();
        /* public List<Traveler> SeniorTravellers(Flight flight)
         {
             var Query = (from f in flight.Passengers.OfType<Traveler>() orderby f.BirthDate select f).Take(3);
             return Query.ToList();

         }*/
        /*  public void SeniorTravellers(Flight flight)
          {
              var requete =
                  (from p in flight.Passengers.OfType<Traveler>()
                   orderby p.BirthDate
                   select p).Take(3);
          }*/
        // q2 = flight.passengers.oftype<traveller>() orderby (p=>p.birthdate.TOlist).take(3); // lambda
        public void DestinationGroupeFlights() {
            var GroupByd = (from f in Flights group f by f.Destination);
            foreach(var des in GroupByd)
                    {
                Console.Write("destination" + des.Key + "ln");
                foreach (var f in Flights) {
                    Console.Write("decollage" + f.EffectiveArrival);
                }
            
            }

        
        
        }
      /* var GroupByDest = Flights.GroupBy(f1 => f1.destination);
            foreach (var des in GroupByDest)
            {
                Console.Write("destination " + des.Key + "\n");
                foreach (var f1 in Flights)
                {
                    Console.Write("  décollage " + f1.effectiveArrival + "\n");
                }
}*/
public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        /*public ServiceFlight() {
            FlightDetailsDel = showFlightDetails;
            /* DurationAverageDel = des =>
             {
                 return (from f in Flights where f.Destination.Equals(des) select f.EstimatedDuration).Average();
             };*/

           // DurationAverageDel = DurationAverage;

       // } 
        
    }

}



