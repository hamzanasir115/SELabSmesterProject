﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class EventViewModel
    {
        [Required]
        [Display(Name = "Event Name")]
        public string Event_Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public System.DateTime Start_Date { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public System.DateTime End_Date { get; set; }
        [Display(Name = "Ticket Price")]
        public string Ticket_Price { get; set; }
        public string Place { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}