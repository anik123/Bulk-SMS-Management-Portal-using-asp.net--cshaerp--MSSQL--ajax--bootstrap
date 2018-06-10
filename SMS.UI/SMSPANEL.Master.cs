using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SMSONBD.BIZ;

namespace SMS.UI
{
    public partial class SMSPANEL : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetSession();
                UserInfo();
            }
        }
        public void GetSession()
        {
            if (Session["Login_Status"] == null)
                Response.Redirect("~/Login/LoginUI.aspx");
            else
                lblloginName.Text = Session["USER_FULL_NAME"].ToString();

        }
        public void UserInfo()
        {
            var data = fetch.getUserProfile(Session["USER_IDS"].ToString());
            lblMsgCount.Text = data.SMS_CREDIT.ToString();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_IDS");
            Session.Remove("USER_FULL_NAME");
            Session.Remove("Login_Status");
            Session.Remove("GROUP_ID");
            Session.Remove("GROUP_NAME");
            Session.Remove("ADDRESS");
            Session.Remove("name");
            Session.Remove("number");
            Response.Redirect("~/Login/LoginUI.aspx");
        }
    }
}