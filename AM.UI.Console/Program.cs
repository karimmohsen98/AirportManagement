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
//ServiceFlight Sf = new ServiceFlight();
//Sf.Flights= TestData.listFlights;
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



//ServicePlane sp = new ServicePlane(new UnitOfWork(DB,typeof(GenericRepository<>)));
//sp.Add(TestData.BoingPlane);
//DB.SaveChanges();

/*GenericRepository<Plane> IGR = new GenericRepository<Plane>(DB);
sp.Add(TestData.BoingPlane);
IGR.SubmitChanges();*/

void insertData() {
    AMContext DB = new AMContext();
    UnitOfWork uw = new UnitOfWork(DB, typeof(GenericRepository<>));
    ServicePlane sp = new ServicePlane(uw);
    sp.Add(TestData.Airbusplane);
    sp.Add(TestData.BoingPlane);
    sp.Commit();

    //Insert Flight
    ServiceFlight srvf = new ServiceFlight(uw);
    TestData.flight2.airLine = "trukishAirline";
    TestData.flight2.Departure = "Tunis";
    TestData.flight2.Destination = "Paris";
    srvf.Add(TestData.flight2);

    TestData.flight3.Departure = "Tunis";
    TestData.flight3.Destination = "Paris";
    TestData.flight3.airLine = "trukishAirline";
    srvf.Add(TestData.flight3);

    TestData.flight4.Departure = "Tunis";
    TestData.flight4.Destination = "Paris";
    TestData.flight4.airLine = "AirFrance";
    srvf.Add(TestData.flight4);

    //Insert Traveller
    ServicePassenger srvp = new ServicePassenger(uw);
    TestData.traveller1.PassportNumber = "ZWFF12";
    TestData.traveller1.Nationality = "Tunisien";
    TestData.traveller1.TelNumber = 12345678;
    srvp.Add(TestData.traveller1);


    TestData.traveller2.PassportNumber = "ZWFF12";
    TestData.traveller2.Nationality = "Tunisien";
    TestData.traveller2.TelNumber = 12345678;
    srvp.Add(TestData.traveller2);


    TestData.traveller3.PassportNumber = "ZWFF12";
    TestData.traveller3.Nationality = "Tunisien";
    TestData.traveller3.TelNumber = 12345678;
    srvp.Add(TestData.traveller3);

    srvp.Commit();

    ///Insert Ticket

    Ticket ticket1 = new Ticket()
    {
        Prix = 250,
        Siege = 15,
        Vip = false,
        passenger = TestData.traveller1,
        flight = TestData.flight2

    };
    Ticket ticket2 = new Ticket()
    {
        Prix = 250,
        Siege = 14,
        Vip = false,
        passenger = TestData.traveller2,
        flight = TestData.flight2

    };

    Ticket ticket3 = new Ticket()
    {
        Prix = 250,
        Siege = 13,
        Vip = false,
        passenger = TestData.traveller3,
        flight = TestData.flight2

    };
    ServiceTicket srvt = new ServiceTicket(uw);
    srvt.Add(ticket1);
    srvt.Add(ticket2);
    srvt.Add(ticket3);
    srvt.Commit();




}



//p1.CheckProfile("Sam", "Newegg");
//Console.WriteLine(p1.CheckProfile("Sam", "Newegg"));
//Console.WriteLine(p2.CheckProfile("Samir","Newegg","Sam@gmail.com"));
//p1.CheckProfile("Don", "Juan", "DonJuan@Gmail.com");







