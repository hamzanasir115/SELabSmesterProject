using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class AchievementViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Achievement Date")]
        public System.DateTime Achievement_Date { get; set; }
        [Required]
        public string Achievement { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Image File")]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}