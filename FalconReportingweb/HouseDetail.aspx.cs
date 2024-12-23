using FalconReportingweb.Code;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalconReportingweb
{
    public partial class HouseDetail : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<HouseDetailModel> Hdetailist = new List<HouseDetailModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Hdetailist = new List<HouseDetailModel>();
            string hous = housenumber.Text;
            int hid = db.Houses.Where(a => a.HouseNo == hous).Select(x => x.Id).FirstOrDefault();
            foreach (var Allottee in db.Allottees.Where(a=>a.HouseId==hid).ToList())
            {
                Hdetailist.Add(new HouseDetailModel { housnumber = hous, Type = "Allottee" });
                if (db.ResidentTbs.Any(a=>a.ownertyp=="Alottee" && a.ownerid==Allottee.Id))
                {
                    #region check Resident if allottee
                    foreach (var resident in db.ResidentTbs.Where(a => a.ownertyp == "Alottee" && a.ownerid == Allottee.Id).ToList())
                    {
                        Hdetailist.Add(new HouseDetailModel { housnumber = hous, Type = "Resident" });
                    }
                    #endregion

                }
                else
                {
                    Hdetailist.Add(new HouseDetailModel { housnumber = hous, Type = "Vacant" });
                }
            }
           
            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = Hdetailist;
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.DataBind();
        }
    }
}