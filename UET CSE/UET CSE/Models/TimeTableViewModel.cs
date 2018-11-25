using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class TimeTableViewModel
    {
        [Required]
        [Display(Name ="Start Time")]
        [DataType(DataType.Time)]

        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]

        public TimeSpan EndTime { get; set; }

        [Required]
        [Display(Name ="Subject Name")]
        public string SubjectName { get; set; }

        
        [Required]
        [Display(Name = "Subject Abbreviation")]
        public string SubjectAbbreviation { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        [Display(Name ="Teacher Name")]
        public string TeacherName { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Session { get; set; }
        [Required]
        public string Section { get; set; }
    }
}