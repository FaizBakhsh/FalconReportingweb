using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FalconReportingweb.Code;
using Microsoft.Reporting.WebForms;

namespace FalconReportingweb
{
    public partial class ComercialRentReport : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<ComercialARentModel> list = new List<ComercialARentModel>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void filterbtn_Click(object sender, EventArgs e)
        {
            list = new List<ComercialARentModel>();
            DateTime start = Convert.ToDateTime(fromdate.Text);
            DateTime enddate = Convert.ToDateTime(Todate.Text);
            foreach (var item in db.ShopsTbs.ToList())
            {
                list.Add(new ComercialARentModel { Market=item.MarketTb.Name, Shopnumber=item.ShopeNumber, Rent=Convert.ToDouble(item.RenteePaymentTbs.Where(a=>a.date>=start && a.date <= enddate).Sum(x=>x.Amount))});
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            ReportParameter[] paramss = new ReportParameter[2];
            paramss[0] = new ReportParameter("startdate", start.ToString("MM/yyyy"));
            paramss[1] = new ReportParameter("todate", enddate.ToString());
            ReportViewer1.LocalReport.SetParameters(paramss);
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = list;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.DataBind();
        }
    }
}