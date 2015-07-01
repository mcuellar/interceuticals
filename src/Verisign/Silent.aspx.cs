using System;
using System.Net;
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
using log4net;
using System.Reflection;

namespace Interceuticals.Verisign
{
	public class Silent : System.Web.UI.Page
	{
        private OTCSalesOrder m_order;

        private OTCDatabase m_db = new OTCDatabase();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public OTCSalesOrder Order { get { return (this.m_order); } }
        public String SiteName { get; set; }
        public String CrossDomainTracking { get; set; }

		private void Page_Load(object sender, System.EventArgs e)
		{

			
			ArrayList products      = new ArrayList();
			int otcSiteMemberId     = Convert.ToInt32(Request.Form["user1"]);
			int otcSalesOrderId     = Convert.ToInt32(Request.Form["user2"]);
            SiteName                = Request.Form["user3"];
            CrossDomainTracking     = Request.Form["user4"];
			int result			    = Convert.ToInt32(Request.Form["RESULT"]);
			string authCode			= Request.Form["AUTHCODE"];
			string responseMessage	= Request.Form["RESPMSG"];
			string avsData          = Request.Form["AVSDATA"];
			string pnrRef           = Request.Form["PNREF"];
			//string cardNumber       = Request.Form["CARDNUM"];
            OTCVerisignTransaction tran = null;
            OTCSalesOrder order = null;

            try
            {
                Log.Info("Received post from paypal.");
                Log.InfoFormat("MemberID = {0} SalesOrderID = {1} Result = {2} AuthCode = {3} ResponseMessage = {4}", otcSiteMemberId.ToString(), otcSalesOrderId.ToString(), result.ToString(), authCode, responseMessage);
                tran = new OTCVerisignTransaction();
                order = new OTCSalesOrder(otcSalesOrderId);
                //OTCCreditCard card   = new OTCCreditCard(10181);
                //card.CardNumber      = cardNumber;
                ////card.ExpirationMonth = 7.ToString();
                //card.ExpirationYear  = 2007.ToString();
                //card.OTCSiteMemberId = otcSiteMemberId;
                //card.Add();
                //FFTProduct product   = new FFTProduct(productId);
                //UNCOMMENT ALL THIS
                tran.AuthCode = authCode.ToString();
                tran.OTCSalesOrderId = otcSalesOrderId;
                tran.OTCSiteMemberId = otcSiteMemberId;
                tran.AVSData = avsData;
                tran.Cost = order.TotalCost;
                tran.PNRRef = pnrRef;
                tran.ResponseMessage = responseMessage;
                tran.Result = result;
                tran.Add();

                m_order = order;

            }
            catch (Exception error)
            {
                Log.Error("Unable to complete Paypal transaction.", error);             
            }

            if (responseMessage.ToLower() == "approved")
            {

                string mailBody = OTCSalesOrder.GetEmailProductString(order.OTCSalesOrderId);

                EmailSender mail = new EmailSender("customerservice@interceuticals.com", "BetterMAN.BetterWOMAN");

                String subject = "Order Confirmation - Interceuticals Order " + order.OTCSalesOrderId;
                String notifyEmails = order.EmailAddress;

                mail.AddEmailAddresses(order.EmailAddress);
                mail.AddBccEmailAddresses(AppLookup.RecipientsOrders);
                String error = mail.SendEmail(subject, mailBody);

                if (error == "")
                    Response.Write("Successfully sent email.<br>");
                else
                {
                    Response.Write("Error in sending email.  " + error);
                    Log.Error(error);
                }

                OTC.Web.Promotion.OTCPromotion pr = new OTC.Web.Promotion.OTCPromotion(order.OTCPromotionId);
                pr.AddPromotionUsage(order.OTCSiteMemberId, order.OTCSalesOrderId);

                try
                {
                    HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create("https://loc1.hitsprocessor.com/confirmation.asp?acct=interceut1&type=60682&s=1&uniqueId=" + order.OTCSalesOrderId + "&orderAmount=" + order.OrderCost);
                   
                    HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
                    Response.Write("hit processesor o.k. <br>");
                    /*
                    webreq = (HttpWebRequest)WebRequest.Create("http://www.betterwomannow.com/Interceuticals/Common/Marketing/BetterWoman.aspx?OID=" + order.OTCSalesOrderId);
                    webresp = (HttpWebResponse)webreq.GetResponse();
                    webreq = (HttpWebRequest)WebRequest.Create("http://www.bettermannow.com/Interceuticals/Common/Marketing/BetterMan.aspx?OID=" + order.OTCSalesOrderId);
                    webresp = (HttpWebResponse)webreq.GetResponse();
                    Response.Write("mailsent o.k. <br>"); */
                }
                catch (Exception ex)
                {

                    if (mail == null)
                        mail = new EmailSender();

                    subject = "ERROR: Order Confirmation - Interceuticals Order " + order.OTCSalesOrderId;
                    mailBody = ex.Message;
                    notifyEmails = "chris@olympictcs.com";

                    mail.AddEmailAddresses(notifyEmails);
                    mail.SendEmail(subject, mailBody);

                }
            }
            else
                setAbandoned(tran.OTCSiteMemberId);
		}

        private void setAbandoned(int memberID)
        {
            try
            {
                Log.InfoFormat("Setting order to abandoned from memberID {0}", memberID.ToString());
                string sql = "UPDATE OTCSiteMember SET AbandonedDate = "
                + OTCDatabase.SqlFormat(System.DateTime.Now.ToString())
                + " WHERE OTCSiteMemberId = " + memberID
                ;

                m_db.Open();
                m_db.SendSQLUpdate(sql);
            }
            catch (Exception e)
            {

                Log.Error("Unable to set order to abandoned.", e);
            }
            finally
            {
                if(m_db != null)
                    m_db.ReleaseConnection();

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
