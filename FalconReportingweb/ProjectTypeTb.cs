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
    
    public partial class ProjectTypeTb
    {
        public ProjectTypeTb()
        {
            this.ProjectTbNews = new HashSet<ProjectTbNew>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    
        public virtual ICollection<ProjectTbNew> ProjectTbNews { get; set; }
    }
}
