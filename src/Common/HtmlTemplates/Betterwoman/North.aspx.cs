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

namespace Interceuticals.Common.HtmlTemplates.Betterwoman
{
	public class North : System.Web.UI.Page
	{
		private string m_image1;
		private string m_image1a;
		private string m_image1b;
		private string m_image1c;
		private string m_image2;
		private string m_image2a;
		private string m_image2b;
		private string m_image2c;
		private string m_betterWomanSwitch;
		private string m_faqSwitch;
		private string m_testimonialSwitch;
		private string m_researchSwitch;
		private string m_pressSwitch;
		private string m_otherProductsSwitch;
		private string m_orderSwitch;
		private string m_rightMenuImage;
		
		public string BetterWomanSwitch		{get{return(this.m_betterWomanSwitch);	 }}
		public string FaqSwitch				{get{return(this.m_faqSwitch);			 }}
		public string TestimonialsSwitch	{get{return(this.m_testimonialSwitch);	 }}
		public string ResearchSwitch		{get{return(this.m_researchSwitch);		 }}
		public string PressCoverageSwitch	{get{return(this.m_pressSwitch);		 }}
		public string OtherProductsSwitch	{get{return(this.m_otherProductsSwitch); }}
		public string OrderSwitch			{get{return(this.m_orderSwitch);		 }}
		public string Image1				{get{return(this.m_image1);				 }}
		public string Image1a				{get{return(this.m_image1a);		     }}
		public string Image1b				{get{return(this.m_image1b);			 }}
		public string Image1c				{get{return(this.m_image1c);			 }}
		public string Image2				{get{return(this.m_image2);				 }}
		public string Image2a				{get{return(this.m_image2a);		     }}
		public string Image2b				{get{return(this.m_image2b);			 }}
		public string Image2c				{get{return(this.m_image2c);			 }}
		public string RightMenuImage        {get{return(this.m_rightMenuImage);		 }}
		
			
		private void Page_Load(object sender, System.EventArgs e)
		{
			string activeMenu  = Request.QueryString.ToString().IndexOf("a_menu") > - 1 ? Request.QueryString["a_menu"] : "";
			string activeImage = Request.QueryString.ToString().IndexOf("a_image") > - 1 ? Request.QueryString["a_image"] : "bw";
			this.m_rightMenuImage     = "contact-company-home.gif";
			
			switch(activeMenu)
			{
				case "bw":
					this.m_betterWomanSwitch = "_on";
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
				case "contact":
					this.m_rightMenuImage = "contact_on-company-home.gif";
					break;
				case "company":
					this.m_rightMenuImage = "contact-company_on-home.gif";
					break;
			}
			
			switch(activeImage)
			{
				case "bw":
					this.m_image1   = "lev2imagewinbw1.jpg";
					this.m_image1a  = "lev2imagewinbw1a.jpg";
					this.m_image1b  = "lev2imagewinbw1b.jpg";
					this.m_image1c  = "lev2imagewinbw1c.jpg";
					this.m_image2   = "lev2imagewinbw2.jpg";
					this.m_image2a  = "lev2imagewinbw2a.jpg";
					this.m_image2b  = "lev2imagewinbw2b.jpg";
					this.m_image2c  = "lev2imagewinbw2c.jpg";
					break;
				case "company":
					this.m_image1   = "lev2imagecompany1.jpg";
					this.m_image1a  = "lev2imagecompany1a.jpg";
					this.m_image1b  = "lev2imagecompany1b.jpg";
					this.m_image1c  = "lev2imagecompany1c.jpg";
					this.m_image2   = "lev2imagecompany2.jpg";
					this.m_image2a  = "lev2imagecompany2a.jpg";
					this.m_image2b  = "lev2imagecompany2b.jpg";
					this.m_image2c  = "lev2imagecompany2c.jpg";
					break;
				case "testimonial":
					this.m_image1   = "lev2imagetest1.jpg";
					this.m_image1a  = "lev2imagetest1a.jpg";
					this.m_image1b  = "lev2imagetest1b.jpg";
					this.m_image1c  = "lev2imagetest1c.jpg";
					this.m_image2   = "lev2imagetest2.jpg";
					this.m_image2a  = "lev2imagetest2a.jpg";
					this.m_image2b  = "lev2imagetest2b.jpg";
					this.m_image2c  = "lev2imagetest2c.jpg";
					break;
				case "press":
					this.m_image1   = "lev2imagepress1.jpg";
					this.m_image1a  = "lev2imagepress1a.jpg";
					this.m_image1b  = "lev2imagepress1b.jpg";
					this.m_image1c  = "lev2imagepress1c.jpg";
					this.m_image2   = "lev2imagepress2.jpg";
					this.m_image2a  = "lev2imagepress2a.jpg";
					this.m_image2b  = "lev2imagepress2b.jpg";
					this.m_image2c  = "lev2imagepress2c.jpg";
					break;
				case "other":
					this.m_image1   = "lev2imageother1.jpg";
					this.m_image1a  = "lev2imageother1a.jpg";
					this.m_image1b  = "lev2imageother1b.jpg";
					this.m_image1c  = "lev2imageother1c.jpg";
					this.m_image2   = "lev2imageother2.jpg";
					this.m_image2a  = "lev2imageother2a.jpg";
					this.m_image2b  = "lev2imageother2b.jpg";
					this.m_image2c  = "lev2imageother2c.jpg";
					break;
				case "contact":
					this.m_image1   = "lev2imagecontact1.jpg";
					this.m_image1a  = "lev2imagecontact1a.jpg";
					this.m_image1b  = "lev2imagecontact1b.jpg";
					this.m_image1c  = "lev2imagecontact1c.jpg";
					this.m_image2   = "lev2imagecontact2.jpg";
					this.m_image2a  = "lev2imagecontact2a.jpg";
					this.m_image2b  = "lev2imagecontact2b.jpg";
					this.m_image2c  = "lev2imagecontact2c.jpg";
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
