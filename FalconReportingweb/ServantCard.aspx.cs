using FalconSystem.Data;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;


using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using BarcodeLib;
using System.Collections;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace FalconReportingweb
{
    public partial class ServantCard : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!this.IsPostBack)
            {
                string selected="";
                try
                {
                    selected = Request.QueryString["selected"].ToString();
                
                }
                catch (Exception ex)
                { }
                string imagePath = new Uri(Server.MapPath("~/images/Logo.jpeg")).AbsoluteUri;
                List<ServantModel> servantlist = new List<ServantModel>();

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                MemoryStream ms = new MemoryStream();

               
                if (selected=="0")
                {
                    foreach (var item in db.Servants.ToList())
                    {
                        if (item.Srnumber != null)
                        {
                            System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.Srnumber, Color.Black, Color.White, 100, 30);
                            img.Save(ms, ImageFormat.Png);
                        }
                        else
                        {
                            System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, "125353648921", Color.Black, Color.White, 100, 30);
                            img.Save(ms, ImageFormat.Png);
                        }

                        servantlist.Add(new ServantModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            CNIC = item.CNIC,
                            Expiry = Convert.ToDateTime(item.ExpiryDate).ToString("MMM-dd-yyyy"),
                            DateIssue = Convert.ToDateTime(item.DateIssue).ToString("MMM-dd-yyyy")
                        , HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                        ,typework = item.Type,
                            Logoimg1 = imagePath,
                            Pimg = new Uri(Server.MapPath("~/" + item.Img)).AbsoluteUri,
                            Barcodeimg = ms.ToArray(),
                            srnumber = item.Srnumber,
                            Occupation = "",
                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri, SO=item.suposof, SOName=item.Suposofname, bcolor=db.ColorTbs.Where(a=>a.cardname=="Sarvant").Select(x=>x.backcolor).FirstOrDefault()
                        });

                    }
                }
                else
                {
                    foreach (var item in db.Servants.Where(a=>a.Selected==1 && a.houseid!=null || a.Selected==1 && a.ShpId>0).ToList())
                    {
                        if (item.Srnumber != null)
                        {
                            System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.Srnumber, Color.Black, Color.White, 100, 30);
                            img.Save(ms, ImageFormat.Png);
                        }
                        else
                        {
                            System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, "125353648921", Color.Black, Color.White, 100, 30);
                            img.Save(ms, ImageFormat.Png);
                        }



                        if (item.houseid != null)
                        {
                            servantlist.Add(new ServantModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                CNIC = item.CNIC,
                                Expiry = Convert.ToDateTime(item.ExpiryDate).ToString("MMM-dd-yyyy"),
                                DateIssue = Convert.ToDateTime(item.DateIssue).ToString("MMM-dd-yyyy")

                            ,
                                HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                            ,
                                typework = item.Type,
                                Logoimg1 = imagePath,
                                Pimg = new Uri(Server.MapPath("~/" + item.Img)).AbsoluteUri,
                                Barcodeimg = ms.ToArray(),
                                srnumber = item.Srnumber,
                                Occupation = "",
                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                SO = item.suposof,
                                SOName = item.Suposofname,
                                bcolor = db.ColorTbs.Where(a => a.cardname == "Sarvant").Select(x => x.backcolor).FirstOrDefault()
                            });
                        }
                        else {

                            servantlist.Add(new ServantModel
                            {
                                Id = item.Id,
                                Name = item.Name,
                                CNIC = item.CNIC,
                                Expiry = Convert.ToDateTime(item.ExpiryDate).ToString("MMM-dd-yyyy"),
                                DateIssue = Convert.ToDateTime(item.DateIssue).ToString("MMM-dd-yyyy"),

                             
                                typework = item.Type,
                                Logoimg1 = imagePath,
                                Pimg = new Uri(Server.MapPath("~/" + item.Img)).AbsoluteUri,
                                Barcodeimg = ms.ToArray(),
                                srnumber = item.Srnumber,
                                Occupation = "",
                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                SO = item.suposof,
                                SOName = item.Suposofname,
                                bcolor = db.ColorTbs.Where(a => a.cardname == "Sarvant").Select(x => x.backcolor).FirstOrDefault(),
                                ShopName = db.ShopsTbs.Where(a => a.Id == item.ShpId).Select(x => x.ShopeNumber).FirstOrDefault()

                            });


                        }

                    }
                }

           

              
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = servantlist;
    
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();

            }

        }

    }
}