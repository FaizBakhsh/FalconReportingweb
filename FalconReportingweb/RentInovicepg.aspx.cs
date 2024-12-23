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
    public partial class RentInovicepg : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<RentDSModel> rentds = new List<RentDSModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rentds = new List<RentDSModel>();
                string selected = "";
                try
                {
                    selected = Request.QueryString["Id"].ToString();

                }
                catch (Exception ex)
                { }
                if (selected=="")
                {
                    foreach (var item in db.RenteePaymentTbs.Where(a=>a.date.Value.Month==DateTime.Now.Month).ToList())
                    {
                        rentds.Add(new RentDSModel { businessname = item.ShopCurrentTb.Businessname, cnic = item.ShopCurrentTb.CNIC, contact = item.ShopCurrentTb.Contact, Invoice = item.id.ToString(), month = Convert.ToDateTime(item.date).ToString("MMMM"), name = item.ShopCurrentTb.Name, Rent = Convert.ToDouble(item.Amount),
                         shopnumber = item.ShopsTb.MarketTb.Name + item.ShopsTb.ShopeNumber, Status=item.Status });
                    }
                }
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                    foreach (var item in db.RenteePaymentTbs.Where(a => a.date.Value.Month == DateTime.Now.Month && a.shopid==id).ToList())
                    {
                        rentds.Add(new RentDSModel
                        {
                            businessname = item.ShopCurrentTb.Businessname,
                            cnic = item.ShopCurrentTb.CNIC,
                            contact = item.ShopCurrentTb.Contact,
                            Invoice = item.id.ToString(),
                            month = Convert.ToDateTime(item.date).ToString("MMMM"),
                            name = item.ShopCurrentTb.Name,
                            Rent = Convert.ToDouble(item.Amount),
                            shopnumber = item.ShopsTb.MarketTb.Name + item.ShopsTb.ShopeNumber,
                            Status = item.Status
                        });
                    }
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = rentds;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }
    }
}