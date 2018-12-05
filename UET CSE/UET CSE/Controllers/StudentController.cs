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
            List<AddDateSheet> date = new List<AddDateSheet>();
            foreach(AddDateSheet dat in db.AddDateSheets)
            {
                if(dat.Section == section && dat.Session == session)
                {
                    date.Add(dat);
                }
            }
            return View(date);
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
            List<AddTimeTable> Time = new List<AddTimeTable>();
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
            
            List<DisplayTimeTable> TimeTable = new List<DisplayTimeTable>();
            DisplayTimeTable ObjTimeTable = new DisplayTimeTable();
            foreach(AddTimeTable disp in Monday)
            {

                if(disp.Day == "Monday")
                {
                    ObjTimeTable.Day = disp.Day;
                    if(disp.StartTime == "08:00:00" && disp.EndTime == "09:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;
                        ObjTimeTable.SubjectName1 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation1 = disp.SubjectAbbreviation;
                        
                    }
                    else if(disp.StartTime == "09:00:00" && disp.EndTime == "10:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;
                        ObjTimeTable.SubjectName2 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation2 = disp.SubjectAbbreviation;
                      }
                    else if(disp.StartTime == "10:00:00" && disp.EndTime == "11:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;
                        ObjTimeTable.SubjectName3 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation3 = disp.SubjectAbbreviation;
                      }
                    else if(disp.StartTime == "11:00:00" && disp.EndTime == "12:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;

                        ObjTimeTable.SubjectName4 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation4 = disp.SubjectAbbreviation;
                      }
                    else if(disp.StartTime == "01:00:00" && disp.EndTime == "02:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;

                        ObjTimeTable.SubjectName5 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation5 = disp.SubjectAbbreviation;
                     }
                    else if(disp.StartTime == "02:00:00" && disp.EndTime == "03:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;

                        ObjTimeTable.SubjectName6 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation6 = disp.SubjectAbbreviation;
                      }
                    else if(disp.StartTime == "03:00:00" && disp.EndTime == "04:00:00")
                    {
                        ObjTimeTable.StartTime = disp.StartTime;
                        ObjTimeTable.EndTime = disp.EndTime;

                        ObjTimeTable.SubjectName7 = disp.SubjectName;
                        ObjTimeTable.SubjectAbbreviation7 = disp.SubjectAbbreviation;
                        
                    }
                }
                ObjTimeTable.Day = disp.Day;
                ObjTimeTable.Place = disp.Place;
                ObjTimeTable.Section = disp.Section;
                ObjTimeTable.Session = disp.Session;
                
            }
            if(ObjTimeTable.SubjectAbbreviation1 == null)
            {
                ObjTimeTable.SubjectAbbreviation1 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation2 == null)
            {
                ObjTimeTable.SubjectAbbreviation2 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation3 == null)
            {
                ObjTimeTable.SubjectAbbreviation3 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation4 == null)
            {
                ObjTimeTable.SubjectAbbreviation4 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation5 == null)
            {
                ObjTimeTable.SubjectAbbreviation5 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation6 == null)
            {
                ObjTimeTable.SubjectAbbreviation6 = "--";
            }
            if (ObjTimeTable.SubjectAbbreviation7 == null)
            {
                ObjTimeTable.SubjectAbbreviation7 = "--";
            }
            TimeTable.Add(ObjTimeTable);

            DisplayTimeTable ObjTimeTable1 = new DisplayTimeTable();
            foreach (AddTimeTable disp in Tuesday)
            {

                if (disp.Day == "Tuesday")
                {
                    ObjTimeTable1.Day = disp.Day;
                    if (disp.StartTime == "08:00:00" && disp.EndTime == "09:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;
                        ObjTimeTable1.SubjectName1 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation1 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "09:00:00" && disp.EndTime == "10:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;
                        ObjTimeTable1.SubjectName2 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation2 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "10:00:00" && disp.EndTime == "11:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;
                        ObjTimeTable1.SubjectName3 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation3 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "11:00:00" && disp.EndTime == "12:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;

                        ObjTimeTable1.SubjectName4 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation4 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "01:00:00" && disp.EndTime == "02:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;

                        ObjTimeTable1.SubjectName5 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation5 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "02:00:00" && disp.EndTime == "03:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;

                        ObjTimeTable1.SubjectName6 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation6 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "03:00:00" && disp.EndTime == "04:00:00")
                    {
                        ObjTimeTable1.StartTime = disp.StartTime;
                        ObjTimeTable1.EndTime = disp.EndTime;

                        ObjTimeTable1.SubjectName7 = disp.SubjectName;
                        ObjTimeTable1.SubjectAbbreviation7 = disp.SubjectAbbreviation;
                        ObjTimeTable.TeacherName = disp.TeacherName;
                       
                    }
                }
                ObjTimeTable1.Day = disp.Day;
                ObjTimeTable1.Place = disp.Place;
                ObjTimeTable1.Section = disp.Section;
                ObjTimeTable1.Session = disp.Session;

            }
            if (ObjTimeTable1.SubjectAbbreviation1 == null)
            {
                ObjTimeTable1.SubjectAbbreviation1 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation2 == null)
            {
                ObjTimeTable1.SubjectAbbreviation2 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation3 == null)
            {
                ObjTimeTable1.SubjectAbbreviation3 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation4 == null)
            {
                ObjTimeTable1.SubjectAbbreviation4 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation5 == null)
            {
                ObjTimeTable1.SubjectAbbreviation5 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation6 == null)
            {
                ObjTimeTable1.SubjectAbbreviation6 = "--";
            }
            if (ObjTimeTable1.SubjectAbbreviation7 == null)
            {
                ObjTimeTable1.SubjectAbbreviation7 = "--";
            }
            TimeTable.Add(ObjTimeTable1);

            DisplayTimeTable ObjTimeTable2 = new DisplayTimeTable();
            foreach (AddTimeTable disp in Wednesday)
            {

                if (disp.Day == "Wednesday")
                {
                    ObjTimeTable2.Day = disp.Day;
                    if (disp.StartTime == "08:00:00" && disp.EndTime == "09:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;
                        ObjTimeTable2.SubjectName1 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation1 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "09:00:00" && disp.EndTime == "10:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;
                        ObjTimeTable2.SubjectName2 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation2 = disp.SubjectAbbreviation;
                     
                    }
                    else if (disp.StartTime == "10:00:00" && disp.EndTime == "11:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;
                        ObjTimeTable2.SubjectName3 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation3 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "11:00:00" && disp.EndTime == "12:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;

                        ObjTimeTable2.SubjectName4 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation4 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "01:00:00" && disp.EndTime == "02:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;

                        ObjTimeTable2.SubjectName5 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation5 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "02:00:00" && disp.EndTime == "03:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;

                        ObjTimeTable2.SubjectName6 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation6 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "03:00:00" && disp.EndTime == "04:00:00")
                    {
                        ObjTimeTable2.StartTime = disp.StartTime;
                        ObjTimeTable2.EndTime = disp.EndTime;

                        ObjTimeTable2.SubjectName7 = disp.SubjectName;
                        ObjTimeTable2.SubjectAbbreviation7 = disp.SubjectAbbreviation;
                        ObjTimeTable2.TeacherName = disp.TeacherName;
                       
                    }
                }
                ObjTimeTable2.Day = disp.Day;
                ObjTimeTable2.Place = disp.Place;
                ObjTimeTable2.Section = disp.Section;
                ObjTimeTable2.Session = disp.Session;

            }
            if (ObjTimeTable2.SubjectAbbreviation1 == null)
            {
                ObjTimeTable2.SubjectAbbreviation1 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation2 == null)
            {
                ObjTimeTable2.SubjectAbbreviation2 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation3 == null)
            {
                ObjTimeTable2.SubjectAbbreviation3 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation4 == null)
            {
                ObjTimeTable2.SubjectAbbreviation4 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation5 == null)
            {
                ObjTimeTable2.SubjectAbbreviation5 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation6 == null)
            {
                ObjTimeTable2.SubjectAbbreviation6 = "--";
            }
            if (ObjTimeTable2.SubjectAbbreviation7 == null)
            {
                ObjTimeTable2.SubjectAbbreviation7 = "--";
            }
            TimeTable.Add(ObjTimeTable2);

            DisplayTimeTable ObjTimeTable3 = new DisplayTimeTable();
            foreach (AddTimeTable disp in Thursday)
            {

                if (disp.Day == "Thursday")
                {
                    ObjTimeTable3.Day = disp.Day;
                    if (disp.StartTime == "08:00:00" && disp.EndTime == "09:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;
                        ObjTimeTable3.SubjectName1 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation1 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "09:00:00" && disp.EndTime == "10:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;
                        ObjTimeTable3.SubjectName2 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation2 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "10:00:00" && disp.EndTime == "11:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;
                        ObjTimeTable3.SubjectName3 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation3 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "11:00:00" && disp.EndTime == "12:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;

                        ObjTimeTable3.SubjectName4 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation4 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "01:00:00" && disp.EndTime == "02:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;

                        ObjTimeTable3.SubjectName5 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation5 = disp.SubjectAbbreviation;
                       
                    }
                    else if (disp.StartTime == "02:00:00" && disp.EndTime == "03:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;

                        ObjTimeTable3.SubjectName6 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation6 = disp.SubjectAbbreviation;
                    }
                    else if (disp.StartTime == "03:00:00" && disp.EndTime == "04:00:00")
                    {
                        ObjTimeTable3.StartTime = disp.StartTime;
                        ObjTimeTable3.EndTime = disp.EndTime;

                        ObjTimeTable3.SubjectName7 = disp.SubjectName;
                        ObjTimeTable3.SubjectAbbreviation7 = disp.SubjectAbbreviation;
                        ObjTimeTable3.TeacherName = disp.TeacherName;
                        
                    }
                }
                ObjTimeTable3.Day = disp.Day;
                ObjTimeTable3.Place = disp.Place;
                ObjTimeTable3.Section = disp.Section;
                ObjTimeTable3.Session = disp.Session;

            }
            if (ObjTimeTable3.SubjectAbbreviation1 == null)
            {
                ObjTimeTable3.SubjectAbbreviation1 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation2 == null)
            {
                ObjTimeTable3.SubjectAbbreviation2 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation3 == null)
            {
                ObjTimeTable3.SubjectAbbreviation3 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation4 == null)
            {
                ObjTimeTable3.SubjectAbbreviation4 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation5 == null)
            {
                ObjTimeTable3.SubjectAbbreviation5 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation6 == null)
            {
                ObjTimeTable3.SubjectAbbreviation6 = "--";
            }
            if (ObjTimeTable3.SubjectAbbreviation7 == null)
            {
                ObjTimeTable3.SubjectAbbreviation7 = "--";
            }
            TimeTable.Add(ObjTimeTable3);

            DisplayTimeTable ObjTimeTable4 = new DisplayTimeTable();
            foreach (AddTimeTable disp in Friday)
            {

                if (disp.Day == "Friday")
                {
                    ObjTimeTable4.Day = disp.Day;
                    if (disp.StartTime == "08:00:00" && disp.EndTime == "09:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;
                        ObjTimeTable4.SubjectName1 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation1 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "09:00:00" && disp.EndTime == "10:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;
                        ObjTimeTable4.SubjectName2 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation2 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "10:00:00" && disp.EndTime == "11:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;
                        ObjTimeTable4.SubjectName3 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation3 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "11:00:00" && disp.EndTime == "12:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;

                        ObjTimeTable4.SubjectName4 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation4 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "01:00:00" && disp.EndTime == "02:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;

                        ObjTimeTable4.SubjectName5 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation5 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "02:00:00" && disp.EndTime == "03:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;

                        ObjTimeTable4.SubjectName6 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation6 = disp.SubjectAbbreviation;
                        
                    }
                    else if (disp.StartTime == "03:00:00" && disp.EndTime == "04:00:00")
                    {
                        ObjTimeTable4.StartTime = disp.StartTime;
                        ObjTimeTable4.EndTime = disp.EndTime;

                        ObjTimeTable4.SubjectName7 = disp.SubjectName;
                        ObjTimeTable4.SubjectAbbreviation7 = disp.SubjectAbbreviation;
                        ObjTimeTable4.TeacherName = disp.TeacherName;
                        
                    }
                }
                ObjTimeTable4.Day = disp.Day;
                ObjTimeTable4.Place = disp.Place;
                ObjTimeTable4.Section = disp.Section;
                ObjTimeTable4.Session = disp.Session;

            }
            if (ObjTimeTable4.SubjectAbbreviation1 == null)
            {
                ObjTimeTable4.SubjectAbbreviation1 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation2 == null)
            {
                ObjTimeTable4.SubjectAbbreviation2 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation3 == null)
            {
                ObjTimeTable4.SubjectAbbreviation3 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation4 == null)
            {
                ObjTimeTable4.SubjectAbbreviation4 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation5 == null)
            {
                ObjTimeTable4.SubjectAbbreviation5 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation6 == null)
            {
                ObjTimeTable4.SubjectAbbreviation6 = "--";
            }
            if (ObjTimeTable4.SubjectAbbreviation7 == null)
            {
                ObjTimeTable4.SubjectAbbreviation7 = "--";
            }
            TimeTable.Add(ObjTimeTable4);

            List<AddTimeTable> time1 = new List<AddTimeTable>();
            
            foreach (AddTimeTable d in db.AddTimeTables)
            {
                if (session == d.Session && section == d.Section)
                {
                    //bool containsItem = myList.Any(item => item.UniqueProperty == wonderIfItsPresent.UniqueProperty);
                    bool contain = time1.Any(item => item.SubjectName == d.SubjectName);
                    if(contain == false)
                    {
                        time1.Add(d);
                    }
                    
                }
            }

            List<AddTimeTable> time2 = new List<AddTimeTable>();
          //  var Duplicate=time1.GroupBy(x => x.Id).Select(y => y.First());
            ViewBag.List = TimeTable;
            ViewBag.List2 = time1;
           // fooArray.GroupBy(x => x.Id).Select(x => x.First());


            return View(ObjTimeTable);
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
