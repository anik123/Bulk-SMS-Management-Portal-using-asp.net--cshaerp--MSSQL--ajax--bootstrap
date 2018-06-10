using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.BIZ;
using SMSONBD.MODEL;

namespace SMS.UI.Login
{
    public partial class RegistrationUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void ClearControl()
        {

            txtRegiEmail.Text = "";
            txtRegiPass.Text = "";
            txtRepass.Text = "";
            txtRegiUserName.Text = "";
        }
        protected void btnRegi_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRegiUserName.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please write username!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (String.IsNullOrEmpty(txtRegiEmail.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please write email!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (String.IsNullOrEmpty(txtRegiPass.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please write Password!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (!txtRegiPass.Text.Equals(txtRepass.Text))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','password doesn't match!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            if (txtRegiPass.Text.Length > 50 || txtRegiUserName.Text.Length > 50 || txtRegiEmail.Text.Length > 50)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Max 50 Character Allow!','" + icon.CANCEL_ICON + "')", true);
                return;
            }
            string GenerateString = "aJdUPArWoNEKgOrOMPorSDeOjEnEKiSUKoRAjAItEsEnaeiGOroMeWikOmRukIaUibuJtEsInaBRIsTOoHOynAgTatKiDyweaReSeeKIngForAcRPom";

            string sub = GenerateString.Substring(0, 114 - (txtRegiUserName.Text.Length + txtRegiPass.Text.Length));
            sub = txtRegiUserName.Text + sub + txtRegiPass.Text;
            //sub=fetch.en
            sub = fetch.HashEncrypt(sub);

            var obj = new SMSON_USER();
            obj.USER_IDS = txtRegiUserName.Text;

            obj.PASSWORD = fetch.PasswordEncrypt(txtRegiPass.Text);
            obj.EMAIL = txtRegiEmail.Text;

            obj.HashCode = sub;
            var count = save.SaveSMSON_USER(obj);
            if (count.ToLower().Contains("success"))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Registration Sucessfull','" + icon.OK_ICON + "')", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + count + "','" + icon.OK_ICON + "')", true);
            }
            ClearControl();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginUI.aspx");
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                         Guid.NewGuid().ToString(),
                         "binding();", true);
        }
    }
}