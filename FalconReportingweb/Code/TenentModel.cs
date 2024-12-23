using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FalconReportingweb.Code
{
    public class TenantModel
    {
        public string HouseNo { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string ContractNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    
}