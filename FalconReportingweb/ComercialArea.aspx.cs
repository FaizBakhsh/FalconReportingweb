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
    public partial class ComercialArea : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<Comercialmodel> comerciallist = new List<Comercialmodel>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region shoploop
                comerciallist = new List<Comercialmodel>();
                foreach (var item in db.ShopsTbs.ToList())
                {
                    string owner = "";
                    string rentee = "";
                    if (item.ShopCurrentTbs.Any(a=>a.TypeStat== "Owner"))
                    {
                        owner = item.ShopCurrentTbs.Where(a => a.TypeStat == "owner").Select(x => x.Name).FirstOrDefault();
                    }
                    else
                    {
                        owner = "AFOHS";
                    }
                    if (item.ShopCurrentTbs.Any(a=>a.TypeStat=="Rentee" && a.Status=="Active"))
                    {
                        rentee = item.ShopCurrentTbs.Where(a => a.TypeStat == "Rentee" && a.Status == "Active").Select(x=>(x.Businessname +"("+x.Name+")")).FirstOrDefault();
                    }
                    else
                    {
                        rentee = "Available For Rent";
                    }
                    comerciallist.Add(new Comercialmodel
                    {
                        Markete = item.MarketTb.Name,
                        Owner = owner,
                        Rent = item.ShopsRents.OrderByDescending(x => x.date).Select(x => x.Rent).FirstOrDefault().ToString(),
                        shop = item.ShopeNumber
                    ,
                        torent = rentee
                    });
                }
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = comerciallist;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
                #endregion
            }
        }
    }
}