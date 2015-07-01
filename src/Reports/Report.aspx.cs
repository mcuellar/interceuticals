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
using OTC;
using OTC.Web;
using OTC.Database;
using Interceuticals.Common.Classes;

namespace Interceuticals.Reports
{
	public class Report : System.Web.UI.Page
	{
		private int m_reportId;
		private int m_partnerId;
		private int m_lineOrderId;
		private char CR = (char)10;
		private bool m_isCSV;
		private DateTime m_startDate;
		private DateTime m_endDate;
		private string m_sortColumn;
		private string m_sortDirection;
		private OTCDatabase m_db = new OTCDatabase();
		private ITCPage m_page;
		private OTCReport m_report;
		
		//==================================
		//
		//==================================
		private void Page_Load(object sender, System.EventArgs e)
		{
			string strCookieValue = "";

			this.m_isCSV = Request.QueryString.ToString().IndexOf("csv") > -1;
			
			//Grab the cookie
			HttpCookie cookie = Request.Cookies["ExportToExcel"];

			//Check to make sure the cookie exists
			if (null != cookie) 
			{
				//Write the cookie value
				strCookieValue = cookie.Value.ToString();
			}
			if(strCookieValue == "true")
				this.m_isCSV = true;


			if(this.m_isCSV)
				Response.ContentType = "application/vnd.ms-excel";
			
			this.m_page  = new ITCPage();
			this.m_page.HideWest = true;
			
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("/interceuticals/admin/login.aspx");
				
			DataRow[] rows;
			this.m_reportId      = Convert.ToInt32(Request.QueryString["RID"]);
			this.m_partnerId     = Request.QueryString.ToString().IndexOf("PID") > - 1 ? Convert.ToInt32(Request.QueryString["PID"]) : 0;
			this.m_lineOrderId   = Request.QueryString.ToString().IndexOf("LID") > - 1 ? Convert.ToInt32(Request.QueryString["LID"]) : 0;
			this.m_report        = new OTCReport(this.m_reportId);
			this.m_startDate     = Convert.ToDateTime(Request.QueryString["STD"]);
			this.m_endDate       = Convert.ToDateTime(Request.QueryString["EDT"]);
			this.m_sortColumn    = Request.QueryString.ToString().IndexOf("sort")  > -1 ? Request.QueryString["sort"] : "";
			this.m_sortDirection = Request.QueryString.ToString().IndexOf("dir")  > -1 ? Request.QueryString["dir"] : "DESC";
			this.m_db.Open();
			
			string sql = this.m_report.SQL + " "
			           + "@startDate = " + OTCDatabase.SqlFormat(this.m_startDate.ToShortDateString())+ ","
			           + "@endDate = " + OTCDatabase.SqlFormat(this.m_endDate.ToShortDateString())
			           ;
			
			//bool bla = (report.ReportRestrictions & (int)EDGAReport.Restriction.PartnerSpecific) > 0;
			
			//if((this.m_report.ReportRestrictions & (int)EDGAReport.Restriction.PartnerSpecific) > 0 && this.m_partnerId > 0)
			//	sql += ", @partnerId = " + this.m_partnerId;
			//if((this.m_report.ReportRestrictions & (int)EDGAReport.Restriction.LineOrderSpecific) > 0 && this.m_lineOrderId > 0)
			//	sql += ", @lineOrderNumber = " + this.m_lineOrderId;
			         
			
			DataTable dt = this.m_db.GetDataset(sql,3600).Tables[0];
			this.m_db.ReleaseConnection();
			//this.m_page.PageMenu = this.buildMenu();
			//this.m_page.MainMenuVisible = true;
			this.m_page.CheckLogin();
			
			if(!(this.m_isCSV))
			{
				this.m_page.OpenHeader();
				this.m_page.CloseHeader();
				this.m_page.Start();
			}
			
			//Complete hack. I need to fix this.
			string genericFilter = dt.Columns.Contains("Order Number") ? "[Order Number] > 0" : "[SortEm] > 0";
			
			if(this.m_sortColumn.Length > 0)
				rows = dt.Select(genericFilter, this.m_sortColumn + " " + this.m_sortDirection);
			else 
				rows = dt.Select();
 			
 			if(this.m_isCSV)
 				this.buildExcelFile(dt,rows);
 			else
 				this.buildGrid(dt,rows);
			
			if(!(this.m_isCSV))
				this.m_page.End();
		}
		
		//=================================
		//
		//=================================
		private void buildExcelFile(DataTable dt, DataRow[] rows)
		{	
			char tab = (char)9;
			foreach(DataColumn dc in dt.Columns){
				if(dc.ColumnName != "SortEm" && dc.ColumnName.IndexOf("NO_DISPLAY") == -1)
					Response.Write(dc.ColumnName + tab);
			}		
				
			Response.Write(CR);
			
			foreach(DataRow dr in rows)
			{
				foreach(DataColumn dc in dt.Columns)
				{
					string columnData  = "";
					switch(dc.DataType.Name)
					{
						case "DateTime" : 
							columnData  = Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString() != "1/1/1900" ? Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString() : "NEVER";
							break;
						case "String" :
							columnData  = dr[dc.ColumnName].ToString();
							break;
						default : 
							columnData  = dr[dc.ColumnName].ToString();
							break;
					}
					
					if(dc.ColumnName != "SortEm" && dc.ColumnName.IndexOf("NO_DISPLAY") == -1)
						Response.Write(columnData.Replace(":^~^:"," ").Replace(tab.ToString()," ").Replace(System.Environment.NewLine, "") + tab);
				}
				Response.Write(CR);
			}
		}
		
		//=================================
		//
		//=================================
		/*
		private EDGAMenu buildMenu()
		{
			EDGAMenu menu = new EDGAMenu();
			menu.MenuWidth = "";
			EDGAMenuItem item  = new EDGAMenuItem();
			item.Text = "Reports";
			item.HREF = "reportpicker.aspx";
			menu.AddMenuItem(item);
			item = new EDGAMenuItem();
			item.Text = "Change Dates";
			item.HREF = "default.aspx?RID=" + this.m_report.OTCReportId;
			menu.AddMenuItem(item);
			item = new EDGAMenuItem();
			item.Text = "<img src=\"/edga/images/icons/csv.gif\" border=\"0\">";
			string qstring = "report.aspx?RID=" + this.m_report.OTCReportId + "&thread=csv&STD=" + this.m_startDate.ToShortDateString() + "&EDT=" + this.m_endDate.ToShortDateString();
			if(this.m_lineOrderId > 0)
				qstring += "&LID=" + this.m_lineOrderId;
			item.HREF = qstring;
			menu.AddMenuItem(item);
			return(menu);
		}
		*/
		
		//==================================
		//
		//==================================
		private void buildGrid(DataTable dt, DataRow[] rows)
		{
			string className = "gridRowAlt";
			
			Response.Write("<br><table class=\"tableWrapper\" cellpadding=\"3\" cellspacing=\"0\" width=\"100%\" border=\"0\">"
					+ CR + " <tr>" 
					+ CR + "  <td colspan=\"" + ((dt.Columns.Count / 2) + 2) + "\" class=\"gridHeader\"><b>" + this.m_report.OTCReportName + "</b> " + this.m_startDate.ToShortDateString()+ "<i> thru </i>" + this.m_endDate.ToShortDateString() + " - " + this.m_report.OTCReportDescription + " : <b>" + rows.Length + " : Records</b></td>"
					+ CR + "  <td align=\"right\" class=\"gridHeader\" nowrap colspan=\"" + ((dt.Columns.Count / 2) - 2)+ "\">[ <a href=\"default.aspx?RID=" + this.m_reportId + "\">change dates</a> ] &nbsp; [ <a href=\"reportpicker.aspx\">change report</a> ]</td>"
					+ CR + " <tr>"
					);
			
			foreach(DataColumn dc in dt.Columns)
			{
				string qstring = "report.aspx?sort=" + dc.ColumnName + "&dir=" + (this.m_sortDirection == "DESC" ? "ASC" : "DESC") + "&STD=" + this.m_startDate.ToShortDateString() + "&EDT=" + this.m_endDate.ToShortDateString() + "&RID=" + this.m_reportId;
				if(this.m_lineOrderId > 0)
					qstring += "&LID=" + this.m_lineOrderId;
				
				if(dc.ColumnName != "SortEm" && dc.ColumnName.IndexOf("NO_DISPLAY") == -1)
					Response.Write("  <td class=\"gridHeader\" nowrap><b><a href=\"" + qstring + "\">" + dc.ColumnName + "</a></td>" + CR);
			}		
				
			Response.Write(" </tr>" + CR);
			
			OTCEncryption crypt = new OTCEncryption(7);
			
			foreach(DataRow dr in rows)
			{
				className = className == "gridRow" ? "gridRowAlt" : "gridRow";
				Response.Write(" <tr class=\"" + className + "\" valign=\"top\">" + CR);
				foreach(DataColumn dc in dt.Columns)
				{
					string columnData  = "";
					string columnAlign = "";
					
					switch(dc.DataType.Name)
					{
						case "DateTime" : 
							columnData  = Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString() != "1/1/1900" ? Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString() : "NEVER";
							columnAlign = "left";
							break;
						case "String" :
							columnData  = dr[dc.ColumnName].ToString();
							columnAlign = "left";
							break;
						default : 
							columnData  = dr[dc.ColumnName].ToString();
							columnAlign = "right";
							break;
					}
					
					if(dc.ColumnName != "SortEm" && dc.ColumnName.IndexOf("NO_DISPLAY") == -1)
					{
						if(dc.ColumnName.IndexOf("DECRYPT") > -1)
						{
							//USED FOR SRS ONLY
							if(dc.ColumnName != "DECRYPT_EXPIRES")
								columnData = crypt.Decrypt(columnData.Replace("DECRYPT_",""));
							else
							{
								string month = crypt.Decrypt(columnData.Split(' ')[0]);
								string year  = crypt.Decrypt(columnData.Split(' ')[1]);
								columnData = (month.Length < 2 ? "0" + month : month) + "/" + year.Substring(2,2);
							}
						}

                        string comments = "";
                        string shortComments = "";
                        if (dc.ColumnName == "Comments")
                        {
                            comments = columnData.Replace(":^~^:", "<br>");

                            if (comments.Length > 50)
                            {
                                shortComments = "<a href=\"#nogo\" class=\"css_tooltip\">" + comments.Substring(0, 50) + "...";
                                shortComments += "<span>" + comments + "</span></a>";
                            }

                            Response.Write(" <td width='200' class=\"formFont\" align=\"" + columnAlign + "\">" + shortComments + "</td>" + CR);
                        }
                        else
                            Response.Write(" <td class=\"formFont\" align=\"" + columnAlign + "\" nowrap>" + columnData.Replace(":^~^:", "<br>") + "</td>" + CR);
					}
				}
				Response.Write(" </tr>");
			}
			
			Response.Write("</table>" + CR);
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
