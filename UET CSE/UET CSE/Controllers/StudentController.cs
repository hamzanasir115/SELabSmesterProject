using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using UET_CSE.Models;
using System.Web.Mvc;

namespace UET_CSE.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminViewModel model)
        {
            ViewBag.Title = "Login";
            /*var email = model.Email;
            var password = model.Password;
            UETCSEEntities db = new UETCSEEntities();
            
            List<Admin> list = db.Admins.ToList();
            foreach(Admin admin in list)
            {
                if(admin.UserName == email && admin.Password == password)
                {
                    return View();
                }

            }
            */
            return View();
        }

        public ActionResult DateSheet()
        {
            ViewBag.Title = "Date Sheet";
            UETCSEDbEntities db = new UETCSEDbEntities();

            return View(db.AddDateSheets);
        }

        public ActionResult TimeTable()
        {
            ViewBag.Title = "Time Table";
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Dash = "--";
            ViewBag.Break = "Break";
            string session = null;
            string section = null;
            String Student = User.Identity.Name;
            foreach(Registered_Student std in db.Registered_Students)
            {
                if(std.Email == Student)
                {
                    session = std.Session;
                    section = std.Section;
                }
            }
            List<AddTimeTable> Monday = new List<AddTimeTable>();
            List<AddTimeTable> Tuesday = new List<AddTimeTable>();
            List<AddTimeTable> Wednesday = new List<AddTimeTable>();
            List<AddTimeTable> Thursday = new List<AddTimeTable>();
            List<AddTimeTable> Friday = new List<AddTimeTable>();
            foreach(AddTimeTable time in db.AddTimeTables)
            {
                if(session == time.Session && section == time.Section)
                {
                    if(time.Day == "Monday")
                    {
                        Monday.Add(time);
                    }
                    else if(time.Day == "Tuesday")
                    {
                        Tuesday.Add(time);
                    }
                    else if(time.Day == "Wednesday")
                    {
                        Wednesday.Add(time);
                    }
                    else if(time.Day == "Thursday")
                    {
                        Thursday.Add(time);
                    }
                    else if(time.Day == "Friday")
                    {
                        Friday.Add(time);
                    }
                }
            }
            ViewBag.Monday = Monday;
            ViewBag.Tuesday = Tuesday;
            ViewBag.Wednesday = Wednesday;
            ViewBag.Thursday = Thursday;
            ViewBag.Friday = Friday;
            return View(db.AddTimeTables);
        }

        public ActionResult ForgetPassword()
        {
            ViewBag.Title = "Forget Password";
            return View();
        }
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
