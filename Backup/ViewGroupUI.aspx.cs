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
    public partial class ViewGroupUI : System.Web.UI.Page
    {
        // List<SMSON_GROUP> groupList = new List<SMSON_GROUP>();
        public static int row = 0;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                FetchData(10, 0);
            }
            else
            {
                // plcPaging.Controls.Clear();
                CreatePagingControl(0);

            }
            Session.Remove("GROUP_ID");
            Session.Remove("GROUP_NAME");
            Session.Remove("ADDRESS");

        }
        protected void btnBindMapping_Click(object sender, EventArgs e)
        {
            CreatePagingControl(0);
        }
        void LoadData()
        {
            if (Session["USER_IDS"] != null)
            {
                var data = fetch.Get_All_Group(Session["USER_IDS"].ToString());
                ViewState["row"] = data;
            }
            else
                Response.Redirect("LoginPage.aspx");
        }
        private void CreatePagingControl(int current)
        {
            if (RowCount < 10)
                plcPaging.Visible = false;
            else
            {
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

                }
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
        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int RepeaterItemIndex = ((RepeaterItem)btn.NamingContainer).ItemIndex;
            string id = (Repeater1.Items[RepeaterItemIndex].FindControl("Label2") as Label).Text;
            Session["ADDRESS"] = id;
            Response.Redirect("ViewAddressBook.aspx");
        }
        protected void Send_Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int RepeaterItemIndex = ((RepeaterItem)btn.NamingContainer).ItemIndex;
            string id = (Repeater1.Items[RepeaterItemIndex].FindControl("Label2") as Label).Text;
            string name = (Repeater1.Items[RepeaterItemIndex].FindControl("LinkButton1") as LinkButton).Text;

            var data = fetch.Get_All_Contact_By_User(int.Parse(id), Session["USER_IDS"].ToString());
            /*
            if (data.Count > 0)
            {*/
            Session["GROUP_ID"] = id;
            Session["GROUP_NAME"] = name + " ( " + data.Count + " )";
            Response.Redirect("GroupSendSms.aspx");
            // Show(s);

            /*
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:popup('Error','" + name + " has no contact.Please add some contact to " + name + "','" + icon.CANCEL_ICON + "')", true);
            }
             */
        }

        private void FetchData(int take, int pageSize)
        {
            List<SMSON_GROUP> grouplist = (List<SMSON_GROUP>)ViewState["row"];
            var query = from p in grouplist.OrderBy(o => o.GROUP_NAME).Take(take).Skip(pageSize)
                        select new
                        {
                            Name = p.GROUP_NAME,
                            id = p.GROUP_ID,
                            count = grouplist.Count

                        };

            //groupList.OrderBy(o => o.GROUP_NAME).Take(take).Skip(pageSize);
            PagedDataSource page = new PagedDataSource();
            page.AllowCustomPaging = true;
            page.AllowPaging = true;
            page.DataSource = query;
            page.PageSize = 10;
            Repeater1.DataSource = page;
            Repeater1.DataBind();

            if (!IsPostBack)
            {
                if (query.Count() > 0)
                    RowCount = query.First().count;
                else
                    RowCount = 0;

            }
            if (pageSize == 0)
            {
                plcPaging.Controls.Clear();
                CreatePagingControl(1);
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl(int.Parse((Math.Floor((take / pageSize) * 1.0).ToString())));
            }

        }
    }
}