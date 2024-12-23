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
    public partial class HouseOccupancy : System.Web.UI.Page
    {
        List<HOccupancyModel> listOccupancylist = new List<HOccupancyModel>();
        List<House> houselist = new List<House>();
        List<Tenant> Tenantlist = new List<Tenant>();
        List<Allottee> AllotteeList = new List<Allottee>();
        List<Purchaser> Purchaserlist = new List<Purchaser>();
        List<FamilytreeTB> Familylist = new List<FamilytreeTB>();
        List<ResidentTb> ResidentList = new List<ResidentTb>();
        int filter1 = 0;
        FalconHouseEntities1 db = new FalconHouseEntities1();
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
                {}
                houselist = new List<House>();
                ResidentList = new List<ResidentTb>();
                Purchaserlist = new List<Purchaser>();
                AllotteeList = new List<Allottee>();
                Familylist = new List<FamilytreeTB>();
                Tenantlist = new List<Tenant>();
                Familylist = db.FamilytreeTBs.ToList();
                Purchaserlist = db.Purchasers.ToList();
                AllotteeList = db.Allottees.ToList();
                if (callh==0)
                {
                    houselist = db.Houses.Where(x => (db.ResidentTbs.Any(a => a.houseid == x.Id && a.checkoutDate == null))).ToList();
                }
                else
                {
                    houselist = db.Houses.Where(x => x.Id==callh).ToList();
                }
               
                Tenantlist = db.Tenants.ToList();
                ResidentList = db.ResidentTbs.ToList();
                foreach (var item in houselist)
                {
                    if (item.ResidentTbs.Count()!=0)
                    {
                        string basepath = db.Accesses.Where(a => a.UserId == 1).Select(x => x.FormName).FirstOrDefault();
                        if (callh==0)
                        {
                            #region if calh==0
                            foreach (var Res in item.ResidentTbs.Where(a => a.checkoutDate == null))
                            {
                                if (Res.type == "Owner")
                                {
                                    if (Res.ownertyp == "Alottee")
                                    {
                                        int memid = Convert.ToInt32(Res.memberid);
                                        string Img = db.Documents.Where(a => a.type == "Allottee" && a.FileType == "Image" && a.memberid == memid).Select(x => x.FilePath).FirstOrDefault();
                                      
                                        Allottee occname = db.Allottees.Where(a => a.Id == memid).FirstOrDefault();
                                        listOccupancylist.Add(new HOccupancyModel { OccupiedBy = occname.Name + "(Allottee)", CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.type == "Alottee" && a.sponsirid == memid))
                                        {
                                            listOccupancylist.Add(new HOccupancyModel { Action = basepath+"/HouseOccupancy.aspx?calhno=" + item.HouseNo, OccupiedBy = family.Name, Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = family.CNIC, Hnumber = item.HouseNo, Relation = family.Relation, Img = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri });
                                        }
                                    }
                                    else
                                    {
                                        int memid = Convert.ToInt32(Res.memberid);
                                        string Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == memid).Select(x => x.FilePath).FirstOrDefault();
                                        
                                        Purchaser occname = db.Purchasers.Where(a => a.Id == memid).FirstOrDefault();
                                        if (occname != null)
                                        {
                                            listOccupancylist.Add(new HOccupancyModel { Action = basepath + "/HouseOccupancy.aspx?calhno=" + item.HouseNo, OccupiedBy = occname.Name + "(Transfer)", Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });
                                        }
                                    }
                                }
                                else
                                {
                                    int memid = Convert.ToInt32(Res.memberid);
                                    string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == memid).Select(x => x.FilePath).FirstOrDefault();
                                  
                                    Tenant occname = db.Tenants.Where(a => a.Id == memid).FirstOrDefault();
                                    listOccupancylist.Add(new HOccupancyModel { Action = basepath+"/HouseOccupancy.aspx?calhno=" + item.HouseNo, OccupiedBy = occname.Name + "(Tenant)", Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });


                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region if calh==0
                            foreach (var Res in item.ResidentTbs)
                            {
                                if (Res.type == "Owner")
                                {
                                    if (Res.ownertyp == "Alottee")
                                    {
                                        string Img = db.Documents.Where(a => a.type == "Allottee" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        int memid = Convert.ToInt32(Res.memberid);
                                        Allottee occname = db.Allottees.Where(a => a.Id == memid).FirstOrDefault();
                                        listOccupancylist.Add(new HOccupancyModel { OccupiedBy = occname.Name + "(Allottee)", CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });
                                        foreach (var family in db.FamilytreeTBs.Where(a => a.type == "Alottee" && a.sponsirid == memid))
                                        {
                                            listOccupancylist.Add(new HOccupancyModel { Action = basepath+"/HouseOccupancy.aspx", OccupiedBy = family.Name, Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = family.CNIC, Hnumber = item.HouseNo, Relation = family.Relation, Img = new Uri(Server.MapPath("~/" + family.Img)).AbsoluteUri });
                                        }
                                    }
                                    else
                                    {
                                        string Img = db.Documents.Where(a => a.type == "Transfer" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                        int memid = Convert.ToInt32(Res.memberid);
                                        Purchaser occname = db.Purchasers.Where(a => a.Id == memid).FirstOrDefault();
                                        listOccupancylist.Add(new HOccupancyModel { Action = basepath+"/HouseOccupancy.aspx", OccupiedBy = occname.Name + "(Transfer)", Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });
                                    }
                                }
                                else
                                {
                                    string Img = db.Documents.Where(a => a.type == "Tenant" && a.FileType == "Image" && a.memberid == item.Id).Select(x => x.FilePath).FirstOrDefault();
                                    int memid = Convert.ToInt32(Res.memberid);
                                    Tenant occname = db.Tenants.Where(a => a.Id == memid).FirstOrDefault();
                                    listOccupancylist.Add(new HOccupancyModel { Action = basepath+"/HouseOccupancy.aspx", OccupiedBy = occname.Name + "(Tenant)", Date = Convert.ToDateTime(Res.Date).ToString("d"), CNIC = occname.CNIC, Hnumber = item.HouseNo, Relation = "SELF", Img = new Uri(Server.MapPath("~/" + Img)).AbsoluteUri });


                                }
                            }
                            #endregion
                        }




                    }
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = listOccupancylist;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }
    }
}