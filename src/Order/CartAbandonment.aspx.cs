using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OTC;
using OTC.Database;
using OTC.Web;
using OTC.Web.Marketing;
using OTC.Web.SalesOrder;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using Interceuticals.Common.Classes;
using Interceuticals.Cache;

namespace Interceuticals.Order
{
	public class Abandonment : System.Web.UI.Page
	{
        private OTCDatabase m_db = new OTCDatabase();
        

        private void Page_Load(object sender, System.EventArgs e)
        {
            var sessionId = Session.SessionID;


            var form = Request.Form;

            var sb = new StringBuilder();

            sb.Append("spUpdateCartAbandonment ");
            sb.Append("@sessionId = " + OTCDatabase.SqlFormat(sessionId));
            sb.Append(",@cartId = " + form["ShoppingCartId"]);
            sb.Append(",@BillToFirstName = " + OTCDatabase.SqlFormat(form["BillToFirstName"]));
            sb.Append(",@BillToLastName = " + OTCDatabase.SqlFormat(form["BillToLastName"]));
            sb.Append(",@BillToAddress = " + OTCDatabase.SqlFormat(form["BillToAddress"]));
            sb.Append(",@BillToCity = " + OTCDatabase.SqlFormat(form["BillToCity"]));
            sb.Append(",@BillToState = " + OTCDatabase.SqlFormat(form["BillToState"]));
            sb.Append(",@BillToProvince = " + OTCDatabase.SqlFormat(form["BillToProvince"]));
            sb.Append(",@BillToZip = " + OTCDatabase.SqlFormat(form["BillToZip"]));
            sb.Append(",@BillToPhone = " + OTCDatabase.SqlFormat(form["BillToPhone"]));
            sb.Append(",@BillToEmail = " + OTCDatabase.SqlFormat(form["BillToEmail"]));
            sb.Append(",@BillToCountry = " + OTCDatabase.SqlFormat(form["BillToCountry"]));
            sb.Append(",@ShipToFirstName = " + OTCDatabase.SqlFormat(form["ShipToFirstName"]));
            sb.Append(",@ShipToLastName = " + OTCDatabase.SqlFormat(form["ShipToLastName"]));
            sb.Append(",@ShipToAddress = " + OTCDatabase.SqlFormat(form["ShipToAddress"]));
            sb.Append(",@ShipToCity = " + OTCDatabase.SqlFormat(form["ShipToCity"]));
            sb.Append(",@ShipToState = " + OTCDatabase.SqlFormat(form["ShipToState"]));
            sb.Append(",@ShipToProvince = " + OTCDatabase.SqlFormat(form["ShipToProvince"]));
            sb.Append(",@ShipToZip = " + OTCDatabase.SqlFormat(form["ShipToZip"]));
            sb.Append(",@ShipToPhone = " + OTCDatabase.SqlFormat(form["ShipToPhone"]));
            sb.Append(",@ShipToEmail = " + OTCDatabase.SqlFormat(form["ShipToEmail"]));
            sb.Append(",@ShipToCountry = " + OTCDatabase.SqlFormat(form["ShipToCountry"]));
            sb.Append(",@HearAboutUs = " + OTCDatabase.SqlFormat(form["HearAboutUs"]));
            sb.Append(",@Age = " + OTCDatabase.SqlFormat(form["Age"]));
            sb.Append(",@Promotion = " + OTCDatabase.SqlFormat(form["Promotion"]));
            sb.Append(",@Comments = " + OTCDatabase.SqlFormat(form["Comments"]));

            this.m_db.Open();
            this.m_db.SendSQLUpdate(sb.ToString());
            this.m_db.ReleaseConnection();

        }

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            
            this.Load += new System.EventHandler(this.Page_Load);

        }
       
	}
}
