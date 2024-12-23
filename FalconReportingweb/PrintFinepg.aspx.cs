using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FalconReporting.DbClass;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace FalconReporting
{
    public partial class PrintFinepg : System.Web.UI.Page
    {
        string Date = null;
        string Type = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Request.QueryString["Type"] != null)
            {
                //Date = Request.QueryString["Date"].ToString();
                Type = Request.QueryString["Type"].ToString();
                bindreport();
            }
            else
            {
                displaylbl.Text = "Please Select Filter and get Fine";
            }

        }

        private void setDBLOGONforREPORT(ConnectionInfo myconnectioninfo)
        {
            TableLogOnInfos mytableloginfos = new TableLogOnInfos();
            mytableloginfos = CrystalReportViewer1.LogOnInfo;
            foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos)
            {
                myTableLogOnInfo.ConnectionInfo = myconnectioninfo;
            }

        }
        public void bindreport()
        {

            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();


                ReportDocument rptDoc = new ReportDocument();
                Finedbset dsrpt = new Finedbset();
                rptDoc.Load(Server.MapPath("~/RPT/crPrintFine.rpt"));
                dt.TableName = "Crystal Report";
                dt = getAllOrders();
                if (dt.Rows.Count > 0)
                {
                    dsrpt.Tables[0].Merge(dt, true, MissingSchemaAction.Ignore);

                }
                rptDoc.SetDataSource(dsrpt);
                CrystalReportViewer1.ReportSource = rptDoc;
                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = "182.191.69.176";
                myConnectionInfo.DatabaseName = "FalconHouse";
                myConnectionInfo.UserID = "fartech";
                myConnectionInfo.Password = "Admin#*02";
                setDBLOGONforREPORT(myConnectionInfo);
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable getAllOrders()
        {
            DataTable dtrpt = new DataTable();
            DataSet dsinfo = new DataSet();

            double Arrears = 0, amount = 0;
            double Surcharge = 0;
            try
            {
                dtrpt.Columns.Add("HouseNo", typeof(string));
                dtrpt.Columns.Add("Reason", typeof(string));
                dtrpt.Columns.Add("Month", typeof(string));
                dtrpt.Columns.Add("Date", typeof(DateTime));
                dtrpt.Columns.Add("Fine", typeof(double));
                dtrpt.Columns.Add("Paid", typeof(double));
               
               
                
               


                string q = "";






                //DateTime dt1New = Convert.ToDateTime(Date);
                //string s1New = dt1New.ToString("MMMM,yyyy");
                //string s2New = Date.ToString();

                //q = "select top 3 * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where BillingMonth = '" + s1New + "'";

                q = @"SELECT dbo.Fine.Id,dbo.Fine.HouseId, dbo.House.HouseNo, FORMAT(dbo.Fine.Date, 'MMMM,yyyy') AS Month,  dbo.Fine.Date, dbo.Fine.Fine, dbo.Fine.Reason, dbo.Fine.Paid
FROM     dbo.Fine INNER JOIN
                         dbo.House ON dbo.Fine.HouseId = dbo.House.Id
				  Where  HouseId='" + Type + "' AND Paid='Pending'";

                dsinfo = db.funGetDataSet(q);

                for (int j = 0; j < dsinfo.Tables[0].Rows.Count; j++)
                {
                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Reason"].ToString(), dsinfo.Tables[0].Rows[j]["Month"].ToString(),Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Date"]),Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Fine"]),0);
                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Reason"].ToString(), dsinfo.Tables[0].Rows[j]["Month"].ToString(), Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Date"]), Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Fine"]), 0);
                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Reason"].ToString(), dsinfo.Tables[0].Rows[j]["Month"].ToString(), Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Date"]), Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Fine"]), 0); 

                }
               
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            return dtrpt;
        }

    }
}