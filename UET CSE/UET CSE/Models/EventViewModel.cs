using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class EventViewModel
    {
        [Required]
        [Display(Name ="Event Name")]
        public string EventName { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Display(Name ="Ticket Price")]
        public string TicketPrice { get; set; }
        [Required]
        public string Place { get; set; }
        public  Byte[] Image { get; set; }


    }
}