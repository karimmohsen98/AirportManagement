using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Service;
using AM.ApplicationCore.Services;
using AM.ApplicationCore.Domain;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Plane = AM.ApplicationCore.Domain.Plane;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.UI.WEB.Controllers
{
    public class PlaneController : Controller
    {
        private readonly IServicePlane _servicePlane;
        public PlaneController(IServicePlane planeService)
        {
            _servicePlane = planeService;
        }
        // GET: PlaneController
        public ActionResult Index()
        {

            return View(_servicePlane.GetAll().ToList()); 
                
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            var Plane = _servicePlane.GetById((int)id);
            if (Plane == null)
            {
                return NotFound();
            }
            return View(Plane);
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane)
        {
            try
            {
                _servicePlane.Add(plane);
                _servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = _servicePlane.GetById((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            ViewBag.Planetype = new SelectList(Enum.GetNames(typeof(PlaneType)));
            return View(plane);
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plane plane)
        {
            try
            {
                _servicePlane.Update(plane);
                _servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = _servicePlane.GetById((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var plane = _servicePlane.GetById((int)id);
                _servicePlane.Delete(plane);
                _servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
