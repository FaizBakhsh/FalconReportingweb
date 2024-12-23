using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FalconReportingweb.Code;

namespace FalconReportingweb
{
    public partial class PurchaseInovice : System.Web.UI.Page
    {
        List<PurchasedModel> Plist = new List<PurchasedModel>();
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                string selected = "";
                string purchasedfor = "";
                string frompu = "";
                PurchaseTb P = new PurchaseTb();
                try
                {
                    selected = Request.QueryString["Id"].ToString();
                    id = Convert.ToInt32(selected);
                    foreach (var item in db.PurchaseDetails.Where(a=>a.puid==id).ToList())
                    {
                        ItemsDeff pitem = db.ItemsDeffs.Where(a => a.Id == item.Itemid).FirstOrDefault();
                        Plist.Add(new PurchasedModel { Itemcode=pitem.ItemCode, Description=pitem.Name +"("+pitem.Detail+")"
                            , QTY=Convert.ToDouble(item.Quantity), Rate=Convert.ToDouble(item.pricepItem), UI=db.UOMTbs.Where(a=>a.Id==pitem.Unit).Select(x=>x.UOM).FirstOrDefault()

                        }); 
                    }
                     P = db.PurchaseTbs.Where(a => a.Id == id).FirstOrDefault();
                    purchasedfor = P.purchasefor;
                    if (P.Supplierid==0)
                    {
                        frompu = "CASH";
                    }
                    else
                    {
                        frompu = db.Suppliers.Where(a => a.Id == P.Supplierid).Select(x => x.Company).FirstOrDefault();
                    }
                    

                }
                catch (Exception ex)
                { }

                List<ReceiptApprovedTb> Receiptapplist = db.ReceiptApprovedTbs.ToList();
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = Plist;
                ReportParameter[] paramss = new ReportParameter[13];
                paramss[0] = new ReportParameter("date", Convert.ToDateTime(P.Date).ToString("dd/MM/yyyy"));
                paramss[1] = new ReportParameter("project", purchasedfor);
                paramss[2] = new ReportParameter("BillNo", selected);
                paramss[3] = new ReportParameter("frompu", frompu);
                int iid = 4;
                foreach (var item in Receiptapplist)
                {
                    paramss[iid] = new ReportParameter("Rank"+item.Id, item.Rank);
                    iid++;
                    paramss[iid] = new ReportParameter("Name" + item.Id, item.Name);
                    iid++;
                    paramss[iid] = new ReportParameter("Pak" + item.Id, item.Pakno);
                    iid++;
                }
                ReportViewer1.LocalReport.SetParameters(paramss);
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }
    }
}