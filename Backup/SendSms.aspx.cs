using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.MODEL;
using SMSONBD.BIZ;

namespace SMS.UI
{
    public partial class SendSms1 : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        public string limit = "100";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["number"] != null)
                {

                    txtNumber.Enabled = false;

                    txtNumber.Text = Session["number"].ToString();
                }

            }
        }


        public void Clear()
        {

            txtNumber.Text = "";
            txtCount.Text = limit;
            txtMsgBox.Text = "";

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMsgBox.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please type some message','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            if (String.IsNullOrEmpty(txtNumber.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please type one phone number','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            var Send = new SMSON_SEND_BOX();
            var message = "";
            Send.MOBILE_NUMBER = txtNumber.Text;
            Send.SMS_TEXT = txtMsgBox.Text;
            Send.USER_IDS = Session["USER_IDS"].ToString();
            Send.SMS_STATUS = 0;
            try
            {
                message = USER_Acitivity.Send_SMS(Send);
                if (!message.ToLower().Contains("enough"))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Success','" + message + "','" + icon.OK_ICON + "')", true);

                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + message + "','" + icon.CANCEL_ICON + "')", true);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Clear();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void UpdatePanel1_Unload(object sender, EventArgs e)
        {
            Session.Remove("number");
            Session.Remove("name");
        }
    }
}