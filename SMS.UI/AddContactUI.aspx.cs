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
    public partial class AddContactUI : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["USER_IDS"] != null)
                    BindGroup();
                else
                    Response.Redirect("LoginPage.aspx");
            }
        }
        public void BindGroup()
        {
            var data = fetch.Get_All_Group(Session["USER_IDS"].ToString());
            dopGroup.DataSource = data;
            dopGroup.DataTextField = "GROUP_NAME";
            dopGroup.DataValueField = "GROUP_ID";
            dopGroup.DataBind();
            dopGroup.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void clear()
        {
            if (dopGroup.Items.Count > 0)
                dopGroup.SelectedIndex = 0;
            txtName.Text = "";
            txtNumber.Text = "";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dopGroup.SelectedValue == "0")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Select Group','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            if (String.IsNullOrEmpty(txtNumber.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Number field is required!','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            else
            {
                var contact = new SMSON_CONTACT();
                contact.CONTACT_NAME = txtName.Text;
                contact.CONTACT_NUMBER = txtNumber.Text;
                contact.GROUP_ID = int.Parse(dopGroup.SelectedValue);
                contact.USER_IDS = Session["USER_IDS"].ToString();
                var message = save.SaveSMSON_CONTACT(contact);
                if (!message.ToLower().Contains("already"))

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Sucess','" + message + "','" + icon.OK_ICON + "')", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + message + "','" + icon.CANCEL_ICON + "')", true);

            }
            clear();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}