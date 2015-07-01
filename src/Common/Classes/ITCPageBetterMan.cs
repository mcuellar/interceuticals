using System;
using System.Web;
using OTC.Web.Page;

namespace Interceuticals.Common.Classes
{
	public class ITCPageBetterMan : OTCPage
	{
		public ITCPageBetterMan()
		{
			base.TopMargin		= 0;
			base.BottonMargin	= 0;
			base.LeftMargin		= 0;
			base.RightMargin	= 0;
			base.AddHeaderElement("<SCRIPT type=\"text/javascript\" id=\"wa_u\" ></SCRIPT><SCRIPT type=\"text/javascript\" src=\"/javascript/interceut1.js\"></SCRIPT>");
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void Start()
		{
			string httpHost     = Request.ServerVariables["HTTP_HOST"];
			string queryString  = Request.QueryString.ToString().Length > 0 ? "?" + Request.QueryString.ToString(): "";
		
			//if(httpHost != "www.bettermannow.com")
			//	Response.Redirect("http://www.bettermannow.com" + Request.ServerVariables["SCRIPT_NAME"] + queryString);
					
			Response.Write("<div align=\"center\">");
			
			//string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Betterman\\North.aspx";
			HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterMan/North.aspx");
			//OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			//Response.Write(r.HTML);
			
			//build body
			Response.Write("<table width=\"725\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">"
					+ CR + " <tr valign=\"top\">"
					+ CR + "  <td width=\"113\">" + CR
					);
					
			this.buildWest();
			
			Response.Write("  </td>"
					+ CR + "  <td width=\"700\">" 
					+ CR + "   <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">"
					+ CR + "    <tr valign=\"top\">"
					+ CR + "     <td>" + CR
				);
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildWest()
		{
			if(!(Request.QueryString.ToString().IndexOf("hide") > -1))
			{
				string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Betterman\\West.htm";
				OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
				HttpContext.Current.Response.Write(r.HTML);
				//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterMan/West.htm");
			}
			else
			{
				if(!(Request.QueryString["hide"].IndexOf("W") > -1))
				{
					string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Betterman\\West.htm";
					OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
					HttpContext.Current.Response.Write(r.HTML);
					//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterMan/West.htm");
				}
				else 
					Response.Write("<table width=\"113\"><tr><td>&nbsp;</td></tr></table>" + CR);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildEast()
		{
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Betterman\\East.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			HttpContext.Current.Response.Write(r.HTML);
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterMan/East.htm");
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void End()
		{
			Response.Write("     </td>" + CR
					+ CR + "    </tr>"
					+ CR + "   </table>" 
					+ CR + "  </td>"
					+ CR + "  <td>");
			
			this.buildEast();
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "<table>");
			
			
			Response.Write("<table width=\"725\" border=\"0\">"
				+ CR + " <tr>"
				+ CR + "  <td align=\"center\">" + CR);
		
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterMan/South.htm");
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Betterman\\South.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			Response.Write(r.HTML);
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>" + CR);
				
			Response.Write("</div>" 
					+ CR + "</body>"
					+ CR + "</html>" + CR);
		}
	}
}
