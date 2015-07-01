using System;
using System.Web;
using OTC.Web.Page;

namespace Interceuticals.Common.Classes
{
	public class ITCPageInterceuticals : OTCPage
	{
		public ITCPageInterceuticals()
		{
			base.TopMargin		= 0;
			base.BottonMargin	= 0;
			base.LeftMargin		= 0;
			base.RightMargin	= 0;
			base.Title = "Interceuticals";
			base.AddHeaderElement("<SCRIPT type=\"text/javascript\" id=\"wa_u\"></SCRIPT><SCRIPT type=\"text/javascript\" src=\"/javascript/interceut1.js\"></SCRIPT>");
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void Start()
		{
			Response.Write("<div align=\"center\">");
			
			HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/Interceuticals/North.aspx");
			//string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Interceuticals\\North.aspx";
			//OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			//HttpContext.Current.Response.Write(r.HTML);
			
			//build body
			Response.Write("<table width=\"725\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">"
					+ CR + " <tr valign=\"top\">"
					+ CR + "  <td width=\"112\">" + CR
					);
					
			this.buildWest();
			
			Response.Write("  </td>"
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
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/Interceuticals/West.htm");
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Interceuticals\\West.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			HttpContext.Current.Response.Write(r.HTML);
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildEast()
		{
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/Interceuticals/East.htm");
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Interceuticals\\East.htm";
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
					+ CR + "  <td>"
					);
			
			this.buildEast();
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "<table>"
					);
			
			
			Response.Write("<table width=\"725\" border=\"0\">"
					+ CR + " <tr>"
					+ CR + "  <td align=\"center\">" + CR
					);
		
			//HttpContext.Current.Server.Execute("/interceuticals/common/HtmlTemplates/Interceuticals/South.htm");
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Common\\HtmlTemplates\\Interceuticals\\South.htm";
			OTC.Web.Page.OTCHtmlReader r = new OTC.Web.Page.OTCHtmlReader(file);
			HttpContext.Current.Response.Write(r.HTML);
		
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
