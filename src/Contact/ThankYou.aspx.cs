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
using OTC.Web;
using Interceuticals.Common.Classes;
using Interceuticals.Common.Util;

namespace Interceuticals.Contact
{
	public class ThankYou : System.Web.UI.Page
	{
		private string m_responseMessage;
		private OTCContact m_contact;
		public string ResponseMessage {get{return(this.m_responseMessage);}}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int contactId = Request.QueryString.ToString().IndexOf("CTID") > - 1 ? Convert.ToInt32(Request.QueryString["CTID"]) : 1744;
			this.m_contact = new OTCContact(contactId);
			switch(this.m_contact.OTCContactTypeId)
			{
				case (int)Contact.OTCContactType.BetterManContact:
					this.sendMessage("Betterman Contact","BetterMAN");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal} h2 {font-family: Arial, Helvetica, sans-serif; font-size:14px; font-style: normal; line-height: 14px; font-weight: normal} p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style> <BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><h2>Important notice: save <a href=\"mailto:info@interceuticals.com\">info@interceuticals.com</a> in your email address book now to receive future notice about your winning of the prize, and our free bulletin and specials via email. Thank you. </h2><HR><P> Your message has been sent. Thank You. Click here to go to the <A HREF=\"http://www.bettermannow.com/interceuticals/betterman/index.html\"> BetterMAN Home Page</A></BODY></HTML>";
					break;
				case (int)Contact.OTCContactType.BetterManWin3:
					this.sendMessage("Betterman Win 3","BetterMAN");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal} h2 {font-family: Arial, Helvetica, sans-serif; font-size:14px; font-style: normal; line-height: 14px; font-weight: normal} p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style> <BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><h2>Important notice: save <a href=\"mailto:info@interceuticals.com\">info@interceuticals.com</a> in your email address book now to receive future notice about your winning of the prize, and our free bulletin and specials via email. Thank you. </h2><HR><P> Your message has been sent. Thank You. Click here to go to the <A HREF=\"http://www.bettermannow.com/interceuticals/betterman/index.html\"> BetterMAN Home Page</A></BODY></HTML>";
					break;
				case (int)Contact.OTCContactType.BetterWomanContact:
					this.sendMessage("Betterwoman Contact","BetterWOMAN");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal}h2 {font-family: Arial, Helvetica, sans-serif; font-size:14px; font-style: normal; line-height: 14px; font-weight: normal}p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style><BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><h2>Important notice: save <a href=\"mailto:info@interceuticals.com\">info@interceuticals.com</a> in your email address book now to receive future notice about your winning of the prize, and our free bulletin and specials via email. Thank you. </h2><HR><P> Your message has been sent. Thank You. Click here to go to the <A HREF=\"http://www.betterwomannow.com/\"> BetterWOMAN Home Page</A>.</BODY></HTML>";
					break;
				case (int)Contact.OTCContactType.BetterWomanWin3:
					this.sendMessage("Betterwoman Win 3","BetterWOMAN");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal}h2 {font-family: Arial, Helvetica, sans-serif; font-size:14px; font-style: normal; line-height: 14px; font-weight: normal}p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style><BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><h2>Important notice: save <a href=\"mailto:info@interceuticals.com\">info@interceuticals.com</a> in your email address book now to receive future notice about your winning of the prize, and our free bulletin and specials via email. Thank you. </h2><HR><P> Your message has been sent. Thank You. Click here to go to the <A HREF=\"http://www.betterwomannow.com/\"> BetterWOMAN Home Page</A>.</BODY></HTML>";
					break;
				case (int)Contact.OTCContactType.InterceuticalsContact:
					this.sendMessage("Interceuticals Contact","Interceuticals");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal}p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style><BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><HR><P>Your message has been sent. Thank You.Click here to go to the <A HREF=\"/interceuticals/index.html\"> Interceuticals Home Page</A>.</BODY></HTML>";
					break;
				case (int)Contact.OTCContactType.NewsLetter:
					this.sendMessage("Interceuticals Newsletter","Interceuticals");
					this.m_responseMessage = "<HTML><HEAD><TITLE>Thank You</TITLE></HEAD><style type=\"text/css\">h1 {font-family: Arial, Helvetica, sans-serif; font-size:18px; font-style: normal; line-height: 14px; font-weight: normal}p {font-family: Arial, Helvetica, sans-serif; font-size:12px; font-style: normal; line-height: 14px; font-weight: normal}</style><BODY BGCOLOR=#FFFFFF><H1><b>Thank You</b></H1><HR><P>Your message has been sent. Thank You.Click here to go to the <A HREF=\"/interceuticals/index.html\"> Interceuticals Home Page</A>.</BODY></HTML>";
					break;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="c"></param>
		private void sendMessage(string source, string project)
		{
			string body = "";
			body = "-----------------------------------------" + (char)10 +
			body + "Source Form: " +  source + (char)10 +
			body + "Project: " +  project + (char)10 + 
			body + "-----------------------------------------" + (char)10 +
			body + "Contact Email: " + this.m_contact.EmailAddress + (char)10 +
			body + "First Name: " + this.m_contact.FirstName + (char)10 +
			body + "Last Name: " + this.m_contact.LastName + (char)10 + 
			body + "Company: " + this.m_contact.Company + (char)10 + 
			body + "Address: " + this.m_contact.Address  + (char)10 + 
			body + "Address: " + this.m_contact.Address2 + (char)10 +
			body + "City: " + this.m_contact.City + (char)10 + 
			body + "State: " + this.m_contact.State + (char)10 + 
			body + "Zip: " + this.m_contact.Zip + (char)10 + 
			body + "Country: " + this.m_contact.CountryCode + (char)10 + 
			body + "Contact Phone: " + this.m_contact.PhoneNumber  + (char)10 + 
			body + "Where Heard: " + this.m_contact.WhereDidYouHear + (char)10 + 
			body + "-------------------------------------" + (char)10 + 
			body + this.m_contact.Comment3
			;

            EmailSender mail = new EmailSender();

            String subject = "Product Order Form Reply";
            String notifyEmails = "pwishnow@interceuticals.com";

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
