using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class AnnouncementViewModel
    {
        [Required]
        public string Topic { get; set; }

        [Required]
        public string Description { get; set; }
    }
}