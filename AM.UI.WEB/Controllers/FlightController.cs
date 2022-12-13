using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO; // input output
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _serviceFlight;
        private readonly IServicePlane _servicePlane;

        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            _serviceFlight = serviceFlight;
            _servicePlane = servicePlane;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            
            if (dateDepart == null)
            {                
                return View(_serviceFlight.GetAll().ToList());
            }
            else
            {
                //var dateDep = ((DateTime)dateDepart).ToShortDateString();
                return View(_serviceFlight.GetFlightsByDate((dateDepart).ToString()));
            }

            
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var Flight = _serviceFlight.GetById((int)id);
            if (Flight == null)
            {
                return NotFound();
            }
            return View(Flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            var planelist = new List<AM.ApplicationCore.Domain.Plane>();
            planelist = _servicePlane.GetAll().ToList();

            ViewBag.planeId = new SelectList(planelist, "PlaneId","Information");

            return View();
                    
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile AirlineImage)
        {
            try
            {
                if (AirlineImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads", AirlineImage.FileName);
                    Stream stream = new FileStream(path,FileMode.Create);
                    AirlineImage.CopyTo(stream);
                    flight.airLine = AirlineImage.FileName;
                }
                _serviceFlight.Add(flight);
                _serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.planeId = new SelectList(_servicePlane.GetAll().ToList(),
                "PlaneId","Information",flight.planeId);
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _serviceFlight.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewBag.Planess = new SelectList(_servicePlane.GetAll().ToList(),
               "PlaneId", "Information", flight.planeId);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var flight = _serviceFlight.GetById((int)id);
            try
            {
                _serviceFlight.Update(flight);
                _serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _serviceFlight.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var flight = _serviceFlight.GetById((int)id);
                _serviceFlight.Delete(flight);
                _serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _Details(int id)
        {
            var Flight = _serviceFlight.GetById((int)id);
            if (Flight == null)
            {
                return NotFound();
            }
            return PartialView(Flight);
        }
    }
    }

