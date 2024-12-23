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
    public partial class ResidentCard : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string selected = "";
                try
                {
                    selected = Request.QueryString["Id"].ToString();

                }
                catch (Exception ex)
                { }
                string imagePath = new Uri(Server.MapPath("~/images/Logo.jpeg")).AbsoluteUri;
                List<ServantModel> servantlist = new List<ServantModel>();

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                MemoryStream ms = new MemoryStream();
                try
                {
                    if (selected=="0")
                    {
                        #region AllResident cards
                        foreach (var item in db.ResidentTbs.Where(a => a.checkoutDate == null ).ToList())
                        {
                            if (item.type == "Owner")
                            {
                                if (item.ownertyp == "Owner")
                                {
                                    #region if owner is Allottee
                                    Allottee Owner = new Allottee();
                                    int memid = Convert.ToInt32(item.memberid);
                                    Owner = db.Allottees.Where(a => a.Id == memid).FirstOrDefault();
                                    string Img = db.Documents.Where(a => a.type == "Allottee" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                    if (Img == null)
                                    {
                                        Img = "Upload/Residant/profile.png";
                                    }
                                    if (item.Srnumber != null)
                                    {
                                        System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.Srnumber, Color.Black, Color.White, 100, 30);
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
                                        Name = Owner.Name,
                                        CNIC = Owner.CNIC,
                                        Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                        DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                          ,
                                       
                                        HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                          ,
                                        typework = "Self",
                                        Logoimg1 = imagePath,
                                        Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                        Barcodeimg = ms.ToArray(),
                                        srnumber = item.Srnumber,
                                        Occupation = item.Occupation,
                                        Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                        SO = Owner.Sof,
                                        SOName = Owner.SO
                                    });
                                    #region Family
                                    string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                    foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Alottee"))
                                    {
                                        string so = "";
                                        string soname = "";
                                        if (family.so !=null)
                                        {
                                            so = family.so;
                                            soname = family.soname;
                                        }
                                        else
                                        {
                                            so = family.Relation;
                                            soname = Owner.Name;
                                        }
                                        servantlist.Add(new ServantModel
                                        {
                                            Id = family.Id,
                                            Name = family.Name,
                                            CNIC = family.CNIC,
                                            Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy") ,
                                            HouseNo = Hnumber  ,
                                            typework = "Family",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = family.Srnumber,
                                            Occupation = "",
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = so,
                                            SOName = soname
                                        });
                                        #endregion

                                    }
                                    #endregion

                                }
                                else
                                {
                                    try
                                    {
                                        #region If Owner is Purchaser
                                        Purchaser Owner = new Purchaser();
                                        int memid = Convert.ToInt32(item.memberid);
                                        Owner = db.Purchasers.Where(a => a.Id == memid).FirstOrDefault();
                                        string Img = null;
                                        try
                                        {
                                            Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        }
                                        catch (Exception)
                                        {

                                        }

                                        if (Img == null)
                                        {
                                            Img = "Upload/Residant/profile.png";
                                        }
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
                                            Name = Owner.Name,
                                            CNIC = Owner.CNIC,
                                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                              ,
                                           
                                            HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                              ,
                                            typework = "Self",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = item.Srnumber,
                                            Occupation = item.Occupation,
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri ,  SO = Owner.Sof,
                                            SOName = Owner.SO
                                        });

                                        #endregion
                                        #region Family
                                        string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Purchaser"))
                                        {
                                            servantlist.Add(new ServantModel
                                            {
                                                Id = family.Id,
                                                Name = family.Name,
                                                CNIC = family.CNIC,
                                                Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                                DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                       ,

                                                HouseNo = Hnumber
                       ,
                                                typework = "Family",
                                                Logoimg1 = imagePath,
                                                Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                                Barcodeimg = ms.ToArray(),
                                                srnumber = family.Srnumber,
                                                Occupation = "",
                                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                                SO = family.Relation,
                                                SOName = Owner.Name
                                            });
                                        }
                                            #endregion
                                        }
                                    catch (Exception ex)
                                    {


                                    }

                                }
                            }
                            else
                            {
                                Tenant Owner = new Tenant();
                                int memid = Convert.ToInt32(item.memberid);
                                Owner = db.Tenants.Where(a => a.Id == memid).FirstOrDefault();
                                if (Owner.Remarks!=null)
                                {
                                    if (Owner.Remarks.Contains("Foreigner"))
                                    {

                                    }
                                    else
                                    {
                                        #region If Resident is Tenant and not Foriegner
                                        string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        if (Img == null)
                                        {
                                            Img = "Upload/Residant/profile.png";
                                        }
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
                                            Name = Owner.Name,
                                            CNIC = Owner.CNIC,
                                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                              ,

                                            HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                              ,
                                            typework = "Tenant",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = item.Srnumber,
                                            Occupation = item.Occupation,
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = Owner.Sof,
                                            SOName = Owner.SO
                                        });

                                        #endregion
                                        #region Family
                                        string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Tenant"))
                                        {
                                            servantlist.Add(new ServantModel
                                            {
                                                Id = family.Id,
                                                Name = family.Name,
                                                CNIC = family.CNIC,
                                                Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                                DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                       ,

                                                HouseNo = Hnumber
                       ,
                                                typework = "Family",
                                                Logoimg1 = imagePath,
                                                Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                                Barcodeimg = ms.ToArray(),
                                                srnumber = family.Srnumber,
                                                Occupation = "",
                                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                                SO = family.Relation,
                                                SOName = Owner.Name
                                            });
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region If Resident is Tenant and not Foriegner
                                    string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                    if (Img == null)
                                    {
                                        Img = "Upload/Residant/profile.png";
                                    }
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
                                        Name = Owner.Name,
                                        CNIC = Owner.CNIC,
                                        Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                        DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                          ,

                                        HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                          ,
                                        typework = "Tenant",
                                        Logoimg1 = imagePath,
                                        Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                        Barcodeimg = ms.ToArray(),
                                        srnumber = item.Srnumber,
                                        Occupation = item.Occupation,
                                        Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                        SO = Owner.Sof,
                                        SOName = Owner.SO
                                    });

                                    #endregion
                                }


                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region AllResident cards
                        foreach (var item in db.ResidentTbs.Where(a => a.checkoutDate == null && a.Selected==1).ToList())
                        {
                            if (item.type == "Owner")
                            {
                                if (item.ownertyp == "Owner")
                                {
                                    #region if owner is Allottee
                                    Allottee Owner = new Allottee();
                                    int memid = Convert.ToInt32(item.memberid);
                                    Owner = db.Allottees.Where(a => a.Id == memid).FirstOrDefault();
                                    string Img = db.Documents.Where(a => a.type == "Allottee" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                    if (Img == null)
                                    {
                                        Img = "Upload/Residant/profile.png";
                                    }
                                    if (item.Srnumber != null)
                                    {
                                        System.Drawing.Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, item.Srnumber, Color.Black, Color.White, 100, 30);
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
                                        Name = Owner.Name,
                                        CNIC = Owner.CNIC,
                                        Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                        DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                          ,
                                      
                                        HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                          ,
                                        typework = "Self",
                                        Logoimg1 = imagePath,
                                        Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                        Barcodeimg = ms.ToArray(),
                                        srnumber = item.Srnumber,
                                        Occupation = item.Occupation,
                                        Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                        SO = Owner.Sof,
                                        SOName = Owner.SO
                                    });

                                    #endregion
                                    #region Family
                                    string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                    foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Alottee"))
                                    {
                                        servantlist.Add(new ServantModel
                                        {
                                            Id = family.Id,
                                            Name = family.Name,
                                            CNIC = family.CNIC,
                                            Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                   ,

                                            HouseNo = Hnumber
                   ,
                                            typework = "Family",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = family.Srnumber,
                                            Occupation = "",
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = family.Relation,
                                            SOName = Owner.Name
                                        });
                                    }
                                    #endregion
                                }
                                else
                                {
                                    try
                                    {
                                        #region If Owner is Purchaser
                                        Purchaser Owner = new Purchaser();
                                        int memid = Convert.ToInt32(item.memberid);
                                        Owner = db.Purchasers.Where(a => a.Id == memid).FirstOrDefault();
                                        string Img = null;
                                        try
                                        {
                                            Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        }
                                        catch (Exception)
                                        {

                                        }

                                        if (Img == null)
                                        {
                                            Img = "Upload/Residant/profile.png";
                                        }
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
                                            Name = Owner.Name,
                                            CNIC = Owner.CNIC,
                                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                              ,
                                           
                                            HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                              ,
                                            typework = "Self",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = item.Srnumber,
                                            Occupation = item.Occupation,
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = Owner.Sof,
                                            SOName = Owner.SO
                                        });

                                        #endregion
                                        #region Family
                                        string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Purchaser"))
                                        {
                                            servantlist.Add(new ServantModel
                                            {
                                                Id = family.Id,
                                                Name = family.Name,
                                                CNIC = family.CNIC,
                                                Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                                DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                       ,

                                                HouseNo = Hnumber
                       ,
                                                typework = "Family",
                                                Logoimg1 = imagePath,
                                                Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                                Barcodeimg = ms.ToArray(),
                                                srnumber = family.Srnumber,
                                                Occupation = "",
                                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                                SO = family.Relation,
                                                SOName = Owner.Name
                                            });
                                        }
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {


                                    }

                                }
                            }
                            else
                            {
                                Tenant Owner = new Tenant();
                                int memid = Convert.ToInt32(item.memberid);
                                Owner = db.Tenants.Where(a => a.Id == memid).FirstOrDefault();
                                if (Owner.Remarks!=null)
                                {
                                    if (Owner.Remarks.Contains("Foreigner") && Owner.Remarks != null)
                                    {

                                    }
                                    else
                                    {
                                        #region If Resident is Tenant and not Foriegner
                                        string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        if (Img == null)
                                        {
                                            Img = "Upload/Residant/profile.png";
                                        }
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
                                            Name = Owner.Name,
                                            CNIC = Owner.CNIC,
                                            Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                              ,

                                            HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                              ,
                                            typework = "Tenant",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = item.Srnumber,
                                            Occupation = item.Occupation,
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = Owner.Sof,
                                            SOName = Owner.SO
                                        });

                                        #endregion
                                        #region Family
                                        string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Tenant"))
                                        {
                                            servantlist.Add(new ServantModel
                                            {
                                                Id = family.Id,
                                                Name = family.Name,
                                                CNIC = family.CNIC,
                                                Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                                DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                       ,

                                                HouseNo = Hnumber
                       ,
                                                typework = "Family",
                                                Logoimg1 = imagePath,
                                                Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                                Barcodeimg = ms.ToArray(),
                                                srnumber = family.Srnumber,
                                                Occupation = "",
                                                Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                                SO = family.Relation,
                                                SOName = Owner.Name
                                            });
                                        }
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region If Resident is Tenant and not Foriegner
                                    string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                    if (Img == null)
                                    {
                                        Img = "Upload/Residant/profile.png";
                                    }
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
                                        Name = Owner.Name,
                                        CNIC = Owner.CNIC,
                                        Expiry = Convert.ToDateTime(item.Cardexp).ToString("MMM-dd-yyyy"),
                                        DateIssue = Convert.ToDateTime(item.CardIssue).ToString("MMM-dd-yyyy")

                          ,

                                        HouseNo = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault()
                          ,
                                        typework = "Tenant",
                                        Logoimg1 = imagePath,
                                        Pimg = new Uri(Server.MapPath("~/" + Owner.Image)).AbsoluteUri,
                                        Barcodeimg = ms.ToArray(),
                                        srnumber = item.Srnumber,
                                        Occupation = item.Occupation,
                                        Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                        SO = Owner.Sof,
                                        SOName = Owner.SO
                                    });

                                    #endregion
                                    #region Family
                                    string Hnumber = db.Houses.Where(a => a.Id == item.houseid).Select(x => x.HouseNo).FirstOrDefault();
                                    foreach (var family in db.FamilytreeTBs.Where(a => a.sponsirid == Owner.Id && a.type == "Tenant"))
                                    {
                                        servantlist.Add(new ServantModel
                                        {
                                            Id = family.Id,
                                            Name = family.Name,
                                            CNIC = family.CNIC,
                                            Expiry = Convert.ToDateTime(family.Cardexp).ToString("MMM-dd-yyyy"),
                                            DateIssue = Convert.ToDateTime(family.CardIssue).ToString("MMM-dd-yyyy")

                   ,

                                            HouseNo = Hnumber
                   ,
                                            typework = "Family",
                                            Logoimg1 = imagePath,
                                            Pimg = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri,
                                            Barcodeimg = ms.ToArray(),
                                            srnumber = family.Srnumber,
                                            Occupation = "",
                                            Stamp = new Uri(Server.MapPath("~/images/Stamp.png")).AbsoluteUri,
                                            SO = family.Relation,
                                            SOName = Owner.Name
                                        });
                                    }
                                    #endregion
                                }


                            }
                        }
                        #endregion
                    }


                }
                catch (Exception ex)
                {

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