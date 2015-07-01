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
using OTC.Web;
using OTC.Database;
using Interceuticals.Common.Classes;

namespace Edga.Reports
{
	public class ReportPicker : System.Web.UI.Page
	{
		private char CR = (char)10;
		private OTCDatabase m_db = new OTCDatabase();
		public ITCPage m_page;
		
		//==================================
		//
		//==================================
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			this.m_page.HideWest = true;
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("/interceuticals/admin/login.aspx");
			this.m_page.OpenHeader();
			this.m_page.CloseHeader();
			this.m_page.Start();
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset("spGetOTCReports @OTCSiteId = 7").Tables[0];
			this.m_db.ReleaseConnection();
			this.buildAvailableReports(dt);
			this.m_page.End();
		}
		
		//==================================
		//
		//==================================
		private void buildAvailableReports(DataTable dt)
		{
//			foreach(DataRow dr in dt.Rows)
//			{
//				Response.Write("<table class=\"cnetTableWrapper\" width=\"100%\" cellpadding=\"3\" cellspacing=\"0\">"
//						+ CR + " <tr>"
//						+ CR + "  <td class=\"gridHeader\"><a href=\"default.aspx?RID=" + dr["OTCReportId"].ToString() + "\" class=\"formFont\"><b>" + dr["OTCReportName"].ToString() + "</a></td>"
//						+ CR + " </tr>"
//						+ CR + " <tr>"
//						+ CR + "  <td class=\"formFont\">" + dr["OTCReportDescription"].ToString() + "</td>"
//						+ CR + " </tr>"
//						+ CR + "</table>" 
//						+ CR + "<br>" + CR
//						);
//			}
			Response.Write("<br>" + CR);
			Response.Write("<table><tr><td>[<a href=\"/interceuticals/admin/links.aspx\">Administration</a>]</td></tr></table><br>" + CR);

			foreach(DataRow dr in dt.Rows)
			{
				Response.Write("<table class=\"cnetTableWrapper\" width=\"100%\" cellpadding=\"3\" cellspacing=\"0\">"
						+ CR + " <tr>"
						+ CR + "  <td class=\"gridHeader\"><a href=\"default.aspx?RID=" + dr["OTCReportId"].ToString() + "\" class=\"formFont\"><b>" + dr["OTCReportName"].ToString() + "</a></td>"
						+ CR + " </tr>"
						+ CR + " <tr>"
						+ CR + "  <td class=\"formFont\">" + dr["ReportDescription"].ToString() + "</td>"
						+ CR + " </tr>"
						+ CR + "</table>" 
						+ CR + "<br>" + CR
						);
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
