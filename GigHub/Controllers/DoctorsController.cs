using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.Controllers.Api;

namespace GigHub.Controllers
{
    public class DoctorsController : Controller
    {
        private DoctorsApi _doctorRepository;

        public DoctorsController()
        {
            _doctorRepository = new DoctorsApi();
        }

        // GET: Doctors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctors/Details/5
        public ActionResult ViewDoctor(int id)
        {
            var model = _doctorRepository.Get(id);
            return View(model);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
