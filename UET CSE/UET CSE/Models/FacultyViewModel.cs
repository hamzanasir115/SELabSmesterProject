using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UET_CSE.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Name must be valid alphabets")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Image File")]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        public string Deisgnation { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        [Display(Name = "Other Qualification")]
        public string Other_Qualification { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}