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
    public partial class ItemIssueStock : System.Web.UI.Page
    {
        List<StockModel> Stocklist = new List<StockModel>();
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void filterbtn_Click(object sender, EventArgs e)
        {
            
            DateTime D = Convert.ToDateTime(datetxt.Text);
            Stocklist = new List<StockModel>();
            foreach (var item in db.ItemsDeffs)
            {

                string itemname = item.Name;
                #region Batchwise
                foreach (var batch in db.ProjectTypeTbs.ToList())
                {
                    if (db.ProjectMeterialIssuTbs.Any(a=>a.status=="Issue" && a.IssueDetailTbs.Any(x=>x.Itemid==item.Id)))
                    {
                        double? total = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == item.Id && (db.PurchaseTbs.Any(x => x.purchasefor.Contains(batch.Name)))).Sum(x => x.TotalAmount);
                        double? Totalq = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == item.Id && (db.PurchaseTbs.Any(x => x.purchasefor.Contains(batch.Name)))).Sum(x => x.Quantity);
                        double? sold = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Sale").Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Total);
                        double? soldqty = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Sale").Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Qty);


                        double? Transferd = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Issue" && (db.ProjectAssignedTbs.Any(z => z.Id == x.passignid && z.ProjectTbNew.ProjectTypeTb.Name.Contains(batch.Name)))).Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Total);
                        double? Transferqty = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Issue" && (db.ProjectAssignedTbs.Any(z => z.Id == x.passignid && z.ProjectTbNew.ProjectTypeTb.Name.Contains(batch.Name)))).Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Qty);
                        double? Bailance2 = total - (sold + Transferd);
                        string CA2 = db.PurchaseTbs.Where(a => (db.PurchaseDetails.Any(x => x.puid == a.Id))).Select(x => x.purchasefor).FirstOrDefault();
                        string Batch2 = "";
                        if (db.ProjectAssignedTbs.Any(a => a.CAno == CA2))
                        {
                            Batch2 = db.ProjectAssignedTbs.Where(a => a.CAno == CA2).Select(x => x.ProjectTbNew.ProjectTypeTb.Name).FirstOrDefault();
                        }
                        Stocklist.Add(new StockModel
                        {
                            Item = itemname,
                            Sold = Convert.ToDouble(sold),
                            Total = Convert.ToDouble(total),
                            Balance = Convert.ToDouble(Bailance2),
                            Transferd = Convert.ToDouble(Transferd),
                            Date = D.ToString("d"),
                            SoldQty = Convert.ToDouble(soldqty),
                            Totalqty = Convert.ToDouble(Totalq),
                            Tranferqty = Convert.ToDouble(Transferqty),
                            ItemCode = item.ItemCode,
                            Batch = batch.Name,
                            Category = item.CategoryTb.Name,
                            UOM = db.UOMTbs.Where(a => a.Id == item.Unit).Select(x => x.UOM).FirstOrDefault()
                        });
                    }
                   
                }
                #endregion

                #region SaleRegion
                if (db.PurchaseTbs.Any(x=>x.Date<=D && x.purchasefor=="Store" && x.PurchaseDetails.Any(a=>a.Itemid==item.Id)))
                {
                    double? total2 = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == item.Id && (db.PurchaseTbs.Any(x => x.purchasefor.Contains("Store")))).Sum(x => x.TotalAmount);
                    double? Totalq2 = db.PurchaseDetails.Where(a => a.Date <= D && a.Itemid == item.Id && (db.PurchaseTbs.Any(x => x.purchasefor.Contains("Store")))).Sum(x => x.Quantity);
                    double? sold2 = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Sale").Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Total);
                    double? soldqty2 = db.IssueDetailTbs.Where(a => (db.ProjectMeterialIssuTbs.Where(x => x.Id == a.Issueid && x.status == "Sale").Select(x => x.date).FirstOrDefault()) <= D && a.Itemid == item.Id).Sum(x => x.Qty);


                    double? Transferd2 = 0;
                    double? Transferqty2 = 0;
                    double? Bailance = total2 - (sold2 + Transferd2);
                    string CA = db.PurchaseTbs.Where(a => (db.PurchaseDetails.Any(x => x.puid == a.Id))).Select(x => x.purchasefor).FirstOrDefault();
                    string Batch = "Store";
                    //if (db.ProjectAssignedTbs.Any(a => a.CAno == CA))
                    //{
                    //    Batch = db.ProjectAssignedTbs.Where(a => a.CAno == CA).Select(x => x.ProjectTbNew.ProjectTypeTb.Name).FirstOrDefault();
                    //}
                    Stocklist.Add(new StockModel
                    {
                        Item = itemname,
                        Sold = Convert.ToDouble(sold2),
                        Total = Convert.ToDouble(total2),
                        Balance = Convert.ToDouble(Bailance),
                        Transferd = Convert.ToDouble(Transferd2),
                        Date = D.ToString("d"),
                        SoldQty = Convert.ToDouble(soldqty2),
                        Totalqty = Convert.ToDouble(Totalq2),
                        Tranferqty = Convert.ToDouble(Transferqty2),
                        ItemCode = item.ItemCode,
                        Batch = "Store",
                        Category = item.CategoryTb.Name, UOM = db.UOMTbs.Where(a => a.Id == item.Unit).Select(x => x.UOM).FirstOrDefault()
                    });

                }
                #endregion

            }
            ReportDataSource reportDataSource = new ReportDataSource();
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = Stocklist;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.DataBind();
        }
    }
}