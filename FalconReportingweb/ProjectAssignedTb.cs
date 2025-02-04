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
    
    public partial class ProjectAssignedTb
    {
        public ProjectAssignedTb()
        {
            this.ProgressTbs = new HashSet<ProgressTb>();
            this.RarTbs = new HashSet<RarTb>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Pid { get; set; }
        public Nullable<int> ctorid { get; set; }
        public Nullable<System.DateTime> datecomm { get; set; }
        public Nullable<System.DateTime> datetcomp { get; set; }
        public Nullable<System.DateTime> extenddate { get; set; }
        public string ExtendStatus { get; set; }
        public string CAno { get; set; }
        public Nullable<decimal> CaCost { get; set; }
        public Nullable<int> Extenssion { get; set; }
        public Nullable<double> Advancepercen { get; set; }
        public Nullable<double> Advance { get; set; }
    
        public virtual ContractorTb ContractorTb { get; set; }
        public virtual ICollection<ProgressTb> ProgressTbs { get; set; }
        public virtual ProjectTbNew ProjectTbNew { get; set; }
        public virtual ICollection<RarTb> RarTbs { get; set; }
    }
}
