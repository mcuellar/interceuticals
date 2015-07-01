using System;
using System.IO;
using System.Web;
using OTC.Web.Page;
using OTC.Web.ShoppingCart;

namespace Interceuticals.Common.Classes
{
	public class ITCPage : OTCPage
	{
		private int m_shoppingCartId;
		private bool m_hideWest;
		private bool m_hideAll;
		private bool m_isBetterWoman;
		private string m_analyticsTracking;
		
		public int ShoppingCartId		{get{return(this.m_shoppingCartId);}}
		public bool HideAll				{set{this.m_hideAll = value;  }}
		public bool HideWest			{set{this.m_hideWest = value; }}
		public bool IsBetterWoman		{get{return(this.m_isBetterWoman);}}
		public string AnalyticsTracking {get{return(this.m_analyticsTracking);}}
		
		public ITCPage()
		{
			base.BottonMargin = 0;
			base.TopMargin    = 0;
			base.LeftMargin   = 0;
			base.RightMargin  = 0;
			base.BodyWidth    = "1";
			//base.AddHeaderElement("<SCRIPT type=\"text/javascript\" id=\"wa_u\" ></SCRIPT><SCRIPT type=\"text/javascript\" src=\"/javascript/interceut1.js\"></SCRIPT>");
			base.Title = "Interceuticals";
			this.m_shoppingCartId = Convert.ToInt32(HttpContext.Current.Session["shoppingCartId"]);
			this.m_isBetterWoman      = (Request.QueryString["site"] == "bw" || Request.QueryString["site"] == "_bw") ? true : false;
			this.m_analyticsTracking  = this.m_isBetterWoman ? "UA-1185020-1" : "UA-1185020-2"; 
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void Start()
		{
			if(this.m_hideAll)
			{
				Response.Write(""
						+ CR + "<div align=\"center\">"
						+ CR + "<table border=\"0\" cellpadding=\"3\" cellspacing=\"0\" width=\"800\" class=\"tableWrapper\">"
						+ CR + " <tr valign=\"top\">"
						+ CR + "  <td>" + CR
						);
			}
			else
			{
				//if(isBetterWoman)
				//	this.buildBetterWoman();
				//else 
				//{
					Response.Write("<div align=\"center\">" + CR);
					Response.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"700\">"
							+ CR + " <tr valign=\"top\">"
							+ CR + "  <td colspan=\"3\">" + CR
							);
					
					
					string rootDirectory = this.m_isBetterWoman ? "BetterWoman" : "Betterman";
					string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Order\\" + rootDirectory + "\\north.htm";
					OTCHtmlReader reader = new OTCHtmlReader(file);
					Response.Write(reader.HTML);
					//HttpContext.Current.Server.Execute("/Interceuticals/Common/HtmlTemplates/Order/Betterman/north.htm");
					
					Response.Write("  </td>"
							+ CR + " </tr>"
							+ CR + " <tr valign=\"top\">" + CR
							);
				//}//
				
				if(!(this.m_hideWest))
					this.buildWest();
				
				Response.Write("  <td valign=\"top\">" + CR);
			}
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		//private void buildBetterWoman()
		//{
		
		//}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildWest()
		{
			Response.Write("<td width=\"18%\">" + CR);
			string rootDirectory = this.m_isBetterWoman ? "BetterWoman" : "Betterman";
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Order\\" + rootDirectory + "\\west.htm";
			OTCHtmlReader reader = new OTCHtmlReader(file);
			Response.Write(reader.HTML);
			Response.Write("</td>" + CR);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void End()
		{
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>"
					+ CR + "</div>"
					+ CR + "</body>"
					+ CR + "</html>" + CR
					);
		}
	}
}
