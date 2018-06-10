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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginUI.aspx");
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
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        void ClearControl()
        {
            txtName.Text = "";
            txtPass.Text = "";
            txtRegiEmail.Text = "";
            txtRegiPass.Text = "";
            txtRegiRePass.Text = "";
            txtRegiUserName.Text = "";
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var SMSON_USER = new SMSON_USER();
            if (String.IsNullOrEmpty(txtName.Text))
            {
                Show("User name is empty");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','User name is empty')", true);
                return;
            }
            if (String.IsNullOrEmpty(txtPass.Text))
            {
                Show("Password is empty");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Password is empty')", true);

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
                    Response.Redirect("HomePanel.aspx");
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Invalid Username or Password')", true);
                    Show("Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void btnRegi_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRegiUserName.Text))
            {
                Show("Please write username!");
                return;
            }
            if (String.IsNullOrEmpty(txtRegiEmail.Text))
            {
                Show("Please write name!");
                return;
            }
            if (String.IsNullOrEmpty(txtRegiPass.Text))
            {
                Show("Please write Password");
                return;
            }
            if (txtRegiPass.Text.Equals(txtRegiRePass.Text))
            {
                Show("password doesn't match!");
                return;
            }
            if (txtRegiPass.Text.Length > 50 || txtRegiUserName.Text.Length > 50 || txtRegiEmail.Text.Length > 50)
            {
                Show("Max 50 Character Allow!");
                return;
            }
            string GenerateString = "ajdupureonekgoromporseeijnnekisukorajaitesenaeigoromekikormukisuibujtesinabristiohoynathatswhyweareseekingforacroom";

            string sub = GenerateString.Substring(0, 115 - (txtRegiUserName.Text.Length + txtRegiPass.Text.Length));
            sub = txtRegiUserName.Text + sub + txtRegiPass.Text;
            //sub=fetch.en
            sub = fetch.PasswordEncrypt(sub);

            var obj = new SMSON_USER();
            obj.USER_IDS = txtRegiUserName.Text;
            obj.USER_FULL_NAME = "";
            obj.PASSWORD = fetch.PasswordEncrypt(txtPass.Text);
            obj.EMAIL = txtRegiEmail.Text;
            obj.PHONE = "";
            obj.DISTRICT = "";
            obj.POST_CODE = "";
            obj.ADDRESS = "";
            obj.HashCode = sub;
            var count = save.SaveSMSON_USER(obj);
            if (count.ToLower().Contains("success"))
            {
                Show("Registration Sucessfull");
            }
            else
            {
                Show(count);
            }
            ClearControl();
        }
    }
}