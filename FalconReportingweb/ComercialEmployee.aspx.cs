using FalconSystem.Data;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalconReportingweb
{
    public partial class ComercialEmployee : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<ServantModel> servantlist = new List<ServantModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string selected = "";
                try
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        selected = Request.QueryString["Id"].ToString();
                    }

                }
                catch (Exception ex)
                { }
                string imagePath = new Uri(Server.MapPath("~/images/Logo.jpeg")).AbsoluteUri;

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                MemoryStream ms = new MemoryStream();
                try
                {
                    if (selected=="0")
                    {
                        #region allcomercial employee
                        foreach (var item in db.ShopCurrentTbs.ToList())
                        {
                            if (item.Image == null)
                            {
                                item.Image = "Upload/Residant/profile.png";
                            }
                            if (item.srnumber != null)
                            {
                                System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.srnumber, Color.Black, Color.White, 100, 30);
                                img.Save(ms, ImageFormat.Png);
                            }
                            else
                            {
                                System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, "125353648921", Color.Black, Color.White, 130, 30);
                                img.Save(ms, ImageFormat.Png);
                            }
                            servantlist.Add(new ServantModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                CNIC = item.CNIC,
                                Expiry = Convert.ToDateTime(item.cardexp).ToString("MMM-dd-yyyy"),
                                DateIssue = Convert.ToDateTime(item.cardissu).ToString("MMM-dd-yyyy")

                         ,

                                HouseNo = item.ShopsTb.ShopeNumber
                         ,
                                typework = item.TypeStat,
                                Logoimg1 = imagePath,
                                Pimg = new Uri(Server.MapPath("~/" + item.Image)).AbsoluteUri,
                                Barcodeimg = ms.ToArray(),
                                srnumber = item.srnumber,
                                Occupation = "",
                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                SO = item.SO,
                                SOName = item.SofName
                            });
                        }
                        #endregion

                    }
                    else
                    {
                        #region Selected Employee
                        foreach (var item in db.ShopCurrentTbs.Where(a=>a.Selected==1).ToList())
                        {
                            if (item.Image == null)
                            {
                                item.Image = "Upload/Residant/profile.png";
                            }
                            if (item.srnumber != null)
                            {
                                System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.srnumber, Color.Black, Color.White, 100, 30);
                                img.Save(ms, ImageFormat.Png);
                            }
                            else
                            {
                                System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, "125353648921", Color.Black, Color.White, 130, 30);
                                img.Save(ms, ImageFormat.Png);
                            }
                            servantlist.Add(new ServantModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                CNIC = item.CNIC,
                                Expiry = Convert.ToDateTime(item.cardexp).ToString("MMM-dd-yyyy"),
                                DateIssue = Convert.ToDateTime(item.cardissu).ToString("MMM-dd-yyyy")

                         ,

                                HouseNo = item.ShopsTb.ShopeNumber
                         ,
                                typework = item.TypeStat,
                                Logoimg1 = imagePath,
                                Pimg = new Uri(Server.MapPath("~/" + item.Image)).AbsoluteUri,
                                Barcodeimg = ms.ToArray(),
                                srnumber = item.srnumber,
                                Occupation = "",
                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                SO = item.SO,
                                SOName = item.SofName
                            });
                        }
                        #endregion
                    }

                    ReportDataSource reportDataSource = new ReportDataSource();
                    // Must match the DataSource in the RDLC
                    reportDataSource.Name = "DataSet1";
                    reportDataSource.Value = servantlist;

                    ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    ReportViewer1.DataBind();
                }
                catch (Exception ex)
                {

                    
                }
            }
        }
    }
}