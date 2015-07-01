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

namespace Interceuticals
{
	public class Content : System.Web.UI.Page
	{
		public ITCPageInterceuticals m_page = new ITCPageInterceuticals();
		
		private void Page_Load(object sender, System.EventArgs e)
		{

		}

        protected void DisplayContent()
        {

            string htmlFile = Request.QueryString.ToString().IndexOf("CTF") > -1 ? Request.QueryString["CTF"] : "";
            if (htmlFile.Length > 0)
                Server.Execute(htmlFile + ".html");
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
