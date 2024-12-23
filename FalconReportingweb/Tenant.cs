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
    
    public partial class Tenant
    {
        public Tenant()
        {
            this.Residents = new HashSet<Resident>();
        }
    
        public int Id { get; set; }
        public Nullable<int> HouseId { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string CurrentOwnerShip { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Residing { get; set; }
        public string Remarks { get; set; }
        public string Sof { get; set; }
        public string SO { get; set; }
        public string Image { get; set; }
        public string Rank { get; set; }
    
        public virtual House House { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }
    }
}