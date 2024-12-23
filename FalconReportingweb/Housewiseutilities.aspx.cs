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
    public partial class Housewiseutilities : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<UtilityModel> utilitylist = new List<UtilityModel>();
        List<House> houselist = new List<House>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            month.Text = DateTime.Now.ToString();
            houselist = new List<House>();
            houselist = db.Houses.ToList();
            string m = Convert.ToDateTime(month.Text).ToString("MMMM,yyyy");
            #region Addutilitylist
            foreach (var item in db.HouseBills.Where(a => a.BillingMonth.Contains(m)).ToList())
            {
                string exp = db.Expenses.Where(a => a.Id == item.ExpenseId).Select(x => x.Head).FirstOrDefault();
                string hno = item.House.HouseNo;
                utilitylist.Add(new UtilityModel
                {
                    Housenumber = hno,
                    Arears =Convert.ToDouble(item.Arears),
                    Exp = exp,
                    month = m,
                    Status = item.Status,
                    Surcharge =Convert.ToDouble(item.Surcharge),
                    Receivable =Convert.ToDouble(item.Payable),
                    Received =Convert.ToDouble(item.Paid)
                });
            }
            #endregion

            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = utilitylist;
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.DataBind();
        }
    }
}