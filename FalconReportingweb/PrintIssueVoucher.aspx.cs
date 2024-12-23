using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FalconReporting.DbClass;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace FalconReportingweb
{
    public partial class PrintIssueVoucher : System.Web.UI.Page
    {
        string Date = null;
        string Type = null;
        int houseid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IssueID"] != null)
            {

                //&& Request.QueryString["Type"] != null)
                //{
                //    Date = Request.QueryString["Date"].ToString();
                //    Type = Request.QueryString["Type"].ToString();

                bindreport(Convert.ToInt32(Request.QueryString["IssueID"]));
                //}
                //else
                //{
                //    displaylbl.Text = "Please Select Filter and get Bill";
                //}
            }
        
        }

        //private void setDBLOGONforREPORT(ConnectionInfo myconnectioninfo)
        //{
        //    TableLogOnInfos mytableloginfos = new TableLogOnInfos();
        //    mytableloginfos = CrystalReportViewer2.LogOnInfo;
        //    foreach (TableLogOnInfo myTableLogOnInfo in mytableloginfos)
        //    {
        //        myTableLogOnInfo.ConnectionInfo = myconnectioninfo;
        //    }

        //}
        public void bindreport(int Id)
        {

            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();


                ReportDocument rptDoc = new ReportDocument();
                //DsPrintBills dsrpt = new DsPrintBills();
                rptDoc.Load(Server.MapPath("~/RPT/01rptMaterialIsue.rpt"));
                //dt.TableName = "Crystal Report";
                if (!IsPostBack)
                {
                    dt = GetIssueVoucher(Id);
                    if (dt.Rows.Count > 0)
                    {
                        rptDoc.SetDataSource(dt);
                        CrystalReportViewer2.ReportSource = rptDoc;
                        ExportFormatType formatType = ExportFormatType.NoFormat;
                        formatType = ExportFormatType.PortableDocFormat;
                        rptDoc.ExportToHttpResponse(formatType, Response, true, "VoucherIssued");
                        
                    }
                   
                    Session["bildata"] = rptDoc;
                }
                else
                {
                    CrystalReportViewer2.ReportSource = (ReportDocument)Session["bildata"];
                }

               
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable GetIssueVoucher(int Id)
        {
            DataTable dt = new DataTable();
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                // Assuming "GetRecordById" is the name of your stored procedure
                string storedProcedureName = "usp_GetMaterialIssuedByIssueNo";

                SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Assuming Id is the parameter for the stored procedure
                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataAdapter adt = new SqlDataAdapter(cmd);
      

                conn.Open();
                adt.Fill(dt);
                conn.Close();
            }


            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //    string sql = "usp_GetMaterialIssuedByIssueNo";

            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.Parameters.AddWithValue("@Id", Id);
            //    SqlDataAdapter adt = new SqlDataAdapter(cmd);
               
            //    cmd.Connection.Open();
            //    adt.Fill(dt);
            //    cmd.Connection.Close();
            //}


            return dt;
        }

        //protected void filterbtn_Click(object sender, EventArgs e)
        //{
        //    Date = monthtxt.Text;
        //    Type = houseddr.SelectedValue.ToString();
        //    Response.Redirect("printbillpg.aspx?Date=" + monthtxt.Text + "&Type=" + houseddr.SelectedValue.ToString());
        //}
    }
}