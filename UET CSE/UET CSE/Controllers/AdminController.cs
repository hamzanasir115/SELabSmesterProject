using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UET_CSE.Models;
using System.IO;

namespace UET_CSE.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddTimeTable()
        {
            ViewBag.Title = "Add Time Table";
            return View();

        }

        public ActionResult UpdateTimeTable()
        {
            ViewBag.Title = "Update Time Table";
            return View();

        }

        public ActionResult AddDateSheet()
        {
            ViewBag.Title = "Add Date Sheet";
            return View();

        }

        public ActionResult UpdateDateSheet()
        {
            ViewBag.Title = "Update Date Sheet";
            return View();

        }

        public ActionResult AddEvent(EventViewModel model, HttpPostedFileBase image1)
        {
            try
            {
                UETCSEEntities db = new UETCSEEntities();
                Event ev = new Event();
                if (image1 != null)
                {
                    ev.Image = model.Image;
                    ev.Image = new byte[image1.ContentLength];
                    image1.InputStream.Read(ev.Image, 0, image1.ContentLength);
                }
                ViewBag.Title = "Add Event";
                var EventName = model.EventName;
                var Description = model.Description;
                var StartDate = model.StartDate;
                var EndDate = model.EndDate;
                var TicketPrice = model.TicketPrice;
                var Place = model.Place;
                ev.Event_Name = EventName;
                ev.Description = Description;
                ev.Start_Date = StartDate;
                ev.End_Date = EndDate;
                ev.Ticket_Price = TicketPrice;
                ev.Place = Place;
                db.Events.Add(ev);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult AddCourses()
        {
            ViewBag.Title = "Add Courses";
            return View();
        }

        public ActionResult UpdateEvent()
        {
            ViewBag.Title = "Update Event";
            return View();
        }

        public ActionResult AddFaculty()
        {
            ViewBag.Title = "Add Faculty";
            return View();
        }

        public ActionResult UpdateFaculty()
        {
            ViewBag.Title = "Update Faculty";
            return View();
        }


        public ActionResult AddAchievements()
        {
            ViewBag.Title = "Add Achievement";
            return View();
        }

        public ActionResult UpdateAchievement()
        {
            ViewBag.Title = "Update Achievement";
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Title = "Admin";
            return View();
        }


        public ActionResult Login(AdminViewModel model)
        {
            ViewBag.Title = "Login";
            var email = model.Email;
            var password = model.Password;
            UETCSEEntities db = new UETCSEEntities();
            
            
            foreach (Admin admin in db.Admins)
            {
                if (admin.UserName == email && admin.Password == password)
                {
                    return View("Admin");
                }

            }
            return View();
        }
        public ActionResult RegisterStudent(StudentViewModel model)
        {

            try
            {
                ViewBag.Title = "Register Students";
                var StudentName = model.StudentName;
                var FatherName = model.FatherName;
                var RegNumber = model.RegistrationNumber;
                var CNIC = model.CNIC;
                var Email = model.Email;
                var Gender = model.Gender;
                Registered_Student std = new Registered_Student();
                std.Name = StudentName;
                std.Father_Name = FatherName;
                std.CNIC = CNIC;
                std.Email = Email;
                std.Registration_Number = RegNumber;
                std.Gender = Gender;
                UETCSEEntities db = new UETCSEEntities();
                db.Registered_Student.Add(std);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
            return View();
            
        }
        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
