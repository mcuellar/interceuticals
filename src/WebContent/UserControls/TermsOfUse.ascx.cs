using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interceuticals.WebContent.UserControls
{
    public partial class TermsOfUse : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlTerms.Style.Add("display", "none");
        }
    }
}