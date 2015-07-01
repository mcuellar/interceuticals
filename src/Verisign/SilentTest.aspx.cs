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

namespace Interceuticals.Verisign
{
    public class SilentTest : System.Web.UI.Page
    {
        private OTCDatabase m_db = new OTCDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList products = new ArrayList();
            int otcSiteMemberId = Convert.ToInt32(Request.Form["user1"]);
            int otcSalesOrderId = Convert.ToInt32(Request.Form["user2"]);
            int result = 0;
            string authCode = "111111";
            string responseMessage = "Denied";
            string avsData = "YYY";
            string pnrRef = "VPCE3F1D15B1";
            //string cardNumber       = Request.Form["CARDNUM"];

            OTCVerisignTransaction tran = new OTCVerisignTransaction();
            OTCSalesOrder order = new OTCSalesOrder(otcSalesOrderId);

            tran.AuthCode = authCode.ToString();
            tran.OTCSalesOrderId = otcSalesOrderId;
            tran.OTCSiteMemberId = otcSiteMemberId;
            tran.AVSData = avsData;
            tran.Cost = order.TotalCost;
            tran.PNRRef = pnrRef;
            tran.ResponseMessage = responseMessage;
            tran.Result = result;
            tran.Add();

            if (responseMessage.ToLower() == "approved")
            {
                string mailBody = OTCSalesOrder.GetEmailProductString(order.OTCSalesOrderId);

                EmailSender mail = new EmailSender();

                String subject = "Order Confirmation - Interceuticals Order " + order.OTCSalesOrderId;
                String notifyEmails = "m.cuellar@cox.net";

                mail.AddEmailAddresses(notifyEmails);
                String error = mail.SendEmail(subject, mailBody);

                if (error == "")
                    Response.Write("Successfully sent email.<br>");
                else
                    Response.Write("Error in sending email.  " + error);

                OTC.Web.Promotion.OTCPromotion pr = new OTC.Web.Promotion.OTCPromotion(order.OTCPromotionId);
                pr.AddPromotionUsage(order.OTCSiteMemberId, order.OTCSalesOrderId);

                try
                {
                    //HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create("https://loc1.hitsprocessor.com/confirmation.asp?acct=interceut1&type=60682&s=1&uniqueId=" + order.OTCSalesOrderId + "&orderAmount=" + order.OrderCost);
                    //HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
                    //Response.Write("hit processesor o.k. <br>");
                    HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create("http://localhost:2535/Interceuticals/Common/Marketing/BetterWoman.aspx?OID=" + order.OTCSalesOrderId);
                    HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
                    webreq = (HttpWebRequest)WebRequest.Create("http://localhost:2535/Interceuticals/Common/Marketing/BetterMan.aspx?OID=" + order.OTCSalesOrderId);
                    webresp = (HttpWebResponse)webreq.GetResponse();
                    Response.Write("Web Requeste check ok. <br>");
                }
                catch (Exception ex)
                {
                    if (mail == null)
                        mail = new EmailSender();

                    subject = "ERROR: Order Confirmation - Interceuticals Order " + order.OTCSalesOrderId;
                    mailBody = ex.Message;
                    notifyEmails = "m.cuellar@cox.net";

                    mail.AddEmailAddresses(notifyEmails);
                    mail.SendEmail(subject, mailBody);

                }
            }
            else
                setAbandoned(tran.OTCSiteMemberId);
        }

        private void setAbandoned(int memberID)
        {
            string sql = "UPDATE OTCSiteMember SET AbandonedDate = "
                        + OTCDatabase.SqlFormat(System.DateTime.Now.ToString())
                        + " WHERE OTCSiteMemberId = " + memberID
                        ;

            m_db.Open();
            m_db.SendSQLUpdate(sql);
            m_db.ReleaseConnection();

        }
    }
}
