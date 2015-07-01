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
using OTC.Database;
using OTC.Web.ECommerce;
using OTC.Web.SalesOrder;
using Interceuticals.Common.Util;


namespace Interceuticals.Common
{
	public class Notifier : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
            EmailSender mail = new EmailSender();

            String subject = "SRS Notification Has Run: " + System.DateTime.Now;
            String body = "SRS Has executed successfully.";
            String notifyEmails = "chris@olympictcs.com,pwishnow@interceuticals.com,Jstilwell@interceuticals.com";

            mail.AddEmailAddresses(notifyEmails);
            mail.SendEmail(subject, body);
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
