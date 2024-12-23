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
    public partial class ProjectwiseStock : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        List<ProjectwisStockemodel> Stocklist = new List<ProjectwisStockemodel>();
        protected void filterbtn_Click(object sender, EventArgs e)
        {
            Stocklist = new List<ProjectwisStockemodel>();
            DateTime D = Convert.ToDateTime(datetxt.Text);
            foreach (var item in db.ProjectAssignedTbs.ToList())
            {
                foreach (var pitem in db.ProjectMeterialIssuTbs.Where(a => a.date <= D && a.passignid == item.Id).ToList())
                {
                    foreach (var detail in db.IssueDetailTbs.Where(a => a.Issueid == pitem.Id).ToList())
                    {
                        ProjectTbNew P = db.ProjectTbNews.Where(a => a.Id == item.Pid).FirstOrDefault();
                        ItemsDeff itemdef = db.ItemsDeffs.Where(a => a.Id == detail.Itemid).FirstOrDefault();
                        string pname = item.CAno +"-" + P.PHnumber;
                        string itemname = itemdef.ItemCode + "-" + itemdef.Name;
                        double? total = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == detail.Itemid).Sum(x => x.TotalAmount);
                        double? Totalq = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == detail.Itemid).Sum(x => x.Quantity);
                        double? Transferd = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Issue" && a.ProjectMeterialIssuTb.passignid== pitem.passignid).Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == detail.Itemid).Sum(x => x.Total);
                        double? Transferqty = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Issue" && a.ProjectMeterialIssuTb.passignid == pitem.passignid).Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == detail.Itemid).Sum(x => x.Qty);
                        Stocklist.Add(new ProjectwisStockemodel { Item=itemname, localstore=Convert.ToDouble(total), Totalqty=Convert.ToDouble(Totalq), Project= pname ,
                         projectstore=0, Transferd=Convert.ToDouble(Transferd), Transferqty=Convert.ToDouble(Transferqty), Date=D.ToString("d")});
                    }

                }

            }

           

            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = Stocklist;

            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.DataBind();
        }
    }
}