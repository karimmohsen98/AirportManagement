using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Service;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;

//  Plane pl2 = new Plane { Capacity = 200, ManufactureDate = DateTime.Now, PlaneType = "Airbus" };

//  Plane pl1 = new Plane(20,DateTime.Now,"Boing");

//pl1.Capacity = 20;
//pl1.PlaneType = "Boing";
//pl1.ManufactureDate = DateTime.Now;


//Passenger p1 = new Passenger("Sam","Newegg");
//Passenger p2 = new Passenger { FirstName = "Samir", LastName = "Newegg", EmailAddress = "Sam@gmail.com" };
//Staff s1 = new Staff();
//Flight f1 = new Flight();
//s1.Passengertype();
//p2.Passengertype();
ServiceFlight Sf = new ServiceFlight();
Sf.Flights= TestData.listFlights;
//Sf.GetFlightsDate("Madrid");
//Sf.GetFlightsDate("Paris");
//Sf.GetFlightsDateOld("Madrid");
//Sf.DurationAverage("Paris");
//Plane p = new Plane { Planetype = PlaneType.Boing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };
//Sf.showFlightDetails(TestData.BoingPlane);
//Sf.OrderedDurationFlight();
//Sf.Passengers = TestData.listPassengers;
//Sf.SeniorTravellers(TestData.flight1);
//Sf.DestinationGroupeFlights();
//Sf.DurationAverageDel("Paris");
//Sf.SeniorTravellers(TestData.flight1);

//AMContext context = new AMContext();
//context.Flights.Add(TestData.flight2);
//context.SaveChanges();
//Console.WriteLine(context.Flights.First());

AMContext DB = new AMContext();

ServicePlane sp = new ServicePlane(new UnitOfWork(DB,typeof(GenericRepository<>)));
sp.Add(TestData.BoingPlane);
DB.SaveChanges();

/*GenericRepository<Plane> IGR = new GenericRepository<Plane>(DB);
sp.Add(TestData.BoingPlane);
IGR.SubmitChanges();*/


//p1.CheckProfile("Sam", "Newegg");
//Console.WriteLine(p1.CheckProfile("Sam", "Newegg"));
//Console.WriteLine(p2.CheckProfile("Samir","Newegg","Sam@gmail.com"));
//p1.CheckProfile("Don", "Juan", "DonJuan@Gmail.com");







