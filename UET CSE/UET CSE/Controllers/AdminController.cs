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

        public ActionResult AddEvent()
        {
            ViewBag.Title = "Add Date Sheet";
            return View();

        }

        [HttpPost]
        public ActionResult AddEvent(AddEvent addeventmodel)
        {
            string fileName = Path.GetFileNameWithoutExtension(addeventmodel.ImageFile.FileName);
            string extension = Path.GetExtension(addeventmodel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            addeventmodel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            addeventmodel.ImageFile.SaveAs(fileName);
            using(UETCSEDbEntities db = new UETCSEDbEntities())
            {
                db.AddEvents.Add(addeventmodel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
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

        [HttpPost]
        public ActionResult Login(Admin model)
        {
            ViewBag.Title = "Login";
            //var email = model.UserName;
            //var password = model.Password;
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {
                db.Admins.Add(model);
                db.SaveChanges();
            }


            //foreach (Admin admin in db.Admins)
            //{
            //    if (admin.UserName == email && admin.Password == password)
            //    {
            //        return View("Admin");
            //    }

            //}
            ModelState.Clear();
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
                UETCSEDbEntities db = new UETCSEDbEntities();
                db.Registered_Student.Add(std);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }

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
