using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interceuticals.Shared.UserControls
{
    public partial class LeftSide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String site = "";

            Session["site"] = site = Request.QueryString.ToString().IndexOf("site") > -1 ? Request.QueryString["site"] : "bm";

 
            if ((site == "bm") || (site == ""))
            {
                divBM.Visible = true;
                divBW.Visible = false;
            }
            else
            {
                divBM.Visible = false;
                divBW.Visible = true;
            }
                
        }
    }
}