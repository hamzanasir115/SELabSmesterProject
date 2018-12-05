using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class DisplayTimeTable
    {
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]

        public string StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]

        public string EndTime { get; set; }

        
        [Display(Name = "Subject Name")]
        public string SubjectName1 { get; set; }
        public string SubjectName2 { get; set; }
        public string SubjectName3 { get; set; }
        public string SubjectName4 { get; set; }
        public string SubjectName5 { get; set; }
        public string SubjectName6 { get; set; }
        public string SubjectName7 { get; set; }
        public string SubjectName8 { get; set; }
        [Display(Name = "Subject Abbreviation")]
        public string SubjectAbbreviation1 { get; set; }
        public string SubjectAbbreviation2 { get; set; }
        public string SubjectAbbreviation3 { get; set; }
        public string SubjectAbbreviation4 { get; set; }
        public string SubjectAbbreviation5 { get; set; }
        public string SubjectAbbreviation6 { get; set; }
        public string SubjectAbbreviation7 { get; set; }
        public string SubjectAbbreviation8 { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Session { get; set; }
        [Required]
        public string Section { get; set; }


    }
}