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
    public partial class ChangePasswordUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        public void clear()
        {
            txtOldPass.Text = "";
            txtNewPassword.Text = "";
            txtRetype.Text = "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNewPassword.Text) || String.IsNullOrEmpty(txtRetype.Text) || String.IsNullOrEmpty(txtOldPass.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Every Field is required!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (!txtNewPassword.Text.Equals(txtRetype.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Unmatch  Password!','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            else
            {
                var message = save.SaveSMSON_USERPassUpdate(fetch.PasswordEncrypt(txtOldPass.Text), fetch.PasswordEncrypt(txtNewPassword.Text), Session["USER_IDS"].ToString());
                //Show(message);
                if (message.ToLower().Contains("wrong"))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + message + "','" + icon.CANCEL_ICON + "')", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Success','" + message + "','" + icon.OK_ICON + "')", true);

            }
            clear();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }

    }
}