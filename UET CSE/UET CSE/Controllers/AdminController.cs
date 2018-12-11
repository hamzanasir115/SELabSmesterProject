using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UET_CSE.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace UET_CSE.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddTimeTable()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Time Table";
            return View();
        }
        
        [HttpPost]
        public ActionResult AddTimeTable(TimeTableViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Time Table";
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }
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

        public ActionResult AddAcademic()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Academics";
            return View();
        }

        [HttpPost]
        public ActionResult AddAcademic(AcademicViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Add Academic";
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                model.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);

                var DegreeProgram = model.DegreeProgram;
                var Description = model.Description;
                var ImageFile = model.ImageFile;
                var ImagePath = model.ImagePath;
                var Duration = model.Duration;

                AddAcademic aca = new Models.AddAcademic();
                aca.Degree_Program = DegreeProgram;
                aca.Description = Description;
                aca.ImagePath = ImagePath;
                aca.Duration = Duration;

                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddAcademics.Add(aca);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return View("Admin");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ViewAcademic()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Academics";

            return View(db.AddAcademics);
        }

        public ActionResult UpdateAcademic(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Academic";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddAcademics.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateAcademic(AddAcademic obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddAcademics.Find(id).Degree_Program = obj.Degree_Program;
                    db.AddAcademics.Find(id).Description = obj.Description;
                    db.AddAcademics.Find(id).ImagePath = obj.ImagePath;
                    db.AddAcademics.Find(id).Duration = obj.Duration;

                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteAcademic(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Academic";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddAcademic t = db.AddAcademics.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeleteAcademic(int id, AddAcademic obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                ViewBag.Title = "Delete Academic";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddAcademics.Single(x => x.Id == id);
                db.AddAcademics.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddDateSheet()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.course = dbo.Courses.ToList();
            ViewBag.Title = "Add Date Sheet";
            return View();
        }
        [HttpPost]
        public ActionResult AddDateSheet(DateSheetViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            
            ViewBag.Title = "Add Date Sheet";
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                List<Cours> c = new List<Cours>();
                ViewBag.Course = new SelectList(c, "SubjectName", "SubjectName");
                AddDateSheet date = new Models.AddDateSheet();
                date.Session = model.Session;
                date.Section = model.Section;
                date.Date = model.Date;
                date.Day = model.Day;
                date.Program = model.Program;
                date.Subject = model.Subject;
                date.Supritendent_Name = model.SupritendentName;
                date.Time = Convert.ToString(model.Time);
                date.Hall = model.Hall;
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddDateSheets.Add(date);
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
        public ActionResult AddAnnouncement()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Announcement";
            return View();
        }
        [HttpPost]
        public ActionResult AddAnnouncement(AnnouncementViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Add Announcement";
            try
            {
                AddAnnouncement announce = new Models.AddAnnouncement();
                announce.Topic = model.Topic;
                announce.Description = model.Description;
                String asp = "" ;
                
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {         
                    db.AddAnnouncements.Add(announce);
                    db.SaveChanges();
                    foreach (Registered_Student a in db.Registered_Students)
                    {
                        var item = new AccountController().SendEmail(a.Email, model.Topic, model.Description);
                    }
                        
                }
                ModelState.Clear();
                return View("Admin");
            }
            catch
            {
                return View();
            }


        }

        public ActionResult UpdateDateSheet(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update DateSheet";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddDateSheets.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateDateSheet(AddDateSheet obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddDateSheets.Find(id).Session = obj.Session;
                    db.AddDateSheets.Find(id).Section = obj.Section;
                    db.AddDateSheets.Find(id).Date = obj.Date;
                    db.AddDateSheets.Find(id).Day = obj.Day;
                    db.AddDateSheets.Find(id).Program = obj.Program;
                    db.AddDateSheets.Find(id).Subject = obj.Subject;
                    db.AddDateSheets.Find(id).Supritendent_Name = obj.Supritendent_Name;
                    db.AddDateSheets.Find(id).Time = obj.Time;
                    db.AddDateSheets.Find(id).Hall = obj.Hall;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult UpdateTimeTable(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update TimeTable";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddTimeTables.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateTimeTable(AddTimeTable obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddTimeTables.Find(id).SubjectName = obj.SubjectName;
                    db.AddTimeTables.Find(id).SubjectAbbreviation= obj.SubjectAbbreviation;
                    db.AddTimeTables.Find(id).Day = obj.Day;
                    db.AddTimeTables.Find(id).Place = obj.Place;
                    db.AddTimeTables.Find(id).Session = obj.Session;
                    db.AddTimeTables.Find(id).Section = obj.Section;
                    db.AddTimeTables.Find(id).StartTime = obj.StartTime;
                    db.AddTimeTables.Find(id).EndTime = obj.EndTime;
                    db.AddTimeTables.Find(id).TeacherName = obj.TeacherName;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewAnnouncement()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Announcement";

            return View(db.AddAnnouncements);
        }
        public ActionResult DeleteAnnouncement(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Announcement";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddAnnouncement t = db.AddAnnouncements.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeleteAnnouncement(int id, AddAnnouncement obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                ViewBag.Title = "Delete Announcement";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddAnnouncements.Single(x => x.Id == id);
                db.AddAnnouncements.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult UpdateAnnouncement(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Announcement";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddAnnouncements.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateAnnouncement(AddAnnouncement obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.AddAnnouncements.Find(id).Topic = obj.Topic;
                    db.AddAnnouncements.Find(id).Description = obj.Description;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ViewTimeTable()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View TimeTable";

            return View(db.AddTimeTables);
        }
        public ActionResult DeleteTimeTable(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete TimeTable";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddTimeTable t = db.AddTimeTables.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeleteTimeTable(int id, AddTimeTable obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                ViewBag.Title = "Delete TimeTable";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddTimeTables.Single(x => x.Id == id);
                db.AddTimeTables.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewDatesheet()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Datesheet";

            return View(db.AddDateSheets);
        }
        public ActionResult DeleteDateSheet(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete DateSheet";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddDateSheet std = db.AddDateSheets.Find(id);
            return View(std);
        }

        [HttpPost]
        public ActionResult DeleteDateSheet(int id, AddDateSheet obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                ViewBag.Title = "Delete DateSheet";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.AddDateSheets.Single(x => x.Id == id);
                db.AddDateSheets.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AddEvent()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Event";
            return View();

        }

        [HttpPost]
        public ActionResult AddEvent(EventViewModel addeventmodel)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
                string fileName = Path.GetFileNameWithoutExtension(addeventmodel.ImageFile.FileName);
                string extension = Path.GetExtension(addeventmodel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                addeventmodel.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                addeventmodel.ImageFile.SaveAs(fileName);

            var ImagePath = addeventmodel.ImagePath;       
            
                var EventName = addeventmodel.Event_Name;
                var Description = addeventmodel.Description;
                var StartDate = addeventmodel.Start_Date;
                var EndDate = addeventmodel.End_Date;
                var EventTime = addeventmodel.Event_Time;
                var TicketPrice = addeventmodel.Ticket_Price;
                var pLACE = addeventmodel.Place;
            
            //var ImagePath = addeventmodel.ImagePath;
                var ImageFile = addeventmodel.ImageFile;
                AddEvent ev = new Models.AddEvent();
                ev.Event_Name = EventName;
                ev.Description = Description;
                ev.Start_Date = StartDate.Date;
                ev.End_Date = EndDate.Date;
                ev.EventTime = Convert.ToString(EventTime);
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "View Events";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddEvents);
        }
        public ActionResult UpdateEvent(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Event";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddEvents.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateEvent(AddEvent obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                { 
                    db.AddEvents.Find(id).Event_Name = obj.Event_Name;
                    db.AddEvents.Find(id).Description = obj.Description;
                    db.AddEvents.Find(id).Start_Date= obj.Start_Date;
                    db.AddEvents.Find(id).End_Date = obj.End_Date;
                    //db.AddEvents.Find(id).EventTime = obj.EventTime;
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Faculty";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.AddFaculties.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateFaculty(AddFaculty obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "View Faculty";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.AddFaculties);
        }
        public ActionResult UpdateCourses(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Courses";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.Courses.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateCourses(Cours obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "View Course";
            UETCSEDbEntities db = new UETCSEDbEntities();
            return View(db.Courses);
        }
        public ActionResult AddCourses()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Courses";
            return View();
        }
        [HttpPost]
        public ActionResult AddCourses(CoursesViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Add Courses";
            if(!ModelState.IsValid)
            {
                return View();
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Faculty";
            return View();
        }
        [HttpPost]
        public ActionResult AddFaculty(FacultyViewModel fa)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Add Achievement";
            return View();
        }
        [HttpPost]
        public ActionResult AddAchievement(AchievementViewModel ac)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Achievement";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {
                
               return View(db.AddAchievements.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateAchievement(AddAchievement obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Achievement";
            
            return View(db.AddAchievements);
        }

        public ActionResult SuperAdmin()
        {
            ViewBag.Title = "Super Admin";
            return View();
        }
        public ActionResult Admin()
        {
            
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "Admin";
            return View();
        }

        public ActionResult Login()
        {
            
            ViewBag.Title = "Login";
            return View();
        }
        [HttpPost]
        public ActionResult Login(AddAdmin model)
        {
            ViewBag.Title = "Login";
           /* UETCSEDbEntities db = new UETCSEDbEntities();
            foreach(Admin ad in db.Admins)
            {
                if(ad.UserName == model.UserName && ad.Password == model.Password)
                {
                    return View("Admin");
                }
            }

            foreach(Registered_Student reg in db.Registered_Students)
            {
                if(reg.Email == model.UserName)
                {

                }
            }
            ModelState.Clear();*/
            return View();
        }
        public ActionResult RegisterStudent(StudentViewModel model)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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

        public ActionResult ViewStudent()
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            UETCSEDbEntities db = new UETCSEDbEntities();
            ViewBag.Title = "View Student";

            return View(db.Registered_Students);
        }
        public ActionResult DeleteStudent(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Student";
            UETCSEDbEntities db = new UETCSEDbEntities();
            Registered_Student std = db.Registered_Students.Find(id);
            return View(std);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id, Registered_Student obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                ViewBag.Title = "Delete Student";
                UETCSEDbEntities db = new UETCSEDbEntities();
                var ToDelete = db.Registered_Students.Single(x => x.Id == id);
                db.Registered_Students.Remove(ToDelete);
                db.SaveChanges();
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateStudent(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Update Student";
            using (UETCSEDbEntities db = new UETCSEDbEntities())
            {

                return View(db.Registered_Students.Where(x => x.Id == id).Single());
            }
        }
        [HttpPost]
        public ActionResult UpdateStudent(Registered_Student obj, int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                using (UETCSEDbEntities db = new UETCSEDbEntities())
                {
                    db.Registered_Students.Find(id).Name = obj.Name;
                    db.Registered_Students.Find(id).Father_Name = obj.Father_Name;
                    db.Registered_Students.Find(id).CNIC = obj.CNIC;
                    db.Registered_Students.Find(id).Registration_Number = obj.Registration_Number;
                    db.Registered_Students.Find(id).Gender = obj.Gender;
                    db.Registered_Students.Find(id).Email = obj.Email;
                    db.Registered_Students.Find(id).Session = obj.Session;
                    db.Registered_Students.Find(id).Section = obj.Section;
                    db.SaveChanges();
                }
                return View("Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteAchievement(int id)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Achievement";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddAchievement ach = db.AddAchievements.Find(id);
            return View(ach);
        }

        [HttpPost]
        public ActionResult DeleteAchievement(int id, AddAchievement obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Event";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddEvent ev = db.AddEvents.Find(id);
            return View(ev);
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id, AddEvent obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Faculty";
            UETCSEDbEntities db = new UETCSEDbEntities();
            AddFaculty fa = db.AddFaculties.Find(id);
            return View(fa);
        }

        [HttpPost]
        public ActionResult DeleteFaculty(int id, AddFaculty obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = "Delete Course";
            UETCSEDbEntities db = new UETCSEDbEntities();
            Cours c = db.Courses.Find(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult DeleteCourse(int id, Cours obj)
        {
            string email = User.Identity.Name;
            string type = null;
            UETCSEDbEntities dbo = new UETCSEDbEntities();
            foreach (AddAdmin reg in dbo.AddAdmins)
            {
                if (reg.Email == email)
                {
                    type = reg.Type;
                    break;
                }
            }
            if (type == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
