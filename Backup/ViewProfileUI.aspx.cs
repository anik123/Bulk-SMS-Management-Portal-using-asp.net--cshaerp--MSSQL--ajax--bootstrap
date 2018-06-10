using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.BIZ;

namespace SMS.UI
{
    public partial class ViewProfileUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                bindProfile();
        }
        public void bindProfile()
        {
            if (Session["USER_IDS"] != null)
            {

                var data = fetch.getUserProfile(Session["USER_IDS"].ToString());
                lblUserName.Text = data.USER_FULL_NAME;
                lbluserTitle.Text = data.USER_FULL_NAME;
                lblAddress.Text = data.ADDRESS;
                lblEmail.Text = data.EMAIL;
                lblPhone.Text = data.PHONE;
                lblDistrict.Text = data.DISTRICT;
                lblPostalCode.Text = data.POST_CODE;
                lblMsgCount.Text = data.SMS_CREDIT.ToString();

                lblMoneyBalance.Text = data.SPEND;
                lblMsgSent.Text = data.TOTAL_MESSAGE + " ";
                lblContact.Text = data.TOTAL_CONTACTS + " ";
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}