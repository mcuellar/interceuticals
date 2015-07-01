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
using OTC.Web;
using OTC.Web.Controls;

namespace Interceuticals.Admin.Reports
{
	public class Order : System.Web.UI.Page
	{
		OTCDatabase m_db = new OTCDatabase();
		public ITCPage m_page;
		private void Page_Load(object sender, System.EventArgs e)
		{
			int orderId       = 0;
			string verisignId = "";
			string sql        = "";
			
			this.m_page = new ITCPage();
			this.m_page.HideWest = true;;
			this.m_page.CheckLogin();
			
			try
			{
				orderId = Convert.ToInt32(Request.QueryString["OID"]);
				sql = "spGetOTCSalesOrderDetails @OTCSalesOrderId = " + orderId;
			}
			catch(System.FormatException)
			{
				verisignId = Request.QueryString["OID"];
				sql = "spGetOTCSalesOrderDetails @VerisignId = " + OTCDatabase.SqlFormat(verisignId) + ",@IsVerisign=1";
			}
			
			this.m_db.Open();
			DataSet ds = this.m_db.GetDataset(sql);
			this.m_db.ReleaseConnection();
			this.m_page.OpenHeader();
			this.m_page.CloseHeader();
			this.m_page.Start();
			Response.Write("<br><br>");
			OTCGrid grid = new OTCGrid(ds.Tables[0]);
			grid.RandomHTML = "<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td class=\"tableFont\">Sales Order ID: " + (orderId > 0 ? orderId.ToString() : verisignId) + ": USER DETAIL</td><td align=\"right\" class=\"tableFont\"><a href=\"javascript:window.history.back(false)\"><< back</a></td></tr></table>";
			grid.Draw();
			
			Response.Write("<br>");
			grid = new OTCGrid(ds.Tables[1]);
			grid.RandomHTML = "<table cellpadding=\"0\" cellspacing=\"0\"><tr><td class=\"tableFont\">Sales Order ID: " + (orderId > 0 ? orderId.ToString() : verisignId)+ ": PRODUCT DETAILS</td></tr></table>";
			grid.Draw();
			
			Response.Write("<br>");
			
			grid = new OTCGrid(ds.Tables[2]);
			grid.RandomHTML = "<table cellpadding=\"0\" cellspacing=\"0\"><tr><td class=\"tableFont\">Sales Order ID: " + (orderId > 0 ? orderId.ToString() : verisignId) + ": SHIPPING DETAILS</td></tr></table>";
			grid.Draw();
			
			Response.Write("<br>");
			
			grid = new OTCGrid(ds.Tables[3]);
			grid.RandomHTML = "<table cellpadding=\"0\" cellspacing=\"0\"><tr><td class=\"tableFont\">Sales Order ID: " + (orderId > 0 ? orderId.ToString() : verisignId) + ": CREDIT CARD INFORMATION</td></tr></table>";
			grid.Draw();
			
			Response.Write("<br>");
			
			grid = new OTCGrid(ds.Tables[4]);
			grid.RandomHTML = "<table cellpadding=\"0\" cellspacing=\"0\"><tr><td class=\"tableFont\">Sales Order ID: " + (orderId > 0 ? orderId.ToString() : verisignId) + ": Marketing Information</td></tr></table>";
			grid.Draw();
			
			this.m_page.End();
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

