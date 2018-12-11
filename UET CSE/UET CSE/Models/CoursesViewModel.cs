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
        [RegularExpression("[1-8]", ErrorMessage ="Semester Number must be between 1-8")]
        public int SemesterNumber { get; set; }
    }
}