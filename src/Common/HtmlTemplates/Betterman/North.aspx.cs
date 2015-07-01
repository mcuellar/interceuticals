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

namespace Interceuticals.Common.HtmlTemplates.Betterman
{
	public class North : System.Web.UI.Page
	{
		private string m_topHeaderImage    = ""; //Image is split into two parts
		private string m_bottomHeaderImage = "";
		private string m_bettermanSwitch;
		private string m_faqSwitch;
		private string m_testimonialSwitch;
		private string m_researchSwitch;
		private string m_pressSwitch;
		private string m_otherProductsSwitch;
		private string m_orderSwitch;
		private string m_rightMenuImageCompany;
		private string m_rightMenuImageContact;
		
		public string BetterManSwitch		{get{return(this.m_bettermanSwitch);	   }}
		public string FaqSwitch				{get{return(this.m_faqSwitch);			   }}
		public string TestimonialsSwitch	{get{return(this.m_testimonialSwitch);	   }}
		public string ResearchSwitch		{get{return(this.m_researchSwitch);		   }}
		public string PressCoverageSwitch	{get{return(this.m_pressSwitch);		   }}
		public string OtherProductsSwitch	{get{return(this.m_otherProductsSwitch);   }}
		public string OrderSwitch			{get{return(this.m_orderSwitch);		   }}
		public string TopHeaderImage	    {get{return(this.m_topHeaderImage);		   }}
		public string BottomHeaderImage	    {get{return(this.m_bottomHeaderImage);     }}
		public string RightMenuImageCompany {get{return(this.m_rightMenuImageCompany); }}
		public string RightMenuImageContact {get{return(this.m_rightMenuImageContact); }}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			string activeMenu  = Request.QueryString.ToString().IndexOf("a_menu") > - 1 ? Request.QueryString["a_menu"] : "";
			string activeImage = Request.QueryString.ToString().IndexOf("a_image") > - 1 ? Request.QueryString["a_image"] : "eri";
			this.m_rightMenuImageCompany = "navcompany.gif";
			this.m_rightMenuImageContact = "navcontactus.gif";
			
			switch(activeMenu)
			{
				case "bm":
					this.m_bettermanSwitch = "_on";
					break;
				case "faq":
					this.m_faqSwitch = "_on";
					break;
				case "testimonial":
					this.m_testimonialSwitch = "_on";
					break;
				case "research":
					this.m_researchSwitch = "_on";
					break;
				case "press":
					this.m_pressSwitch = "_on";
					break;
				case "product":
					this.m_otherProductsSwitch = "_on";
					break;
				case "order":
					this.m_orderSwitch = "_on";
					break;
					//navcontactus_on.gif
					//navcompany_on.gif
				case "company":
					this.m_rightMenuImageCompany = "navcompany_on.gif";
					this.m_rightMenuImageContact = "navcontactus.gif";
					break;
				case "contact":
					this.m_rightMenuImageCompany = "navcompany.gif";
					this.m_rightMenuImageContact = "navcontactus_on.gif";
					break;
			}
			
			switch(activeImage)
			{
				case "eri":
					this.m_topHeaderImage = "erecimage1.jpg";
					this.m_bottomHeaderImage = "erecimage2.jpg";
					break;
				case "faq":
					this.m_topHeaderImage = "faqimage1.jpg";
					this.m_bottomHeaderImage = "faqimage2.jpg";
					break;
				case "bm":
					this.m_topHeaderImage = "bettermanimage1.jpg";
					this.m_bottomHeaderImage = "bettermanimage2.jpg";
					break;
				case "press":
					this.m_topHeaderImage = "press1.jpg";
					this.m_bottomHeaderImage = "press2.jpg";
					break;
				case "misc":
					this.m_topHeaderImage = "miscimage1.jpg";
					this.m_bottomHeaderImage = "miscimage2.jpg";
					break;
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
