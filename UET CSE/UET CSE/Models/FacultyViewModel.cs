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
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string ImagePath { get; set; }
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