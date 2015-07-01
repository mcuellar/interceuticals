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
	public class BetterWoman : System.Web.UI.Page
	{
		public ITCPageBetterWoman m_page = new ITCPageBetterWoman();
		protected System.Web.UI.WebControls.TextBox txtHowDidYouHear;
		protected System.Web.UI.WebControls.TextBox txtEmailAddress;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldEmail;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtCompany;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.TextBox txtCountry;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldComments;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtComments;
		
		private void Page_Load(object sender, System.EventArgs e)
		{

		}
		
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			OTCContact c = new OTCContact();
			c.OTCContactTypeId = (int)OTCContactType.BetterWomanContact;
			c.Address = this.txtAddress.Text;
			c.Address2 = this.txtAddress2.Text;
			c.City = this.txtCity.Text;
			//c.Comment1 = this.txtHowDidYouHear.Text; depricated
			//c.Comment2 = this.txtCompany.Text; depricated
			c.Comment3 = this.txtComments.Value;
			c.CountryCode = this.txtCountry.Text;
			c.EmailAddress = this.txtEmailAddress.Text;
			c.FirstName = this.txtFirstName.Text;
			c.LastName = this.txtLastName.Text;
			c.PhoneNumber = this.txtPhone.Text;
			c.SiteId = 7;
			c.State = this.txtState.Text;
			c.Zip = this.txtZip.Text;
			c.WhereDidYouHear = this.txtHowDidYouHear.Text;
			c.Company = this.txtCompany.Text;
			Response.Redirect("thankyou.aspx?CTID=" + c.Add());
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
	}
}
