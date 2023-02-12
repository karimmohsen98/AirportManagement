using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServiceTicket _serviceTicket;
        private readonly IServiceFlight _serviceFlight;
        private readonly IServicePassenger _servicePassenger;


        public TicketController(IServiceTicket ticketService, IServiceFlight serviceFlight, IServicePassenger servicePassenger)
        {
            _serviceTicket = ticketService;
            _serviceFlight = serviceFlight;
            _servicePassenger = servicePassenger;
        }
        // GET: TicketController
        public ActionResult Index()
        {
            return View(_serviceTicket.GetAll().ToList());
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int Passengerid, int FlightId, int nbrTickets)
        {
            var ticket = _serviceTicket.GetMany().FirstOrDefault(m => m.PassengerFK == Passengerid && m.FlightFK == FlightId && m.NumTicket == nbrTickets);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            var Flightlist = new List<AM.ApplicationCore.Domain.Flight>();
            Flightlist = _serviceFlight.GetAll().ToList();

            var Passengerlist = new List<AM.ApplicationCore.Domain.Passenger>();
            Passengerlist = _servicePassenger.GetAll().ToList();
           


            ViewBag.FlightFK= new SelectList(Flightlist, "FlightId", "Destination");
            ViewBag.PassengerFK = new SelectList(Passengerlist, "Id","fullName.FirstName");
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                _serviceTicket.Add(ticket);
                _serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int? Passengerid,int? FlightId,int? nbrTickets)
        {
            if ((Passengerid == null) ||(FlightId ==null) || (nbrTickets==null))
            {
                return NotFound();
            }

            var ticket = _serviceTicket.GetAll().FirstOrDefault(m => m.PassengerFK == Passengerid && m.FlightFK == FlightId && m.NumTicket == nbrTickets);
            if (ticket == null)
            {
                return NotFound();
            }

            //ViewBag.Planetype = new SelectList(Enum.GetNames(typeof(PlaneType)));
            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                //var tickett = _serviceTicket.GetMany(m => m.PassengerFK == ticket.PassengerFK && m.FlightFK == ticket.FlightFK && m.NumTicket == ticket.NumTicket).FirstOrDefault();

                //tickett.Prix = ticket.Prix;
                //tickett.Siege = ticket.Siege;
                //tickett.Vip = ticket.Vip;


                _serviceTicket.Update(ticket);
                _serviceTicket.Commit();
                return RedirectToAction(nameof(Index)); 
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int? Passengerid, int? FlightId, int? nbrTickets)
        {
            if ((Passengerid == null) || (FlightId == null) || (nbrTickets == null))
            {
                return NotFound();
            }

            var ticket = _serviceTicket.GetAll()
                .FirstOrDefault(m => m.PassengerFK == Passengerid && m.FlightFK == FlightId && m.NumTicket == nbrTickets);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PassengerFK, int FlightFK, int nbrTickets)
        {
            try
            {
                var ticket = _serviceTicket.GetAll()
                    .FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK && m.NumTicket == nbrTickets);
                _serviceTicket.Delete(ticket);
                _serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
