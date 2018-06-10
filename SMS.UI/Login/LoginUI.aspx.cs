using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.MODEL;
using SMSONBD.BIZ;

namespace SMS.UI.Login
{
    public partial class LoginUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Redirect();
        }
        public void Redirect()
        {
            try
            {
                int status = int.Parse(Session["Login_Status"].ToString());
                if (status == 1)
                    Response.Redirect("HomePanel.aspx");

            }
            catch (Exception ex) { }
        }
        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                          Guid.NewGuid().ToString(),
                          "binding();", true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var SMSON_USER = new SMSON_USER();
            if (String.IsNullOrEmpty(txtName.Text))
            {
                //Show("User name is empty");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','User name is empty','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (String.IsNullOrEmpty(txtPass.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Password is empty','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            SMSON_USER.USER_IDS = txtName.Text;
            SMSON_USER.PASSWORD = fetch.PasswordEncrypt(txtPass.Text);
            try
            {
                var data = USER_Acitivity.Check_Login(SMSON_USER);
                if (data.Count > 0)
                {
                    Session.Add("USER_IDS", data.First().USER_IDS);
                    Session.Add("USER_FULL_NAME", data.First().USER_FULL_NAME);
                    Session.Add("Login_Status", 1);
                    Response.Redirect("~/HomePanel.aspx");
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Invalid Username or Password')", true);
                    // Show("Invalid Username or Password");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Invalid Username or Password','" + icon.CANCEL_ICON + "')", true);
                }
            }
            catch (Exception ex)
            {
                // Show(ex.Message);
            }
        }

        protected void btnRegi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/RegistrationUI.aspx");
        }
    }
}