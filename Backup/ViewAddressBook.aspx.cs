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
    public partial class ViewAddressBook : System.Web.UI.Page
    {

        POPUP_ICON icon = new POPUP_ICON();
        private int RowCount
        {
            get
            {
                return (int)ViewState["RowCount"];
            }
            set
            {
                ViewState["RowCount"] = value;
            }
        }
        private bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindGroup();
                LoadData();
                FetchData(10, 0);
                flag = false;

            }
            else
            {
                // plcPaging.Controls.Clear();
                string value = Request["__EVENTTARGET"];
                if (btnSend.UniqueID != Page.Request.Params["__EVENTTARGET"])
                    CreatePagingControl(1, false);
                else
                    CreatePagingControl(1, true);
            }
            Session.Remove("name");
            Session.Remove("number");
        }
        void bindGroup()
        {
            if (Session["USER_IDS"] != null)
            {
                var data = fetch.Get_All_Group(Session["USER_IDS"].ToString());
                dopGroup.DataSource = data;
                dopGroup.DataTextField = "GROUP_NAME";
                dopGroup.DataValueField = "GROUP_ID";
                dopGroup.DataBind();
                dopGroup.Items.Insert(0, new ListItem("Please Select Group", "0"));
                if (Session["ADDRESS"] != null)
                {
                    dopGroup.SelectedIndex = dopGroup.Items.IndexOf(dopGroup.Items.FindByValue(Session["ADDRESS"].ToString().Trim()));
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        void LoadData()
        {
            if (Session["USER_IDS"] != null)
            {
                var data = fetch.getAllContactList(dopGroup.SelectedValue, Session["USER_IDS"].ToString());
                this.ViewState.Clear();
                ViewState["row"] = data;
            }
            else
                Response.Redirect("LoginPage.aspx");
        }
        private void CreatePagingControl(int current, bool flag)
        {
            if (!flag)
            {
                if (RowCount < 10)
                    plcPaging.Visible = false;
                else
                {
                    plcPaging.Visible = true;
                    for (int i = 0; i < (RowCount / 10) + 1; i++)
                    {
                        LinkButton lnk = new LinkButton();
                        lnk.Click += new System.EventHandler(lbl_Click);
                        LiteralControl spacer = new LiteralControl();

                        if ((i + 1) == current)

                            spacer.Text = "<li class='active'>";
                        else
                            spacer.Text = "<li>";
                        plcPaging.Controls.Add(spacer);


                        lnk.ID = "lnkPage" + (i + 1).ToString();

                        lnk.Text = (i + 1).ToString();

                        plcPaging.Controls.Add(lnk);

                        LiteralControl spacer1 = new LiteralControl();
                        spacer1.Text = "<li>";
                        plcPaging.Controls.Add(spacer1);
                        Session.Remove("plc");
                        Session["plc"] = plcPaging;

                    }
                }
            }
            else
            {
                if (Session["plc"] != null)
                    plcPaging = (PlaceHolder)Session["plc"];
            }
        }
        protected void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 10;
            int skip = currentPage == 1 ? 0 : take - 10;
            FetchData(take, skip);
        }


        private void FetchData(int take, int pageSize)
        {
            List<SMSON_CONTACT> grouplist = (List<SMSON_CONTACT>)ViewState["row"];
            var query = from p in grouplist.Take(take).Skip(pageSize)
                        select new
                        {
                            Name = p.CONTACT_NAME,
                            number = p.CONTACT_NUMBER,
                            groupname = p.GROUP_NAME,
                            count = grouplist.Count,
                            date = p.MAKE_DT

                        };

            //groupList.OrderBy(o => o.GROUP_NAME).Take(take).Skip(pageSize);
            PagedDataSource page = new PagedDataSource();
            page.AllowCustomPaging = true;
            page.AllowPaging = true;
            page.DataSource = query;
            page.PageSize = 10;
            Repeater1.DataSource = page;
            Repeater1.DataBind();

            if (!IsPostBack || flag == true)
            {
                if (query.Count() > 0)
                    RowCount = query.First().count;
                else
                    RowCount = 0;
                flag = false;
            }
            if (pageSize == 0)
            {
                plcPaging.Controls.Clear();
                CreatePagingControl(1, false);
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl(int.Parse((Math.Floor((take / pageSize) * 1.0).ToString())), false);
            }

        }

        protected void dopGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = true;
            LoadData();
            FetchData(10, 0);
        }

        protected void UpdatePanel1_Unload(object sender, EventArgs e)
        {
            Session.Remove("ADDRESS");
        }
        protected void Send_Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int RepeaterItemIndex = ((RepeaterItem)btn.NamingContainer).ItemIndex;

            string name = (Repeater1.Items[RepeaterItemIndex].FindControl("Label1") as Label).Text;
            string number = (Repeater1.Items[RepeaterItemIndex].FindControl("Label2") as Label).Text;
            Session["name"] = name;
            Session["number"] = number;

            Response.Redirect("SendSms.aspx");
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (dopGroup.SelectedIndex == 0)
            {
                // CreatePagingControl(1, true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','Please select group','" + icon.CANCEL_ICON + "')", true);
                // FetchData(10, 0);
                //return;
            }
            else
            {
                var data = fetch.Get_All_Contact_By_User(int.Parse(dopGroup.SelectedValue), Session["USER_IDS"].ToString());
                if (data.Count > 0)
                {
                    Session["GROUP_ID"] = dopGroup.SelectedValue;
                    Session["GROUP_NAME"] = dopGroup.SelectedItem + " ( " + data.Count + " )";
                    Response.Redirect("GroupSendSms.aspx");
                    // Show(s);
                }
                else
                {
                    // LoadData();
                    FetchData(10, 0);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + dopGroup.SelectedItem + " has no contact.Please add some contact to " + dopGroup.SelectedItem + "','" + icon.CANCEL_ICON + "')", true);
                }
            }
        }


    }
}