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
    public partial class VehicleReport : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<VehicleModel> vhlist = new List<VehicleModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                #region vhlist 
                foreach (var item in db.VehicleTbs.ToList())
                {
                    if (item.ownertype == "Alottee")
                    {
                        if (db.ResidentTbs.Any(a => a.memberid == item.ownerid.ToString() && a.type == "Owner" && a.ownertyp == "Alottee"))
                        {
                            ResidentTb R = db.ResidentTbs.Where(a => a.memberid == item.ownerid.ToString() && a.type == "Owner").FirstOrDefault();
                            string housnumber = db.Houses.Where(a => a.Id == R.houseid).Select(x => x.HouseNo).FirstOrDefault();
                            string ownby = db.Allottees.Where(a => a.Id == item.ownerid).Select(x => x.Name).FirstOrDefault();
                            vhlist.Add(new VehicleModel {  Etag=item.Eteg , HouseNumber = housnumber, Make = item.Make, Model = item.ModelNo, OwnBy = ownby, Registration = item.RegNo, Type = item.Typevh });
                        }
                    }
                    else if (item.ownertype == "Purchaser")
                    {
                        if (db.ResidentTbs.Any(a => a.memberid == item.ownerid.ToString() && a.type == "Owner" && a.ownertyp == "Purchaser"))
                        {
                            ResidentTb R = db.ResidentTbs.Where(a => a.memberid == item.ownerid.ToString() && a.type == "Owner").FirstOrDefault();
                            string housnumber = db.Houses.Where(a => a.Id == R.houseid).Select(x => x.HouseNo).FirstOrDefault();
                            string ownby = db.Allottees.Where(a => a.Id == item.ownerid).Select(x => x.Name).FirstOrDefault();
                            vhlist.Add(new VehicleModel { Etag = item.Eteg, HouseNumber = housnumber, Make = item.Make, Model = item.ModelNo, OwnBy = ownby, Registration = item.RegNo, Type = item.Typevh });

                        }
                    }
                    else
                    {
                        if (db.ResidentTbs.Any(a => a.memberid == item.ownerid.ToString() && a.type == "Tenant"))
                        {
                            ResidentTb R = db.ResidentTbs.Where(a => a.memberid == item.ownerid.ToString() && a.type == "Tenant").FirstOrDefault();
                            string housnumber = db.Houses.Where(a => a.Id == R.houseid).Select(x => x.HouseNo).FirstOrDefault();
                            string ownby = db.Allottees.Where(a => a.Id == item.ownerid).Select(x => x.Name).FirstOrDefault();
                            vhlist.Add(new VehicleModel { Etag = item.Eteg, HouseNumber = housnumber, Make = item.Make, Model = item.ModelNo, OwnBy = ownby, Registration = item.RegNo, Type = item.Typevh });

                        }
                    }

                }
                #endregion
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = vhlist;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }
    }
}