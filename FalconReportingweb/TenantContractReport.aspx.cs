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
using FalconReportingweb.Code;
using Microsoft.Reporting.WebForms;
using CrystalDecisions.Web;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;

namespace FalconReportingweb 
{
    public partial class TenantContractReport : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected static string strConnect;

        public SqlConnection _cn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {


                bindReport(DateTime.Now.AddMonths(-11),DateTime.Today);


                //List<TenantModel> TenantList = new List<TenantModel>();



                //foreach (var item in db.Tenants.ToList().OrderBy(X=>X.HouseId))
                //{
                //    if (item.Date != null )
                //    {
                //        if (item.Date.Value.AddMonths(11) > DateTime.Today)

                //        {
                //            TenantList.Add(new TenantModel
                //            {

                //                Name = item.Name,
                //                CNIC = item.CNIC,

                //                ExpiryDate = Convert.ToDateTime(item.Date.Value.AddMonths(11)),
                //                Date = item.Date.Value,
                //                HouseNo = db.Houses.Where(a => a.Id == item.HouseId).Select(x => x.HouseNo).FirstOrDefault(),
                //                ContractNo = item.ContactNo,

                //            });

                //        }
                //    }
                //}








                //ReportDataSource reportDataSource = new ReportDataSource();
                //// Must match the DataSource in the RDLC
                //reportDataSource.Name = "DataSet";
                //reportDataSource.Value = TenantList;

                ////LocalReport report = new LocalReport();
                ////report.ReportPath = "Reports\\RentContractReport.rdlc";
                ////report.EnableExternalImages = true;
                ////report.DataSources.Add(reportDataSource);

                //ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                //ReportViewer1.DataBind();

            }

        }


        protected void filterbtn_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(fromdate.Text);
            DateTime enddate = Convert.ToDateTime(Todate.Text);

            bindReport(start, enddate);

            //List<TenantModel> TenantList = new List<TenantModel>();



            //foreach (var item in db.Tenants.ToList().OrderBy(X => X.HouseId))
            //{
            //    if (item.Date != null)
            //    {
            //        if (item.Date.Value >= start && item.Date.Value<=enddate)

            //        {
            //            TenantList.Add(new TenantModel
            //            {

            //                Name = item.Name,
            //                CNIC = item.CNIC,

            //                ExpiryDate = Convert.ToDateTime(item.Date.Value.AddMonths(11)),
            //                Date = item.Date.Value,
            //                HouseNo = db.Houses.Where(a => a.Id == item.HouseId).Select(x => x.HouseNo).FirstOrDefault(),
            //                ContractNo = item.ContactNo,

            //            });

            //        }
            //    }
            //}
            //ReportDataSource reportDataSource = new ReportDataSource();

            //reportDataSource.Name = "DataSet";
            //reportDataSource.Value = TenantList;
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //ReportViewer1.DataBind();
        }

        private void bindReport(DateTime Start, DateTime enddate)
        {

            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("~/RPT/02TenantContractReport.rpt"));
            DataTable dt = new DataTable();
            dt = GetTenantContractReport(Start, enddate);
            if (dt.Rows.Count > 0)
            {

                rptDoc.SetDataSource(dt);
                CrystalReportViewer2.ReportSource = rptDoc;
                Session["bildata"] = rptDoc;
            }

        }

        public DataTable GetTenantContractReport(DateTime fromDate, DateTime toDate)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "usp_GetTenantContractReport";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);


            }
            catch (Exception ex)
            { throw ex; }

           dt = GetDataByDataTable(cmd);

            return dt;
        }


        public DataTable GetDataByDataTable(SqlCommand cmd)
        {
            strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"]);

            SqlConnection oConnection = new SqlConnection(strConnect);
            _cn = oConnection;
            DataTable dt = new DataTable();
            cmd.Connection = _cn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandTimeout = 180;
            if (_cn.State != ConnectionState.Closed)
            {
                _cn.Close();
            }
            da.Fill(dt);
            return dt;
            


        }
    }
}