using FalconReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalconReportingweb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        FalconHouseEntities1 db = new FalconHouseEntities1();
        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (db.Users.Any(a=>a.UserName==usernametxt.Text && a.Password==passtxt.Text))
            {
                Session["userid"] = db.Users.Where(a => a.UserName == usernametxt.Text && a.Password == passtxt.Text).Select(x => x.Id).FirstOrDefault();
                if (Session["url"] == null)
                {
                    Session["url"] = "/PrintBillpg.aspx";
                    Response.Redirect(Session["url"].ToString());
                }
                else
                {
                    Response.Redirect(Session["url"].ToString());
                }
               
            }
        }
    }
}