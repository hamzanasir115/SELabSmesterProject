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
    
    public partial class Event
    {
        public string Event_Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public string Ticket_Price { get; set; }
        public string Place { get; set; }
        public byte[] Image { get; set; }
    }
}
