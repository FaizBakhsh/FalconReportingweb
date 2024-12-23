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
    public partial class HouseTransferList : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<House> houselist = new List<House>();
        List<TransferModel> Transferlist = new List<TransferModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string calhouse = "";
                int callh = 0;
                try
                {
                    if (Request.QueryString["calhno"] != null)
                    {
                        calhouse = Request.QueryString["calhno"].ToString();
                        callh = db.Houses.Where(a => a.HouseNo == calhouse).Select(x => x.Id).FirstOrDefault();
                    }
                
                }
                catch (Exception ex)
                { }
                Transferlist = new List<TransferModel>();
                houselist = new List<House>();
                if (callh==0)
                {
                    houselist = db.Houses.Where(a => (db.Purchasers.Any(x => x.HouseId == a.Id))).ToList();
                }
                else
                {
                    houselist = db.Houses.Where(a =>a.Id==callh && (db.Purchasers.Any(x => x.HouseId == a.Id))).ToList();
                }
              
                foreach (var item in houselist)
                {
                    foreach (var purchase in db.Purchasers.Where(a=>a.HouseId==item.Id).ToList())
                    {
                        string basepath = db.Accesses.Where(a => a.UserId == 1).Select(x => x.FormName).FirstOrDefault();
                        if (callh==0)
                        {
                            #region transfer List
                            string remark = "Sale";
                            try
                            {
                                if (purchase.Remarks==null)
                                {
                                    remark = "Sale";
                                }else
                                if (purchase.Remarks.Contains("Transfer"))
                                {
                                    remark = "Transfer";
                                }
                                else if(purchase.Remarks.Contains("Gift"))
                                {
                                    remark = "Gift";
                                }
                            }
                            catch (Exception ex)
                            { }
                          
                            string Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == purchase.Id).Select(x => x.FilePath).FirstOrDefault();
                            Transferlist.Add(new TransferModel
                            {
                                cnic = purchase.CNIC,
                                Date = Convert.ToDateTime(purchase.Date).ToString("dd/MM/yyyy"),
                                HouseNumber = item.HouseNo
                                ,
                                Img = Img,
                                Name = purchase.Name,
                                Remarks = remark,
                                url = basepath+"HouseTransferList.aspx?calhno=" + item.HouseNo
                            });
                            #endregion
                        }
                        else
                        {
                            #region transfer List
                            string remark = "Sale";
                            try
                            {
                                if (purchase.Remarks.Contains("Transfer"))
                                {
                                    remark = "Transfer";
                                }
                                else
                                {
                                    remark = "Gift";
                                }
                            }
                            catch (Exception ex)
                            { }

                            string Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == purchase.Id).Select(x => x.FilePath).FirstOrDefault();
                            Transferlist.Add(new TransferModel
                            {
                                cnic = purchase.CNIC,
                                Date = Convert.ToDateTime(purchase.Date).ToString("dd/MM/yyyy"),
                                HouseNumber = item.HouseNo
                                ,
                                Img = Img,
                                Name = purchase.Name,
                                Remarks = remark,
                                url = basepath+"HouseTransferList.aspx"
                            });
                            #endregion
                        }


                    }

                }

                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = Transferlist;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
            
            
        }
    }
}