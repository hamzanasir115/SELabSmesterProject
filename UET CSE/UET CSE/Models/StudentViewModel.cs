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
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Student Name must be valid alphabets")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name ="Father Name")]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Father Name must be valid alphabets")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name ="CNIC")]
        [RegularExpression(@"[\d]{13}", ErrorMessage = "Length of CNIC must be 13")]
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
        [RegularExpression(@"[\d]{4}[-][A-Z|a-z][A-Z|a-z][-][\d]+", ErrorMessage = "Registeration Number must be entered in correct format i.e 0000-ab-0")]

        public string RegistrationNumber { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}