using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UET_CSE.Models;
using System.IO;

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

            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Events = db.AddEvents;
            ViewBag.Faculty = db.AddFaculties;
            ViewBag.Achievements = db.AddAchievements;
            ViewBag.Announcements = db.AddAnnouncements;
            ViewBag.Academics = db.AddAcademics;
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
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddEvents);
        }

        public ActionResult EventsDetail(int? Name)
        {
            return View();
        }

        public ActionResult Faculty()
        {
            ViewBag.Title = "Faculty";
            UETCSEDbEntities db = new UETCSEDbEntities();
            List<AddFaculty> EventList = db.AddFaculties.ToList();

            
            return View(db.AddFaculties);
        }

        public ActionResult FacultyDetail(int id)
        {
            ViewBag.Title = "Faculty Detail";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {
              return View(db.AddFaculties.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult FacultyDetail(AddFaculty obj, int id)
        {
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddFaculties.Find(id).Name = obj.Name;
                    db.AddFaculties.Find(id).Email = obj.Email;
                    db.AddFaculties.Find(id).Designation = obj.Designation;
                    db.AddFaculties.Find(id).Qualification = obj.Qualification;
                    db.AddFaculties.Find(id).Other_Qualification = obj.Other_Qualification;
                    db.AddFaculties.Find(id).Gender = obj.Gender;
                    ViewBag.Image = Server.MapPath("~") + db.AddFaculties.Find(id).ImagePath;
                    db.AddFaculties.Find(id).ImagePath = obj.ImagePath;
                    db.SaveChanges();
                }
                    return View("HomePage");
            }
            catch
            {
                return View();
            }
            
        }


        public ActionResult Achievement()
        {
            ViewBag.Title = "Achievements";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddAchievements);
        }


        public ActionResult Announcement()
        {
            ViewBag.Title = "Announcements";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddAnnouncements);
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
