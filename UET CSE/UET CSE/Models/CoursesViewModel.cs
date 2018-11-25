using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class CoursesViewModel
    {
        [Required]
        [Display(Name = "Subject Code")]
        
        public string SubjectCode { get; set; }
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name ="Subject Abbreviation")]
        public string SubjectAbbreviation { get; set; }

        [Required]
        [Display(Name ="Credit Hours")]
        public int CreditHours{ get; set; }

        [Required]
        [Display(Name ="Semester Number")]
        public int SemesterNumber { get; set; }
    }
}