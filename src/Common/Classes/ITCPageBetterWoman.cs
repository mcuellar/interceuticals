using System;
using System.Web;
using OTC.Web.Page;

namespace Interceuticals.Common.Classes
{
	public class ITCPageBetterWoman : OTCPage
	{
		public ITCPageBetterWoman()
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
			
			//if(httpHost != "www.betterwomannow.com")
			//   Response.Redirect("http://www.betterwomannow.com" + Request.ServerVariables["SCRIPT_NAME"] + queryString);
				
			Response.Write("<div align=\"center\">");
			
			HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterWoman/North.aspx");
			
			//build body
			Response.Write("<table width=\"725\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">"
					+ CR + " <tr valign=\"top\">"
					+ CR + "  <td width=\"112\">" + CR
					);
					
			this.buildWest();
			
			Response.Write(" </td>"
					+ CR + "  <td width=\"700\">" 
					+ CR + "   <table border=\"0\" cellpadding=\"2\" cellspacing=\"0\">"
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
				string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\BetterWoman\\West.htm";
				OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
				HttpContext.Current.Response.Write(r.HTML);
				//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterWoman/West.htm");
			}
			else
			{
				if(!(Request.QueryString["hide"].IndexOf("W") > -1))
				{
					string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\BetterWoman\\West.htm";
					OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
					HttpContext.Current.Response.Write(r.HTML);
					//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterWoman/West.htm");
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
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\BetterWoman\\east.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			HttpContext.Current.Response.Write(r.HTML);
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
				+ CR + "  <td align=\"center\">" + CR
				);
		
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\BetterWoman\\South.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			HttpContext.Current.Response.Write(r.HTML);
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/BetterWoman/South.htm");
		
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>" + CR
				);
			
			Response.Write("</div>" 
				+ CR + "</body>"
				+ CR + "</html>" + CR
				);
		}
	}
}
