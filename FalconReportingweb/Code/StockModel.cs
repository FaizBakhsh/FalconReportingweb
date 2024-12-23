using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FalconReportingweb.Code
{
    public class StockModel
    {
        public string Item { get; set; }
        public string Date { get; set; }
        public double Total { get; set; }
        public double Sold { get; set; }
        public double Transferd { get; set; }
        public double Balance { get; set; }
        public double Totalqty { get; set; }
        public double SoldQty { get; set; }
        public double Tranferqty { get; set; }
        public string ItemCode { get; set; }
        public string Batch { get; set; }
        public string Category { get; set; }
        public string UOM { get; set; }
        public string CA { get; set; }
        public double Price { get; set; }
    }
}