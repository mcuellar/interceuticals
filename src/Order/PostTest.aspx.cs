using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Interceuticals.Order
{
    public class PostTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value;

            foreach (string key in Request.Form.Keys)
            {
                value = Request.Form[key].ToString();

                Response.Write("Item Name = " + key);
                Response.Write("<br>Item Value = " + value);
                Response.Write("<br>--------------------------");
                Response.Write("<br><br>");
            }


        }
    }
}
