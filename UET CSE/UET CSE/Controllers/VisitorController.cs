using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UET_CSE.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            ViewBag.Title = "WE ENSURE BETTER EDUCATION FOR A BETTER WORLD";
            ViewBag.Info = "Computer science is the theory, experimentation, and engineering that form the basis for the design and use of computers. It involves the study of algorithms that process, store, and communicate digital information.";
            return View();

        }
        public ActionResult about()
        {
            ViewBag.Title = "About";
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Title = "Events";
            return View();
        }

        public ActionResult EventsDetail()
        {
            ViewBag.Title = "Events Detail";
            return View();
        }

        public ActionResult Faculty()
        {
            ViewBag.Title = "Faculty";
            return View();
        }

        public ActionResult FacultyDetail()
        {
            ViewBag.Title = "Faculty Detail";
            return View();
        }


        public ActionResult Achievement()
        {
            ViewBag.Title = "Achievements";
            return View();
        }

        
        // GET: Visitor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Visitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitor/Create
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

        // GET: Visitor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Visitor/Edit/5
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

        // GET: Visitor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visitor/Delete/5
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
