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
using Interceuticals.Common.Classes;
using OTC.Database;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;


namespace Interceuticals.Product
{
	public class MemberShip : System.Web.UI.Page
	{
		private int    m_productId;
		private string m_onload = "";
		private string m_site; 
				
		public int    ProductId {get{return(this.m_productId);	}}
		public string OnLoad	{get{return(this.m_onload);		}}
		public string Site		{get{return(this.m_site);		}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_site			= Request.QueryString["site"];
			this.m_productId	= Request.QueryString.ToString().IndexOf("PID") > -1 ? Convert.ToInt32(Request.QueryString["PID"]) : 0;
			
			Session["viewedMembership"] = true;
			if(Request.Form.ToString().Length > 0)
			{
				Session["WantsMembership"] = Convert.ToBoolean(Convert.ToInt32(Request.Form["rdoMemberShip"]));
				Response.Redirect("MemberShip.aspx?thread=close&site=" + this.m_site + "&PID=" + Request.Form["productId"]);
			}
			
			if(Request.QueryString.ToString().IndexOf("thread") > -1)
			{
				if(Request.QueryString["thread"] == "close")
					this.m_onload = "javascript:closeWindow('" + this.m_site + "'," + Request.QueryString["PID"] + ")";
			}
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
