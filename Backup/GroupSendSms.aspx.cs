using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSONBD.BIZ;
using ConnectionProvider;
using System.Data.SqlClient;
using System.Text;
using SMSONBD.MODEL;

namespace SMS.UI
{
    public partial class GroupSendSms : System.Web.UI.Page
    {
        POPUP_ICON icon = new POPUP_ICON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["GROUP_ID"] == null)
                    Response.Redirect("ViewGroupUI.aspx");
                else
                {
                    HFGroupId.Value = Session["GROUP_ID"].ToString();
                    txtNumber.Text = Session["GROUP_NAME"].ToString();
                }
            }
        }
        public void clear()
        {
            txtMsgBox.Text = "";
            txtCount.Text = "100";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(HFGroupId.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Invalid Group','" + icon.CANCEL_ICON + "')", true);

                return;
            }
            if (String.IsNullOrEmpty(txtMsgBox.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please type some message','" + icon.CANCEL_ICON + "')", true);

                return;
            }

            else
            {
                var data = fetch.Get_All_Contact_By_User(int.Parse(HFGroupId.Value), Session["USER_IDS"].ToString());

                if (data.Count > 0)
                {
                    if (data.First().SMS_CREDIT < data.Count)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Not enough balance','" + icon.CANCEL_ICON + "')", true);
                        return;
                    }

                    var conn = ConnectionClass.GetConnection();
                    var cmd = new SqlCommand();
                    SqlTransaction trans = null;
                    conn.Open();
                    var sb = new StringBuilder();
                    foreach (var item in data)
                    {
                        sb.Append("EXEC FSP_SEND_SMS_I '" + item.CONTACT_NUMBER + "','" + Session["USER_IDS"] + "','" + txtMsgBox.Text + "','0','" + item.GROUP_ID + "','' ;");
                    }
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    cmd.Connection = conn;
                    cmd.CommandText = sb.ToString();
                    try
                    {
                        var count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Success','Sucessfully Send!','" + icon.OK_ICON + "')", true);
                            trans.Commit();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Saving process in not successfull!','" + icon.CANCEL_ICON + "')", true);

                            trans.Rollback();
                        }
                    }
                    catch
                    {
                        trans.Rollback();

                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','This Group Has No Contact Number!','" + icon.CANCEL_ICON + "')", true);
                }
            }
            clear();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}