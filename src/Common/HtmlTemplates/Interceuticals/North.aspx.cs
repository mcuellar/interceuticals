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

namespace Interceuticals.Common.HtmlTemplates.Interceuticals
{
	public class North : System.Web.UI.Page
	{
		private string m_rightMenuImageCompany;
		private string m_rightMenuImageContact;
		
		public string RightMenuImageCompany {get{return(this.m_rightMenuImageCompany);}}
		public string RightMenuImageContact {get{return(this.m_rightMenuImageContact);}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			string activeMenu     = Request.QueryString.ToString().IndexOf("a_menu") > - 1 ? Request.QueryString["a_menu"] : "bw";
			this.m_rightMenuImageCompany = "company.gif";
			this.m_rightMenuImageContact = "contactus.gif";
			
			switch(activeMenu)
			{
				case "contact":
					this.m_rightMenuImageCompany = "company.gif";
					this.m_rightMenuImageContact = "contactus_on.gif";
					break;
				case "company":
					this.m_rightMenuImageCompany = "company_on.gif";
					this.m_rightMenuImageContact = "contactus.gif";
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
