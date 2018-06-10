using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.UI
{
    public partial class HomePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Check_Session();

        }
        private void Check_Session()
        {
            if (Session["Login_Status"] == null)
                Response.Redirect("LoginPage.aspx");
        }
    }
}