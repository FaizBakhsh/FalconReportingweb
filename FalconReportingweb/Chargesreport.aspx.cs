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
    public partial class Chargesreport : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<Chargesmodel> chargeslist = new List<Chargesmodel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chargeslist = new List<Chargesmodel>();
                foreach (var item in db.Expenses.GroupBy(x => x.Head).ToList())
                {
                    string sd = "";
                    string ih = "";
                    foreach (var exp in db.Expenses.Where(a => a.Head == item.Key))
                    {
                        #region filterih and sd
                        if (exp.Type == "IH")
                        {
                            ih = exp.Amount.ToString();
                        }
                        else
                        {
                            sd = exp.Amount.ToString();
                        }
                        #endregion

                       
                    }
                    chargeslist.Add(new Chargesmodel { Title = item.Key, IH = ih, SD = sd });

                }
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = chargeslist;
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
         
        }
    }
}