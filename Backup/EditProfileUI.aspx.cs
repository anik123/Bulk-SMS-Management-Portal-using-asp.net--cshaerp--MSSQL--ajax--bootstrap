using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.BIZ;
using SMSONBD.MODEL;

namespace SMS.UI
{
    public partial class EditProfileUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindProfile();
        }
        public void BindProfile()
        {
            if (Session["USER_IDS"] != null)
            {

                var data = fetch.getUserProfile(Session["USER_IDS"].ToString());
                txtUname.Text = Session["USER_IDS"].ToString();
                txtFullName.Text = data.USER_FULL_NAME;
                txtAddress.Text = data.ADDRESS;
                txtEmail.Text = data.EMAIL;
                txtPhone.Text = data.PHONE;
                txtDistrict.Text = data.DISTRICT;
                txtPostal.Text = data.POST_CODE;

            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please type your current password','" + icon.CANCEL_ICON + "')", true);
                return;
            }

            var user = new SMSON_USER();
            user.PASSWORD = fetch.PasswordEncrypt(txtPassword.Text);
            user.USER_IDS = Session["USER_IDS"].ToString();
            user.USER_FULL_NAME = txtFullName.Text;
            user.ADDRESS = txtAddress.Text;
            user.EMAIL = txtEmail.Text;
            user.PHONE = txtPhone.Text;
            user.DISTRICT = txtDistrict.Text;
            user.POST_CODE = txtPostal.Text;
            var message = save.SaveSMSON_USERUpdate(user);
            if (message.ToLower().Contains("wrong"))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + message + "','" + icon.CANCEL_ICON + "')", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Success','" + message + "','" + icon.OK_ICON + "')", true);

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindProfile();
        }
    }
}