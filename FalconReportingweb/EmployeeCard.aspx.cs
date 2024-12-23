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
    public partial class EmployeeCard : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string selected = "";
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

                if (selected == "0")
                {
                    foreach (var item in db.Employees.ToList())
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
                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                        ,
                            HouseNo = item.Sof
                        ,
                            typework = item.Designation,
                            Logoimg1 = imagePath,
                            Pimg = new Uri(Server.MapPath("~/" + item.Img)).AbsoluteUri,
                            Barcodeimg = ms.ToArray(),
                            srnumber = item.Srnumber,
                            Occupation = item.Address,
                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri
                        });

                    }
                }
                else
                {
                    foreach (var item in db.Employees.Where(a=>a.Selected==1).ToList())
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
                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                        ,
                            HouseNo = item.Sof
                        ,
                            typework = item.Designation,
                            Logoimg1 = imagePath,
                            Pimg = new Uri(Server.MapPath("~/" + item.Img)).AbsoluteUri,
                            Barcodeimg = ms.ToArray(),
                            srnumber = item.Srnumber,
                            Occupation = item.Address,
                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri
                        });

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