using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OTC.Web.SalesOrder;
using OTC.Database;
using OTC.Web.Product;
using Interceuticals.Common.Util;

namespace Interceuticals.Common.Marketing
{
	public class BetterMan : System.Web.UI.Page
	{
		private OTCSalesOrder m_order;
		private double m_productPrice;
		private int m_productCount = 1;
		
		public OTCSalesOrder Order {get{return(this.m_order);}}
		public double ProductPrice {get{return(this.m_productPrice);}}
		public int ProductQty	   {get{return(this.m_productCount);}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			int orderId = Convert.ToInt32(Request.QueryString["OID"]);
			this.m_order = new OTCSalesOrder(orderId);
			string sql = "SELECT * FROM OTCSalesOrderDetail WHERE OTCSalesOrderId = " + this.m_order.OTCSalesOrderId;
			OTCDatabase db = new OTCDatabase();
			db.Open();
			DataTable dt = db.GetDataset(sql).Tables[0];
			db.ReleaseConnection();
			foreach(DataRow dr in dt.Rows){
				int productId = Convert.ToInt32(dr["OTCProductId"]);
				OTCProduct p = new OTCProduct(productId);
				if(p.CategoryId != 21)
					Response.End();
				m_productPrice = p.Price;
			}


            EmailSender mail = new EmailSender();

            String subject = "Order Confirmtion - Interceuticals Order " + this.m_order.OTCSalesOrderId;
            String body = "Marketing Information Captured";
            String notifyEmails = "chris@olympictcs.com";

            mail.AddEmailAddresses(notifyEmails);
            //mail.SendEmail(subject, body);

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
