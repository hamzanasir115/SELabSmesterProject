using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UET_CSE.Models
{
    public class DateSheetViewModel
    {
        [Required]
        [RegularExpression(@"[\d]{4}", ErrorMessage = "Invalid Session")]
        public string Session { get; set; }

        [Required]
        [RegularExpression("[A-Z]")]
        public string Section { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Supritendent Name")]
        [RegularExpression(@"^(([A-Z][a-z]+[\s]{1}[A-za-z]+)|([A-Z][a-z]+))$", ErrorMessage = "Supritendent Name must be valid alphabets")]
        public string SupritendentName { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name ="Location")]
        public string Hall { get; set; }

        public SelectList Courses { get; set; }
    }
}