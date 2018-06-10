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
    public partial class ViewSendBoxUI : System.Web.UI.Page
    {
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
        }
        void LoadData()
        {
            if (Session["USER_IDS"] != null)
            {
                var data = fetch.getAllSend(Session["USER_IDS"].ToString());
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
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }

        private void FetchData(int take, int pageSize)
        {
            List<SMSON_SEND_BOX> grouplist = (List<SMSON_SEND_BOX>)ViewState["row"];
            var query = from p in grouplist.Take(take).Skip(pageSize)
                        select new
                        {
                            Name = p.GROUP_NAME,
                            number = p.MOBILE_NUMBER,
                            status = p.STATUS,
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
            BindColor();
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
        public void BindColor()
        {
            int index = 0;
            foreach (var item in Repeater1.Items)
            {
                string text = (Repeater1.Items[index].FindControl("btnStatus") as Button).Text;
                if (text.Contains("Pending"))
                {
                    (Repeater1.Items[index].FindControl("btnStatus") as Button).CssClass = "btn btn-xs btn-warning";
                }
                if (text.Contains("Sent"))
                {
                    (Repeater1.Items[index].FindControl("btnStatus") as Button).CssClass = "btn btn-xs btn-success";
                }
                if (text.Contains("Not Sent"))
                {
                    (Repeater1.Items[index].FindControl("btnStatus") as Button).CssClass = "btn btn-xs btn-danger";
                }

                index++;
            }
        }
    }
}