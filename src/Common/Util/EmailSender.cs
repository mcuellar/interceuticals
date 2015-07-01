using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Interceuticals.Common.Util;

namespace Interceuticals.Common.Util
{
    public class EmailSender
    {
        MailMessage mail = new MailMessage();
        private string remoteHost = AppLookup.EmailRemoteHost;
        private string fromName = "Customer Service";
        private string fromAddress = "customerservice@interceuticals.com";

        public EmailSender()
        {
            mail.From = new MailAddress(fromAddress, fromName);
        }

        public EmailSender(String fromEmailAddress, String fromDisplayName)
        {
            fromAddress = fromEmailAddress;
            fromName = fromDisplayName;
            mail.From = new MailAddress(fromAddress, fromName);
        }

        public void AddEmailAddresses(String emailAddresses)
        {
            mail.To.Add(emailAddresses);
        }

        public void AddBccEmailAddresses(String emailAddresses)
        {
            mail.Bcc.Add(emailAddresses);
        }

        public String SendEmail(String emailSubject, String emailBody)
        {
            String result = "";

            try
            {
                mail.Subject = emailSubject;
                mail.Body = emailBody;
                SmtpClient smtp = new SmtpClient(remoteHost);
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                result = "Error in sending email: " + e.Message;
                return result;
            }
            finally
            {
                if (mail != null)
                    mail = null;
            }

            return result;
        }

        public String SendEmail(string _fromName, String emailSubject, String emailBody)
        {
            String result = "";

            try
            {
                fromName = _fromName;
                mail.Subject = emailSubject;
                mail.Body = emailBody;
                SmtpClient smtp = new SmtpClient(remoteHost);
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                result = "Error in sending email: " + e.Message;
                return result;
            }
            finally
            {
                if (mail != null)
                    mail = null;
            }

            return result;
        }

    }
}