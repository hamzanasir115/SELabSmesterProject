using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace UET_CSE.Models
{
    public class DateSheetViewModel
    {
        [Required]
        public string Session { get; set; }

        [Required]
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
        public string SupritendentName { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required]
        public string Hall { get; set; }
    }
}