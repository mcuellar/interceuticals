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
using OTC.Web;
using OTC.Web.Controls;
using OTC.Database;
using OTC.Web.Product;
using OTC.Web.Promotion;

namespace Interceuticals.Admin
{
	public class PromotionList : System.Web.UI.Page
	{
		public ITCPage m_page;
		private string m_thread;
		private OTCDatabase m_db = new OTCDatabase();
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_thread = Request.QueryString.ToString().IndexOf("thread") > -1 ? Request.QueryString["thread"] : "";
			
			if(this.m_thread == "delete")
				this.doDelete();
			
			char CR = (char)10;
			int counter = 0;
			this.m_db.Open();
			DataSet ds    = this.m_db.GetDataset("spGetOTCPromotionList");
			DataTable dt  = ds.Tables[0];
			DataTable dt2 = ds.Tables[1];
			this.m_db.ReleaseConnection();
			
			this.m_page = new ITCPage();
			
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("Login.aspx");
				
			this.m_page.HideWest = true;
			this.m_page.OpenHeader();
			this.m_page.CloseHeader();
			this.m_page.Start();
			
			Response.Write("<table border=\"0\" width=\"725\">" + CR
					+ CR + " <tr>"
					+ CR + "  <td colspan=\"2\"><table title=\"click here to add new promotion\" class=\"toolbarButton\" onclick=\"javascript:addNew()\"><tr><td>Add New Promotion</td><td><img src=\"/interceuticals/images/add.gif\"></td></tr></table></td>"
					+ CR + " </tr>"
					+ CR + " <tr valign=\"top\">"
					);
			foreach(DataRow dr in dt.Rows)
			{
				Response.Write("  <td>" + CR);
				this.buildPromotionSquare(dr,dt2.Select("OTCPromotionId = " + dr["OTCPromotionID"].ToString()));
				Response.Write("  </td>" + CR);
				counter ++;
				if(counter > 1)
				{
					counter = 0;
					Response.Write("  </tr>"
							+ CR + "  <tr>"
							+ CR + "   <td colspan=\"2\">&nbsp;</td>"
							+ CR + "  </tr>"
							+ CR + "  <tr>"
							);
				}
			}
			Response.Write(" </tr>"
					+ CR + "</table>" + CR);
			
			this.m_page.End();	
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void doDelete()
		{
			int promotionId = Convert.ToInt32(Request.QueryString["PID"]);
			OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(promotionId);
			if(p.Delete()){
				Response.Redirect("PromotionList.aspx?thread=deleteresult&result=1");
			} else {
				Response.Redirect("PromotionList.aspx?thread=deleteresult&result=0");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildPromotionSquare(DataRow dr, DataRow[] rows)
		{
			char CR = (char)10;
			string fontColor    = Convert.ToBoolean(dr["IsActive"]) == true ? "black" : "gray";
			string activateLink = Convert.ToBoolean(dr["IsActive"]) == false ? "<font color=\"white\">THIS PROMOTION IS NOT ACTIVE</font>" : "";
			string tableClass   = Convert.ToBoolean(dr["IsActive"]) == false ? "tableWrapperInactivePromotion" : "tableWrapper";
			 
			Response.Write("<table class=\"" + tableClass + "\" width=\"100%\">"
					+ CR + " <tr>"
					+ CR + "  <td colspan=\"2\" background=\"/interceuticals/images/blue-bg.gif\"><table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td><a href=\"promotionv2.aspx?PID=" + dr["OTCPromotionId"].ToString() + "\"><font color=\"white\">Edit</a></td><td align=\"center\">" + activateLink + "</td><td align=\"right\"><a href=\"javascript:deleteCampaign(" + dr["OTCPromotionId"].ToString() + ",'" + dr["PromotionKey"].ToString() + "')\"><img src=\"/interceuticals/images/delete.gif\" border=\"0\"></a></td></tr></table></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Runs : </td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + Convert.ToDateTime(dr["StartDate"]).ToShortDateString() + "&nbsp; - &nbsp;" + (Convert.ToDateTime(dr["EndDate"]).ToShortDateString() == "1/1/1900" ? "<b><i><font color=\"red\">Continuous<b>" : Convert.ToDateTime(dr["EndDate"]).ToShortDateString()) + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Key:</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + dr["PromotionKey"].ToString() + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td width=\"100\"><b>Name: </td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + dr["PromotionName"].ToString() + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Description:</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + dr["PromotionDescription"].ToString() + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Number Of Uses</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + dr["UsageCount"].ToString() + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>DiscountPercentage</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + Convert.ToDouble(dr["DiscountPercentage"]).ToString("p") + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Discount Amount</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + Convert.ToDouble(dr["DiscountAmount"]).ToString("c") + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><b>Minimum Purchase Amount</td>"
					+ CR + "  <td><font color=\"" + fontColor + "\">" + Convert.ToDouble(dr["MinimumPurchaseAmount"]).ToString("c") + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr><td colspan=\"2\">"
					);
			
			Response.Write("<div class=\"promotionProductWrapper\">"
					+ CR + "<table width=\"100%\">" + CR
					);
			
			foreach(DataRow row in rows)
			{
				Response.Write("<tr><td>" + row["ProductName"].ToString() + "</td></tr>");
			}
			
			Response.Write("</table>"
					+ CR + "</div>" + CR
					);
					
			Response.Write(" </td></tr>"
					+ CR + " <tr>"
					+ CR + "  <td colspan=\"2\" align=\"center\"><a href=\"/interceuticals/product/default.aspx\">Test Promotion</td></td>"
					+ CR + " </tr>"
					+ CR + "</table>"
					);				
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
