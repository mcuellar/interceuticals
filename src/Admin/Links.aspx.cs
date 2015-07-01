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
using OTC.Database;
using OTC.Web;
using OTC.Web.Controls;

namespace Interceuticals.Admin
{
	public class Links : System.Web.UI.Page
	{
		public ITCPage m_page;
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("Login.aspx");
			this.m_page.HideWest = true;
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
