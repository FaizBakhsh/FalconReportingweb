using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FalconReportingweb.Code
{
    public class ProjectwisStockemodel
    {
        public string Project { get; set; }
        public string Item { get; set; }
        public double projectstore { get; set; }
        public double localstore { get; set; }
        public double Transferd { get; set; }
        public double Totalqty { get; set; }
        public double Transferqty { get; set; }
        public string Date { get; set; }
       
    }
}