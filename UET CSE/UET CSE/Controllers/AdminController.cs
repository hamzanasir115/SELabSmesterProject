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


        public ActionResult AddTimeTable(TimeTableViewModel model)
        {
            ViewBag.Title = "Add Time Table";
            try
            {
                AddTimeTable time = new AddTimeTable();
                time.StartTime = Convert.ToString(model.StartTime);
                time.EndTime = Convert.ToString(model.EndTime);
                time.SubjectName = model.SubjectName;
                time.SubjectAbbreviation = model.SubjectAbbreviation;
                time.Day = model.Day;
                time.TeacherName = model.TeacherName;
                time.Place = model.Place;
                time.Session = model.Session;
                time.Section = model.Section;
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddTimeTables.Add(time);
                    db.SaveChanges();

                }
                ModelState.Clear();
                return View("Admin");
            }
            catch
            {
                return View();
            }
            
            

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
                var EventTime = addeventmodel.Event_Time;
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
                ev.Start_Date = StartDate.Date;
                ev.End_Date = EndDate.Date;
                ev.Event_Time = Convert.ToString(EventTime);
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

        public ActionResult ViewEvents()
        {
            ViewBag.Title = "View Events";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddEvents);
        }
        public ActionResult UpdateEvent(int id)
        {
            ViewBag.Title = "Update Event";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddEvents.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateEvent(AddEvent obj, int id)
        {
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                { 
                    db.AddEvents.Find(id).Event_Name = obj.Event_Name;
                    db.AddEvents.Find(id).Description = obj.Description;
                    db.AddEvents.Find(id).Start_Date= obj.Start_Date;
                    db.AddEvents.Find(id).End_Date = obj.End_Date;
                    db.AddEvents.Find(id).Event_Time = obj.Event_Time;
                    db.AddEvents.Find(id).Ticket_Price = obj.Ticket_Price;
                    db.AddEvents.Find(id).Place = obj.Place;
                    db.AddEvents.Find(id).ImagePath = obj.ImagePath;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult UpdateFaculty(int id)
        {
            ViewBag.Title = "Update Faculty";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddFaculties.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateFaculty(AddFaculty obj, int id)
        {
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddFaculties.Find(id).Name = obj.Name;
                    db.AddFaculties.Find(id).Email = obj.Email;
                    db.AddFaculties.Find(id).ImagePath = obj.ImagePath;
                    db.AddFaculties.Find(id).Designation = obj.Designation;
                    db.AddFaculties.Find(id).Qualification = obj.Qualification;
                    db.AddFaculties.Find(id).Other_Qualification = obj.Other_Qualification;
                    db.AddFaculties.Find(id).Gender = obj.Gender;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewFaculty()
        {
            ViewBag.Title = "View Faculty";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddFaculties);
        }
        public ActionResult UpdateCourses(int id)
        {
            ViewBag.Title = "Update Courses";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.Courses.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateCourses(Cours obj, int id)
        {
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.Courses.Find(id).SubjectCode = obj.SubjectCode;
                    db.Courses.Find(id).SubjectName = obj.SubjectName;
                    db.Courses.Find(id).SubjectAbbreviation = obj.SubjectAbbreviation;
                    db.Courses.Find(id).CreditHours = obj.CreditHours;
                    db.Courses.Find(id).SemesterNumber = obj.SemesterNumber;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewCourses()
        {
            ViewBag.Title = "View Course";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.Courses);
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
        

        public ActionResult UpdateAchievement(int id)
        {
            ViewBag.Title = "Update Achievement";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {
                
               return View(db.AddAchievements.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateAchievement(AddAchievement obj, int id)
        {
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddAchievements.Find(id).Name = obj.Name;
                    db.AddAchievements.Find(id).Achievement_Date = obj.Achievement_Date;
                    db.AddAchievements.Find(id).Achievement = obj.Achievement;
                    db.AddAchievements.Find(id).Email = obj.Email;
                    db.AddAchievements.Find(id).Image_Path = obj.Image_Path;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult ViewAchievement()
        {
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Achievement";
            
            return View(db.AddAchievements);
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
                db.Registered_Student.Add(std);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult DeleteAchievement(int id)
        {
            ViewBag.Title = "Delete Achievement";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddAchievement ach = db.AddAchievements.Find(id);
            return View(ach);
        }

        [HttpPost]
        public ActionResult DeleteAchievement(int id, AddAchievement obj)
        {
            try
            {
                ViewBag.Title = "Delete Achievement";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddAchievements.Single(x => x.Id == id);
                db.AddAchievements.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteEvent(int id)
        {
            ViewBag.Title = "Delete Event";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddEvent ev = db.AddEvents.Find(id);
            return View(ev);
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id, AddEvent obj)
        {
            try
            {
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddEvents.Single(x => x.Id == id);
                db.AddEvents.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteFaculty(int id)
        {
            ViewBag.Title = "Delete Faculty";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddFaculty fa = db.AddFaculties.Find(id);
            return View(fa);
        }

        [HttpPost]
        public ActionResult DeleteFaculty(int id, AddFaculty obj)
        {
            try
            {
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddFaculties.Single(x => x.Id == id);
                db.AddFaculties.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteCourse(int id)
        {
            ViewBag.Title = "Delete Course";
            UETCSEDbEntities db = new UETCSEDbEntities();
            Cours c = db.Courses.Find(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult DeleteCourse(int id, Cours obj)
        {
            try
            {
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.Courses.Single(x => x.Id == id);
                db.Courses.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
