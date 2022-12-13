using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IServicePassenger _servicePassenger;

        public PassengerController(IServicePassenger passengerService)
        {
            _servicePassenger = passengerService;
        }
        // GET: PassengerController
        public ActionResult Index()
        {
            return View(_servicePassenger.GetAll().ToList());
        }

        // GET: PassengerController/Details/5
        public ActionResult Details(int id)
        {
            var passenger = _servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger pass)
        {
            try
            {
                _servicePassenger.Add(pass);
                _servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = _servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            /*ViewBag.Planess = new SelectList(_servicePassenger.GetAll().ToList(),
               "planeId", "information", flight.planeId);*/
            return View(passenger);
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Passenger pass)
        {
            try
            {
                _servicePassenger.Update(pass);
                _servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            // GET: PassengerController/Delete/5
            public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = _servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var passenger = _servicePassenger.GetById((int)id);
                _servicePassenger.Delete(passenger);
                _servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _Details(int id)
        {
            var passenger = _servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            return PartialView(passenger);
        }
    }
}
