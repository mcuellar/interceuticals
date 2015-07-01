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

namespace Interceuticals.Verisign
{
	public class Post : System.Web.UI.Page
	{
		private int m_salesOrderId;
		private string m_expirationDate;
		private OTCSalesOrder m_order = new OTCSalesOrder();
		private OTCCreditCard m_card  = new OTCCreditCard();
		
		public OTCSalesOrder Order   {get{return(this.m_order);}}
		public OTCCreditCard Card    {get{return(this.m_card);}}
		public String ExpirationDate {get{return(this.m_expirationDate);}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_salesOrderId = Convert.ToInt32(Request.QueryString["SID"]);
			
			if(Convert.ToInt32(Session["SID"]) > 0)
				Response.Redirect("/interceuticals/order/checkout.aspx?SID=" + Session["SID"] + "&thread=reset");
			else 
				Session["SID"]= this.m_salesOrderId;
			
			this.m_order = new OTCSalesOrder(this.m_salesOrderId);
			this.m_card  = new OTCCreditCard(this.m_salesOrderId);
			this.m_expirationDate = this.m_card.ExpirationMonth.Length == 1 ? ("0" + this.m_card.ExpirationMonth  + this.m_card.ExpirationYear) : (this.m_card.ExpirationMonth  + this.m_card.ExpirationYear);
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
