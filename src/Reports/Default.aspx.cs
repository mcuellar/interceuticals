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

namespace Interceuticals.Reports
{
	public class _Default : System.Web.UI.Page
	{
		private string m_thread;
		protected System.Web.UI.WebControls.RadioButtonList rdoReportType;
		protected System.Web.UI.WebControls.Calendar cldStartDate;
		protected System.Web.UI.WebControls.Calendar cldEndDate;
		protected System.Web.UI.WebControls.Button btnBuild;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtReportTypeId;
		protected System.Web.UI.WebControls.Label lblReportHeader;
		protected System.Web.UI.WebControls.CheckBox chkExport;
		protected System.Web.UI.WebControls.Label lblDescription;
		public ITCPage m_page;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			this.m_page.HideWest = true;
			
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("/interceuticals/admin/login.aspx");
			
			if(!Page.IsPostBack)
			{
				this.m_thread = Request.QueryString.ToString().IndexOf("thread") > - 1 ? Request.QueryString["thread"] : "";
				switch(this.m_thread)
				{
					case "AC":
						OTCDatabase db = new OTCDatabase();
						db.Open();
						int reportId = Convert.ToInt32(db.GetDataset("SELECT EngagementReportId FROM EngagementReport WHERE SQL = 'spGetReport_CoordinatorDocument'").Tables[0].Rows[0]["EngagementReportId"]);
						db.ReleaseConnection();
						string lineOrderNumber = Request.QueryString["LON"];
						Response.Write(reportId + " " + lineOrderNumber);
						Response.Redirect("default.aspx?RID=" + reportId + "&LON=" + lineOrderNumber);
						break;
				}
				
				DateTime startDate  = Convert.ToDateTime(System.DateTime.Now.Month.ToString() + "/1/" + System.DateTime.Now.Year.ToString()); 
				DateTime endDate    = System.DateTime.Now.AddDays(1);
				this.txtReportTypeId.Value = Request.QueryString["RID"];
				OTCReport report = new OTCReport(Convert.ToInt32(Request.QueryString["RID"]));
				this.lblReportHeader.Text = report.OTCReportName;
				this.lblDescription.Text = report.OTCReportDescription;
				this.cldStartDate.VisibleDate = startDate;
				this.cldEndDate.VisibleDate = endDate;
				this.cldStartDate.SelectedDate = startDate;
				this.cldEndDate.SelectedDate = endDate;
				///his.ddLineOrders.Visible = false;
				//this.ddPartner.Visible = false;

				string strCookieValue = "";

				//Grab the cookie
				HttpCookie cookie = Request.Cookies["ExportToExcel"];

				//Check to make sure the cookie exists
				if (null != cookie) 
				{
					//Write the cookie value
					strCookieValue = cookie.Value.ToString();
				}
				if(strCookieValue == "true")
					this.chkExport.Checked = true;
				
				/*
				if((report.ReportRestrictions & (int)EDGAReport.Restriction.PartnerSpecific) > 0)
				{
					this.ddPartner.Visible = true;
					this.ddPartner.Fill();
				}
				
				if((report.ReportRestrictions & (int)EDGAReport.Restriction.LineOrderSpecific) > 0)
				{
					this.ddLineOrders.Visible = true;
					this.ddLineOrders.Fill();
					if(Request.QueryString.ToString().IndexOf("LON") > - 1){
						string lineOrderNumber = Request.QueryString["LON"];
						this.ddLineOrders.SetActiveItem(lineOrderNumber);
						this.ddLineOrders.Enabled = false;
						BTG.ITPaper.BTGLineOrder lineOrder = new BTG.ITPaper.BTGLineOrder(Convert.ToInt32(lineOrderNumber));
						this.cldStartDate.VisibleDate = lineOrder.StartDate;
						this.cldEndDate.VisibleDate = System.DateTime.Now;
						this.cldStartDate.SelectedDate = lineOrder.StartDate;
						this.cldEndDate.SelectedDate = System.DateTime.Now;	
					}
				}
				*/
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
			this.chkExport.CheckedChanged += new System.EventHandler(this.chkExport_CheckedChanged);
			this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuild_Click(object sender, System.EventArgs e)
		{
			OTCReport report = new OTCReport(Convert.ToInt32(this.txtReportTypeId.Value));
			string startDate = this.cldStartDate.SelectedDate.ToShortDateString();
			string endDate   = this.cldEndDate.SelectedDate.ToShortDateString();
			string qstring   = "report.aspx?RID=" + this.txtReportTypeId.Value + "&STD=" + startDate + "&EDT=" + endDate;
			//if(this.ddPartner.Visible && this.ddPartner.SelectedIndex > 0)
			//	qstring += "&PID=" + this.ddPartner.SelectedValue;
			//if(this.ddLineOrders.Visible && this.ddLineOrders.SelectedIndex > 0)
			//	qstring += "&LID=" + this.ddLineOrders.SelectedValue;
			
			Response.Redirect(qstring);
		}

		private void chkExport_CheckedChanged(object sender, System.EventArgs e)
		{
			//Create a new cookie, passing the name into the constructor
			HttpCookie cookie = new HttpCookie("ExportToExcel");

			if(chkExport.Checked == true)
				//Set the cookies value
				cookie.Value = "true";
			else
				cookie.Value = "false";

			//Set the cookie to expire in 1 year
			DateTime dtNow = DateTime.Now;
			TimeSpan tsMinute = new TimeSpan(364,0,0,0,0);
			cookie.Expires = dtNow + tsMinute;

			//Add the cookie
			Response.Cookies.Add(cookie);
		}
	}
}
