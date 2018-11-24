﻿using System;
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
            ViewBag.Title = "Add Event";
            return View();

        }

        [HttpPost]
        public ActionResult AddEvent(EventViewModel addeventmodel)
        {       
                var EventName = addeventmodel.Event_Name;
                var Description = addeventmodel.Description;
                var StartDate = addeventmodel.Start_Date;
                var EndDate = addeventmodel.End_Date;
                var TicketPrice = addeventmodel.Ticket_Price;
                var pLACE = addeventmodel.Place;
                string fileName = Path.GetFileNameWithoutExtension(addeventmodel.ImageFile.FileName);
                string extension = Path.GetExtension(addeventmodel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                addeventmodel.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                addeventmodel.ImageFile.SaveAs(fileName);
                var ImagePath = addeventmodel.ImagePath;
            var ImageFile = addeventmodel.ImageFile;
                AddEvent ev = new Models.AddEvent();
                ev.Event_Name = EventName;
                ev.Description = Description;
                ev.Start_Date = StartDate;
                ev.End_Date = EndDate;
                ev.Ticket_Price = TicketPrice;
                ev.Place = pLACE;
                ev.ImagePath = ImagePath;
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddEvents.Add(ev);
                    db.SaveChanges();
                    
                }
                ModelState.Clear();
                return View("Admin");

            
            
            
            
        }

        public ActionResult AddCourses()
        {
            ViewBag.Title = "Add Courses";
            return View();
        }
        [HttpPost]
        public ActionResult AddCourses(CoursesViewModel model)
        {
            ViewBag.Title = "Add Courses";
            Cours co = new Cours();
            co.SemesterNumber = Convert.ToString(model.SemesterNumber);
            co.SubjectName = model.SubjectName;
            co.SubjectCode = model.SubjectCode;
            co.SubjectAbbreviation = model.SubjectAbbreviation;
            co.CreditHours = model.CreditHours;
            UETCSEDbEntities db = new UETCSEDbEntities();
            db.Courses.Add(co);
            db.SaveChanges();
            ModelState.Clear();
            return View("Admin");
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
        [HttpPost]
        public ActionResult AddFaculty(FacultyViewModel fa)
        {
            string fileName = Path.GetFileNameWithoutExtension(fa.ImageFile.FileName);
            string extension = Path.GetExtension(fa.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            fa.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            fa.ImageFile.SaveAs(fileName);
            var Name = fa.Name;
            var Email = fa.Email;
            var ImageFile = fa.ImageFile;
            var ImagePath = fa.ImagePath;
            var Designation = fa.Deisgnation;
            var Qualification = fa.Qualification;
            var OtherQual = fa.Other_Qualification;
            var Gender = fa.Gender;
            AddFaculty faculty = new Models.AddFaculty();
            faculty.Name = Name;
            faculty.Designation = Designation;
            faculty.Email = Email;
            faculty.Qualification = Qualification;
            faculty.Other_Qualification = OtherQual;
            faculty.Gender = Gender;
            faculty.ImagePath = ImagePath;
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {
                db.AddFaculties.Add(faculty);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View("Admin");
        }
        public ActionResult UpdateFaculty()
        {
            ViewBag.Title = "Update Faculty";
            return View();
        }


       public ActionResult AddAchievement()
        {
            ViewBag.Title = "Add Achievement";
            return View();
        }
        [HttpPost]
        public ActionResult AddAchievement(AchievementViewModel ac)
        {
            string fileName = Path.GetFileNameWithoutExtension(ac.ImageFile.FileName);
            string extension = Path.GetExtension(ac.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            ac.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            ac.ImageFile.SaveAs(fileName);

            var Name = ac.Name;
            var Email = ac.Email;
            var ImagePath = ac.ImagePath;
            var ImageFile = ac.ImageFile;
            var Achievement = ac.Achievement;
            var AchievementDate = ac.Achievement_Date;
            AddAchievement ach = new Models.AddAchievement();
            ach.Name = Name;
            ach.Email = Email;
            ach.Achievement = Achievement;
            ach.Achievement_Date = AchievementDate;
            ach.Image_Path = ImagePath;
            using(UETCSEDbEntities db = new UETCSEDbEntities())
            {
                db.AddAchievements.Add(ach);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View("Admin");
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

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin model)
        {
            ViewBag.Title = "Login";
            UETCSEDbEntities db = new UETCSEDbEntities();
            foreach(Admin ad in db.Admins)
            {
                if(ad.UserName == model.UserName && ad.Password == model.Password)
                {
                    return View("Admin");
                }
            }
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
                db.Registered_Students.Add(std);
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
