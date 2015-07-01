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
using OTC.Web.User;

namespace Interceuticals.Admin
{
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPassword;
		protected System.Web.UI.WebControls.Button btnSave;
		public ITCPage m_page;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(OTCUser.AuthenticateUser(this.txtUserName.Text,this.txtPassword.Value) == OTCUser.LoginStatus.Passed)
				Response.Redirect("Links.aspx");
		}
	}
}
