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
using FalconReportingweb;

namespace FalconReporting
{
    public partial class PrintBillpg : System.Web.UI.Page
    {
        string Date=null;
        string Type=null;
        int houseid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Date"] != null && Request.QueryString["Type"] != null)
            {
                Date = Request.QueryString["Date"].ToString();
                Type = Request.QueryString["Type"].ToString();
               
                bindreport();
            }
            else
            {
                displaylbl.Text = "Please Select Filter and get Bill";
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
        public void bindreport()
        {

            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();


                ReportDocument rptDoc = new ReportDocument();
                DsPrintBills dsrpt = new DsPrintBills();
                rptDoc.Load(Server.MapPath("~/RPT/crPrintBillDemo.rpt"));
                dt.TableName = "Crystal Report";
                if (!IsPostBack)
                {
                    dt = getAllOrders();
                    if (dt.Rows.Count > 0)
                    {
                        dsrpt.Tables[0].Merge(dt, true);

                    }
                    rptDoc.SetDataSource(dsrpt);
                    CrystalReportViewer2.ReportSource = rptDoc;
                    Session["bildata"] = rptDoc;
                }
                else
                {
                    CrystalReportViewer2.ReportSource = (ReportDocument)Session["bildata"];
                }
                
                //ConnectionInfo myConnectionInfo = new ConnectionInfo();
                //myConnectionInfo.ServerName = "DESKTOP-LF88M85\\SQLEXPRESS";
                //myConnectionInfo.DatabaseName = "FalconHouse";
                //myConnectionInfo.UserID = "falcon";
                //myConnectionInfo.Password = "falcon";
                //myConnectionInfo.ServerName = "182.191.69.176";
                //myConnectionInfo.DatabaseName = "FalconHouse";
                //myConnectionInfo.UserID = "fartech";
                //myConnectionInfo.Password = "Admin#*02";
                //setDBLOGONforREPORT(myConnectionInfo);
            }
            catch (Exception ex)
            {

            }
        }
       
        public DataTable getAllOrders()
        {
            DataTable dtrpt = new DataTable();
            DataSet dsinfo = new DataSet();
            DataSet dsinfo1 = new DataSet();
            double Arrears = 0, amount = 0;
            double Surcharge = 0; DateTime? lastMonthPaidDate = null; DateTime? PaidDueMonth = null;
            double Fine = 0;
            try
            {
                dtrpt.Columns.Add("HouseNo", typeof(string));
                dtrpt.Columns.Add("Type", typeof(string));
                
                dtrpt.Columns.Add("ExpenseHead", typeof(string));
                dtrpt.Columns.Add("DueDate", typeof(string));
                dtrpt.Columns.Add("Amount", typeof(double));
                dtrpt.Columns.Add("BillingMonth", typeof(string));
                dtrpt.Columns.Add("Surcharge", typeof(double));
                dtrpt.Columns.Add("Arrears", typeof(double));
                dtrpt.Columns.Add("HNo", typeof(string));
                dtrpt.Columns.Add("title", typeof(string));
                dtrpt.Columns.Add("SinglePayable", typeof(Double));
                dtrpt.Columns.Add("Payable", typeof(Double));
                dtrpt.Columns.Add("Paid", typeof(Double));
                dtrpt.Columns.Add("Arears", typeof(Double));
                dtrpt.Columns.Add("Surcharges", typeof(Double));
                dtrpt.Columns.Add("expid", typeof(Double));
                dtrpt.Columns.Add("detail", typeof(string));
                dtrpt.Columns.Add("detail2", typeof(string));
                dtrpt.Columns.Add("detail3", typeof(string));
                dtrpt.Columns.Add("detail4", typeof(string));
                dtrpt.Columns.Add("HouseId", typeof(int));
                dtrpt.Columns.Add("HNos", typeof(int));
                dtrpt.Columns.Add("Id", typeof(int));
                dtrpt.Columns.Add("PaidDate", typeof(string));
                dtrpt.Columns.Add("Fine", typeof(double));
                //dtrpt.Columns.Add("Date",typeof(string));
                string q = "";






                DateTime dt1New = Convert.ToDateTime(Date);
                string DueMonth = dt1New.ToString("MMMM,yyyy");
                string s2New = Date.ToString();

                //q = "select top 3 * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where BillingMonth = '" + DueMonth + "'";
                if (Type == "-2")
                {
                    q = "select  * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId LEFT join Fine ON Fine.HouseId = HouseBills.HouseId where BillingMonth = '" + DueMonth + "' and dbo.House.Type='SD'" + "order by HNos,Expenses.Id"; 
                }
                else if (Type == "-1")
                {
                    q = "select  * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId LEFT join Fine ON Fine.HouseId = HouseBills.HouseId where BillingMonth = '" + DueMonth + "' and dbo.House.Type='IH'" + "order by HNos,Expenses.Id";

                }
                else if (Type == "0")
                {
                    q = "select  * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where BillingMonth = '" + DueMonth + "'" + "order by dbo.House.Type,HNos,Expenses.Id ";


                }
                else
                {
                    //q = "select  * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where BillingMonth = '" + DueMonth + "' and dbo.House.Id ='" + Type + "'";
                    q = "select * from HouseBills inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId LEFT join Fine ON Fine.HouseId = HouseBills.HouseId where BillingMonth = '" + DueMonth + "' and dbo.House.Id ='" + Type + "'";

                }

                // coment 
                //q = "select  * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where BillingMonth = '" + DueMonth + "'  and dbo.House.Type='IH'";
                dsinfo = db.funGetDataSet(q);

                if (dsinfo.Tables.Count > 0 && dsinfo.Tables[0].Rows.Count > 0) 
                {
                    for (int j = 0; j < dsinfo.Tables[0].Rows.Count; j++)
                    {
                        Arrears = 0; amount = 0; Surcharge = 0;Fine = 0;
                        DateTime dt = Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Due_Date"].ToString());
                        string billStatus = dsinfo.Tables[0].Rows[j]["Status"].ToString();
                        string s = dt.ToString("MMMM/dd/yyyy");
                        //Fine

                        DateTime FineDate;
                        var fineDateString = dsinfo.Tables[0].Rows[j]["FineDate"].ToString();

                        if (!string.IsNullOrEmpty(fineDateString))
                        {
                            FineDate = Convert.ToDateTime(fineDateString);
                        }
                        else
                        {
                            FineDate = DateTime.MinValue; // or you can set a specific default date, e.g., DateTime.Today
                        }





                        //DateTime FineDate = Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["FineDate"].ToString());

                        if (FineDate.Month < dt.Month && FineDate.Year == dt.Year)
                        {
                            Fine = Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Fine"]);
                        }

                        string query = "select Top 1 * from HouseBills  inner join House ON House.Id = HouseBills.HouseId inner join Expenses ON Expenses.Id = HouseBills.ExpenseId where ExpenseId='" + dsinfo.Tables[0].Rows[j]["ExpenseId"] + "' AND Date <'" + Convert.ToDateTime(DueMonth) + "' and dbo.House.Id ='" + Type + "' ORDER BY Date desc";
                        DataSet ddss = new System.Data.DataSet();
                        ddss = db.funGetDataSet(query);


                        string ss = "select sum(expenses.amount)Arrears from housebills inner join House ON house.Id = HouseBills.HouseId inner join expenses ON expenses.id = housebills.expenseid where House.Id = '" + dsinfo.Tables[0].Rows[j]["HouseId"] + "' and Status = 'Pending' and not BillingMonth =  '" + DueMonth + "'";
                        DataSet dsArrears = new DataSet();
                        //string ssq = " Select * from HouseBills WHERE Id='" + dsinfo.Tables[0].Rows[j]["Id"]+ "'";
                        //DataSet forsurcharg = new System.Data.DataSet();
                        //forsurcharg = db.funGetDataSet(ssq);
                        //for (int k = 0; k < forsurcharg.Tables[0].Rows.Count; k++)
                        //{
                        //    if (Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Date"]) > DateTime.Now)
                        //    {
                        //        double surch = Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Amount"])*0.1;
                        //        double previoussurch = Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Surcharge"]);
                        //        double newsurcharge = previoussurch + surch;
                        //        string qqs = "UPDATE HouseBills SET Surcharge='" + surch + "' WHERE Id='" + forsurcharg.Tables[0].Rows[k]["Id"] + "'";
                        //        db.insert(qqs);
                        //    }


                        //}


                        //dsArrears = db.funGetDataSet(ss);
                        //if (dsArrears.Tables[0].Rows[0]["Arrears"].ToString() != "")
                        //{

                        //    Surcharge = Convert.ToDouble(dsArrears.Tables[0].Rows[0]["Arrears"]);
                        //    Surcharge = Surcharge * 0.1;
                        //    Arrears = Arrears + Convert.ToDouble(dsArrears.Tables[0].Rows[0]["Arrears"]);
                        //}


                        string ss1 = "select Remaining as Arrears from payment inner join paymentDetails ON payment.id = paymentDetails.payid where  HouseId = '" + dsinfo.Tables[0].Rows[j]["HouseId"] + "' and not billingmonth =  '" + DueMonth + "' and remaining != 0";
                        DataSet dsArrears1 = new DataSet();
                        dsArrears1 = db.funGetDataSet(ss1);
                        if (dsArrears1.Tables[0].Rows.Count > 0 && dsArrears1.Tables[0].Rows[0]["Arrears"].ToString() != "")
                        {
                            Arrears = Arrears + Convert.ToDouble(dsArrears1.Tables[0].Rows[0]["Arrears"]);
                        }

                        ///

                        string ss2 = "select sum(expenses.amount) amount from housebills inner join House ON house.Id = HouseBills.HouseId inner join expenses ON expenses.id = housebills.expenseid where House.Id =  '" + dsinfo.Tables[0].Rows[j]["HouseId"] + "' and  BillingMonth =  '" + DueMonth + "'";
                        DataSet dsArrears2 = new DataSet();
                        dsArrears2 = db.funGetDataSet(ss2);
                        if (dsArrears2.Tables[0].Rows[0]["amount"].ToString() != "")
                        {


                            amount = amount + Convert.ToDouble(dsArrears2.Tables[0].Rows[0]["amount"]);
                        }


                        DateTime d =Convert.ToDateTime(Date);

                        d = d.AddMonths(-1);
                        string sd = d.ToString("dd,MMMM,yyyy");
                        double singlepayable = 0;
                        double Arearss = 0;
                        //if (dsinfo.Tables[0].Rows[j]["Head"].ToString() == "Water")
                        //{
                            //for (int i = 0; i < ddss.Tables[0].Rows.Count; i++)
                            //{
                            //    Arearss = Convert.ToDouble(ddss.Tables[0].Rows[i]["Arears"]);
                            //}


                           // dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), sd, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Customer Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"]);
                            //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), sd, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"]);
                            //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), sd, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"]);
                        //}
                        //else
                        //{
                        //for (int i = 0; i < ddss.Tables[0].Rows.Count; i++)
                        //{
                        //    Arearss = Convert.ToDouble(ddss.Tables[0].Rows[i]["Arears"]);
                        //}
                        string detail1 ="For Credit to Falcon Complex Lahore";
                        string detail2 = "Account No: 1009728851000546.";
                        string detail3 = "Only at MCB Bank Ltd,";
                        string detail4 = "Falcon Complex Branch,AFOHS, Lahore.";
                        string detail5 = detail1 + detail2 + detail3 + detail4;
                        if (j==0)
                        {
                            detail1 ="For Credit to Falcon Complex Lahore";
                        }else
                        if (j==1)
                        {
                            detail1 = detail2;
                        }
                        else if (j == 2)
                        {
                            detail1 = detail3;
                        }
                        else if (j == 3)
                        {
                            detail1 = detail4;
                        }
                        //else
                        //{
                        //    detail1 = "";
                        //}

                        //if (Type == "0")
                        //{

                        //    detail1 ;
                        //} 
                        // Check if the bill status is "Paid"
                        //if (billStatus == "Paid")
                        //{
                        //    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], ddss.Tables[0].Rows[0]["Arears"], ddss.Tables[0].Rows[0]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], ddss.Tables[0].Rows[0]["Arears"], ddss.Tables[0].Rows[0]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], ddss.Tables[0].Rows[0]["Arears"], ddss.Tables[0].Rows[0]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //}
                        //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"],j,detail1,"","","", dsinfo.Tables[0].Rows[j]["HouseId"],dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                        //if (ddss.Tables[0].Rows.Count > 0)
                        //{
                        if (ddss != null && ddss.Tables.Count > 0 && ddss.Tables[0].Rows.Count > 0)
                        {
                            if (ddss.Tables[0].Rows[0]["Status"].ToString() == "Paid")
                            {
                                // Step # 1: If the status of bill is Paid
                                //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], ddss.Tables[0].Rows[0]["Arears"], ddss.Tables[0].Rows[0]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);

                                // Check if paid within due date or after due date

                                if (ddss.Tables[0].Rows[0]["PaidDate"] != DBNull.Value)
                                {
                                    lastMonthPaidDate = Convert.ToDateTime(ddss.Tables[0].Rows[0]["PaidDate"]);
                                }
                                DateTime dueDate = Convert.ToDateTime(ddss.Tables[0].Rows[0]["Due_Date"]);
                                if (lastMonthPaidDate.HasValue && lastMonthPaidDate <= dueDate)
                                {
                                    // Paid within due date, no surcharge
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                }
                                else
                                {
                                    // Paid after due date, add surcharge
                                    double surch = Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Amount"]) * 0.1;
                                    Surcharge += surch;
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], 0, Surcharge, j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], 0, Surcharge, j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                    dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], 0, Surcharge, j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : "", Fine);
                                }


                            }
                            else if (ddss.Tables[0].Rows[0]["Status"].ToString() == "Pending")
                            {
                                // Step # 2: If the status of bill is Pending
                                //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                                // Step # 3: If the Bill Paid After Due_date, Surcharge must add in current bill
                                //if (Convert.ToDateTime(dsinfo.Tables[0].Rows[j]["Due_Date"]) < DateTime.Now)
                                //{
                                //    double surch = Convert.ToDouble(dsinfo.Tables[0].Rows[j]["Amount"]) * 0.1;
                                //    Surcharge += surch;

                                //}
                            }
                            else if (ddss.Tables[0].Rows[0]["Status"].ToString() == "Partial-Paid")
                            {
                                // Step # 2: If the status of bill is Pending
                                //dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"]);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], Fine);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], Fine);
                                dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], Fine);
                            }
                        }
                        else 
                        {
                            dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-B", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Resident Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                            dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-C", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Admin Office Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                            dtrpt.Rows.Add(dsinfo.Tables[0].Rows[j]["HouseNo"].ToString() + "-O", dsinfo.Tables[0].Rows[j]["Type"].ToString(), dsinfo.Tables[0].Rows[j]["Head"].ToString(), s, dsinfo.Tables[0].Rows[j]["Amount"].ToString(), DueMonth, Surcharge, Arrears, dsinfo.Tables[0].Rows[j]["HouseNo"].ToString(), "Bank Copy", singlepayable, dsinfo.Tables[0].Rows[j]["Payable"], dsinfo.Tables[0].Rows[j]["Paid"], dsinfo.Tables[0].Rows[j]["Arears"], dsinfo.Tables[0].Rows[j]["Surcharge"], j, detail1, "", "", "", dsinfo.Tables[0].Rows[j]["HouseId"], dsinfo.Tables[0].Rows[j]["HNos"], dsinfo.Tables[0].Rows[j]["Id"], lastMonthPaidDate.HasValue ? lastMonthPaidDate.Value.ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd"), Fine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            return dtrpt;
        }

        protected void filterbtn_Click(object sender, EventArgs e)
        {
            Date = monthtxt.Text;
            Type = houseddr.SelectedValue.ToString();
            Response.Redirect("printbillpg.aspx?Date="+monthtxt.Text+"&Type="+houseddr.SelectedValue.ToString());
        }
    }
}