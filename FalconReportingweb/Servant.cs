//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FalconReportingweb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servant
    {
        public int Id { get; set; }
        public Nullable<int> ResId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        public string ContactNo { get; set; }
        public string BloodGroup { get; set; }
        public string SecurityPass { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Nullable<int> houseid { get; set; }
        public string Img { get; set; }
        public string Srnumber { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<System.DateTime> DateIssue { get; set; }
        public string CardStatus { get; set; }
        public string CardTrackNote { get; set; }
        public Nullable<int> residentid { get; set; }
        public Nullable<int> Selected { get; set; }
        public string suposof { get; set; }
        public string Suposofname { get; set; }
        public int ShpId { get; set; }
    
        public virtual Resident Resident { get; set; }
    }
}