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

namespace Interceuticals.Contact
{
	public enum OTCContactType
	{
		BetterManContact = 1,
		BetterWomanContact = 2,
		InterceuticalsContact = 3,
		NewsLetter = 4,
		BetterManWin3 = 5,
		BetterWomanWin3 = 6
	}
	
	public class _Default : System.Web.UI.Page
	{
		private int m_contactType;
		protected System.Web.UI.WebControls.TextBox txtHowDidYouHear;
		protected System.Web.UI.WebControls.TextBox txtEmailAddress;
		protected System.Web.UI.WebControls.TextBox txtCompany;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtComments;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldComments;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.m_contactType = Request.QueryString.ToString().IndexOf("CTP") > -1 ? Convert.ToInt32(Request.QueryString["CTP"]) : 3;
			}
			catch(System.Web.HttpRequestValidationException)
			{
			
			}
		}
		
		public void WriteHeader()
		{
			switch(this.m_contactType)
			{
				case (int)OTCContactType.BetterManContact :
					ITCPageBetterMan page1 = new ITCPageBetterMan();
					page1.OpenHeader();
					page1.CloseHeader();
					page1.Start();
					break;
				case (int)OTCContactType.BetterManWin3 :
					ITCPageBetterMan page2 = new ITCPageBetterMan();
					page2.OpenHeader();
					page2.CloseHeader();
					page2.Start();
					break;
				case (int)OTCContactType.BetterWomanContact :
					ITCPageBetterWoman page3 = new ITCPageBetterWoman();
					page3.OpenHeader();
					page3.CloseHeader();
					page3.Start();
					break;
				case (int)OTCContactType.BetterWomanWin3 :
					ITCPageBetterWoman page4 = new ITCPageBetterWoman();
					page4.OpenHeader();
					page4.CloseHeader();
					page4.Start();
					break;
				case (int)OTCContactType.InterceuticalsContact :
					ITCPageBetterMan page5 = new ITCPageBetterMan();
					page5.OpenHeader();
					page5.CloseHeader();
					page5.Start();
					break;
				case (int)OTCContactType.NewsLetter :
					string bla5 = "";
					break;
			}
		}
		
		
		public void WriteFooter()
		{
			switch(this.m_contactType)
			{
				case (int)OTCContactType.BetterManContact :
					ITCPageBetterMan page1 = new ITCPageBetterMan();
					page1.End();
					break;
				case (int)OTCContactType.BetterManWin3 :
					ITCPageBetterMan page2 = new ITCPageBetterMan();
					page2.End();
					break;
				case (int)OTCContactType.BetterWomanContact :
					ITCPageBetterWoman page3 = new ITCPageBetterWoman();
					page3.End();
					break;
				case (int)OTCContactType.BetterWomanWin3 :
					ITCPageBetterWoman page4 = new ITCPageBetterWoman();
					page4.End();
					break;
				case (int)OTCContactType.InterceuticalsContact :
					ITCPage page5 = new ITCPage();
					page5.End();
					break;
				case (int)OTCContactType.NewsLetter :
					ITCPageBetterMan page6 = new ITCPageBetterMan();
					page6.End();
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
				OTCContact c = new OTCContact();
				c.Address = this.txtAddress.Text;
				c.Address2 = this.txtAddress2.Text;
				c.City = this.txtCity.Text;
				c.Comment1 = this.txtHowDidYouHear.Text;
				c.Comment2 = this.txtCompany.Text;
				c.Comment3 = this.txtComments.Value;
				c.EmailAddress = this.txtEmailAddress.Text;
				c.FirstName = this.txtFirstName.Text;
				c.LastName = this.txtLastName.Text;
				c.PhoneNumber = this.txtPhone.Text;
				c.SiteId = 7;
				c.State = this.txtState.Text;
				c.Zip = this.txtZip.Text;
				c.Add();
		}
	}
}
