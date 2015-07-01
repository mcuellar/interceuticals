using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interceuticals.Shared
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["site"] == null)
            //    Session["site"] = Request.QueryString.ToString().IndexOf("site") > -1 ? Request.QueryString["site"] : "bm";
        }
    }
}