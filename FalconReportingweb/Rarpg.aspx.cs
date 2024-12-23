using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FalconReportingweb.Code;
namespace FalconReportingweb
{
    public partial class Rarpg : System.Web.UI.Page
    {
        FalconHouseEntities1 db = new FalconHouseEntities1();
        List<RarrecieptModel> receipt = new List<RarrecieptModel>();
        string ID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ID = Request.QueryString["ID"].ToString();
                int rarid = Convert.ToInt32(ID);
              
                foreach (var item in db.RarReceiptTbs.Where(a=>a.rarid==rarid).ToList())
                {
                    ProjectAssignedTb passig = db.ProjectAssignedTbs.Where(a => a.Id == item.RarTb.pasind).FirstOrDefault();
                    int advan = Convert.ToInt32(passig.Advance * 1000000);
                   string advanceword = NumberToWords(advan);
                    receipt.Add(new RarrecieptModel { Rarnumber=item.rarid.ToString(), Date=Convert.ToDateTime(item.RarTb.date).ToString("dd/MMMM/yyyy")
                        ,contractno= passig.CAno, work=passig.ProjectTbNew.Pname+ passig.ProjectTbNew.PHnumber
                        ,  contractor=passig.ContractorTb.Company+ passig.ContractorTb.Address
                        , CNIC= passig.ContractorTb.CNIC, NTN= passig.ContractorTb.NTN
                        , mobilisationadv=Convert.ToDouble(passig.Advance*1000000),
                         advword= advanceword, commdate=Convert.ToDateTime(passig.datecomm).ToString("dd/MM/yyyy")
                         , compdate= Convert.ToDateTime(passig.datetcomp).ToString("dd/MM/yyyy")
                         , Extendeddate= Convert.ToDateTime(passig.extenddate).ToString("dd/MM/yyyy"),
                          valuofcont=Convert.ToDouble(passig.CaCost), lumpsumyard=Convert.ToDouble(item.yardstickpercentage),
                           prolumpsum=0,DOsmeasured=Convert.ToDouble(item.dosmeasured),
                           Metebycontractor=Convert.ToDouble(item.meterialprovided)
                           , advrecovery=Convert.ToDouble(item.mobilisationadvance)
                           , previousrarpaid=Convert.ToDouble(item.previouserar), currentstoreissue=Convert.ToDouble(item.storesissued),
                            previousstoreisu=Convert.ToDouble(item.storesacclastrar), incomtax=Convert.ToDouble(item.incometax)
                            , returntostore= Convert.ToDouble(item.storereturn), loadingunloading= Convert.ToDouble(item.loadingunloading)
                            , mailexp= Convert.ToDouble(item.mailexp), rentbuilding= Convert.ToDouble(item.rent)
                            , Retention= Convert.ToDouble(item.Retentionmoney), Sdovoucher="", secuadv= Convert.ToDouble(item.secureadvance)
                            , tarsnportcharges= Convert.ToDouble(item.transport), watercharges= Convert.ToDouble(item.water)
                            , bankcom=Convert.ToDouble(item.bank)
                    });
                }
                
                ReportDataSource reportDataSource = new ReportDataSource();
                // Must match the DataSource in the RDLC
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = receipt;

                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.DataBind();
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}