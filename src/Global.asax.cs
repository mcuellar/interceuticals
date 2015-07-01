using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using OTC.Web;
using OTC.Web.User;
using OTC.Web.ShoppingCart;
using Interceuticals.Common.Util;
using Interceuticals.Cache;


namespace Interceuticals 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{ 
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{ 

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
            OTCShoppingCart cart = new OTCShoppingCart(Session.SessionID);
            OTCUser user = new OTCUser();
            Session["shoppingCartId"] = cart.AddNew();
            Session["user"] = new OTCUser();
            Session["SID"] = 0;
            Session["WantsMembership"] = true;
            Session["viewedMemberShip"] = false;
            Session.Timeout = 240;
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
            //EmailSender emailSender = new EmailSender();
            //String notifyEmails = AppLookup.RecipientsAlerts;
            //emailSender.AddEmailAddresses(notifyEmails);

            //String subject = "Interceuticals.com ERROR";
            //String body = Server.GetLastError().Message + (char)10 + Server.GetLastError().InnerException;
            
            //emailSender.SendEmail(subject, body);

		}

		protected void Session_End(Object sender, EventArgs e)
		{


		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

