using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class AcademicViewModel
    {
        [Required]
        [Display(Name ="Degree Program")]
        public string DegreeProgram { get; set; }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name ="Image Path")]
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Image File")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public string Duration { get; set; }
    }
}