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
    public partial class AllottMentList : System.Web.UI.Page
    {
        List<AllotteeModel> Allotteelist = new List<AllotteeModel>();
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"]==null)
            {
                Session["url"] = "/allottmentlist.aspx";
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    Allotteelist = new List<AllotteeModel>();
                    int id = 1;
                    foreach (var item in db.Allottees.ToList())
                    {
                        string Img = db.Documents.Where(a => a.type == "Allottee" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                        Allotteelist.Add(new AllotteeModel { id = id, Allottee = item.Name, CNIC = item.CNIC, Date = Convert.ToDateTime(item.Date).ToString("MM-dd-yyyy"), Housenumber = db.Houses.Where(a => a.Id == item.HouseId).Select(x => x.HouseNo).FirstOrDefault(), Img = new Uri(Server.MapPath(Img)).AbsoluteUri, Logo = "" });
                        id++;
                    }
                    ReportDataSource reportDataSource = new ReportDataSource();
                    // Must match the DataSource in the RDLC
                    reportDataSource.Name = "DataSet1";
                    reportDataSource.Value = Allotteelist;

                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    ReportViewer1.DataBind();
                }
            }
          
           
        }
    }
}