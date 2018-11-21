//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UET_CSE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class AddAchievement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Achievement Date")]
        public System.DateTime Achievement_Date { get; set; }
        [Required]
        public string Achievement { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}

