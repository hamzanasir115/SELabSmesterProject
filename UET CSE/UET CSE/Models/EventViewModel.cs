using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UET_CSE.Models
{
    public class EventViewModel
    {
        [Required]
        [Display(Name = "Event Name")]
        public string Event_Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public System.DateTime Start_Date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public System.DateTime End_Date { get; set; }
        [Required]
        [Display(Name ="Event Time")]
        [DataType(DataType.Time)]
        public TimeSpan Event_Time { get; set; }
        [Required]
        [Display(Name = "Ticket Price")]
        [RegularExpression("[0-9]+", ErrorMessage ="Ticket Price must be in numbers")]
        public string Ticket_Price { get; set; }
        [Required]
        public string Place { get; set; }
        
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Image File")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}