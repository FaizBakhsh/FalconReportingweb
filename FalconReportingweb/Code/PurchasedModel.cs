using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FalconReportingweb.Code
{
    public class PurchasedModel
    {
        public string Itemcode { get; set; }
        public string Description { get; set; }
        public double QTY { get; set; }
        public double Rate { get; set; }
        public string UI { get; set; }
    }
}