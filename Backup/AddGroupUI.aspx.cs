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
    public partial class AddGroupUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Check_Session();
            }
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

        void clear()
        {
            txtName.Text = "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','User name is empty','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            SMSON_GROUP objSMSON_GROUP = new SMSON_GROUP();
            objSMSON_GROUP.GROUP_NAME = txtName.Text;
            objSMSON_GROUP.USER_IDS = Session["USER_IDS"].ToString();
            // objSMSON_GROUP.SMS_STATUS = 1;
            var data = save.SaveSMSON_GROUP(objSMSON_GROUP);

            try
            {
                if (!data.ToLower().Contains("already"))
                {
                    //Show("Save Successfully");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Success','" + data + "','" + icon.OK_ICON + "')", true);

                }

                else
                {
                    //Show("Save Not Successfully");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + data + "','" + icon.CANCEL_ICON + "')", true);
                }
            }
            catch { }
            finally { clear(); }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}