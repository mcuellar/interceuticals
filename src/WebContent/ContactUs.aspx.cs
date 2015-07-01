using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interceuticals.Common.Util;
using System.Text;
using OTC.Database;
using System.Configuration;


namespace Interceuticals.WebContent
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private String conn = AppLookup.ConnString;

        String email;
        String firstName;
        String lastName;
        String company;
        String address1;
        String address2;
        String city;
        String state;
        String zip;
        String country;
        String phone;
        String whereHeard;
        String comments;
        String interest;
        int contentType = 3;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            email = Request.Form["email"].ToString();
	        firstName	= Request.Form["firstName"].ToString();
	        lastName	= Request.Form["lastName"].ToString();
	        company		= Request.Form["company"].ToString();
	        address1	= Request.Form["address1"].ToString();
	        address2	= Request.Form["address2"].ToString();
	        city		= Request.Form["city"].ToString();
	        state		= Request.Form["state"].ToString();
	        zip			= Request.Form["zip"].ToString();
	        country		= Request.Form["country"].ToString();
	        phone		= Request.Form["phone"].ToString();
	        whereHeard  = Request.Form["whereHeard"].ToString();
            comments = Request.Form["comments"].ToString();
            interest = Request.Form["drp_interest"].ToString();


            StringBuilder sb = new StringBuilder();

            sb.Append("*****************************************");
            sb.AppendLine();
            sb.Append("Source From: Interceuticals Contact");
            sb.AppendLine();
            sb.Append("Project:  Interceuticals Website");
            sb.AppendLine();
            sb.Append("*****************************************");
            sb.AppendLine();
            sb.Append("Contact Email: " + email);
            sb.AppendLine();
	        sb.Append("First Name: " + firstName);
            sb.AppendLine();
            sb.Append("Last Name: " + lastName);
            sb.AppendLine();
            sb.Append("Company: " + company);
            sb.AppendLine();
            sb.Append("Address: " + address1);
            sb.AppendLine();
            sb.Append("Address: " + address2);
            sb.AppendLine();
            sb.Append("City: " + city);
            sb.AppendLine();
            sb.Append("State: " + state);
            sb.AppendLine();
            sb.Append("Zip: " + zip);
            sb.AppendLine();
            sb.Append("Country: " + country);
            sb.AppendLine();
            sb.Append("Contact Phone: " + phone);
            sb.AppendLine();
            sb.Append("Which Products are you interested in?: " + interest);
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("Where Heard: " + whereHeard);
            sb.AppendLine();
            sb.Append("*****************************************");
            sb.AppendLine();
            sb.Append(comments);

            EmailSender emailSender = new EmailSender();
            String notifyEmails = AppLookup.RecipientsContactUs + ",jfarrington@dirigodev.com";
            emailSender.AddEmailAddresses(notifyEmails);

            String result = emailSender.SendEmail("BetterMAN..BetterWOMAN ", "Contact Us - Int", sb.ToString());

            if (result == "")
                Response.Write("Successfully Sent Email");
            else
                Response.Write(result);

            storeEmail();
            
        }

        private void storeEmail()
        {
            OTCDatabase db = null;

            String sql = "spInsertOTCContact " +
                        "@OTCSiteId = 7," +
                        "@OTCContactTypeId = " + contentType +
                        ", @firstName = " + OTCDatabase.SqlFormat(firstName) +
                        ", @lastName = " + OTCDatabase.SqlFormat(lastName) +
                        ", @address1 = " + OTCDatabase.SqlFormat(address1) +
                        ", @address2 = " + OTCDatabase.SqlFormat(address2) +
                        ", @city = " + OTCDatabase.SqlFormat(city) +
                        ", @state = " + OTCDatabase.SqlFormat(state) +
                        ", @zip = " + OTCDatabase.SqlFormat(zip) +
                        ", @phoneNumber = " + OTCDatabase.SqlFormat(phone) +
                        ", @emailAddress = " + OTCDatabase.SqlFormat(email) +
                        ", @comment1 = " + OTCDatabase.SqlFormat(whereHeard) +
                        ", @comment2 = " + OTCDatabase.SqlFormat(company) +
                        ", @comment3 = " + OTCDatabase.SqlFormat(comments);
            
        
		    db = new OTCDatabase(conn);
            db.Open();
            db.SendSQLUpdate(sql);
                
            if (db != null)
                db.ReleaseConnection();

            dv_inter_contact_form_thanks.Visible = true;
            dv_inter_contact_form.Visible = false;
        }

    }
}