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
    
    public partial class ResidentTb
    {
        public int Id { get; set; }
        public Nullable<int> houseid { get; set; }
        public string type { get; set; }
        public string memberid { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Floor { get; set; }
        public Nullable<System.DateTime> checkoutDate { get; set; }
        public string ownertyp { get; set; }
        public Nullable<int> ownerid { get; set; }
        public string Srnumber { get; set; }
        public Nullable<System.DateTime> Cardexp { get; set; }
        public Nullable<System.DateTime> CardIssue { get; set; }
        public string Occupation { get; set; }
        public string CardStatus { get; set; }
        public string CardTrackNote { get; set; }
        public Nullable<int> Selected { get; set; }
    
        public virtual House House { get; set; }
    }
}
