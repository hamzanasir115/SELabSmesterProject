using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class StudentViewModel
    {
        [Required]
        [Display(Name ="Student Name ")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name ="Father Name")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name ="CNIC")]
        public string CNIC { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;  }

        [Required]
        [Display(Name ="Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}