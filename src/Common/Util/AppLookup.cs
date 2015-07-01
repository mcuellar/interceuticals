using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace Interceuticals.Common.Util
{
    public static class AppLookup
    {
        private static HttpServerUtility server = HttpContext.Current.Server;
        private static HttpRequest request = HttpContext.Current.Request;
        private static String recipientEmails = ConfigurationManager.AppSettings["orderConfirmRecipients"].ToString();
        private static String recipientsAlerts = ConfigurationManager.AppSettings["alertsRecipients"].ToString();
        private static String recipientsContactUs = ConfigurationManager.AppSettings["contactUsRecipients"].ToString();
        private static String connString = ConfigurationManager.AppSettings["connection"].ToString();
        private static String emailRemoteHost = ConfigurationManager.AppSettings["emailRemoteHost"].ToString();

        public static String GetServerName
        {
            get { return server.ToString(); }   
        }

        public static String ServerHttpHost
        {
            get { return request.ServerVariables["HTTP_HOST"]; }
        }

        public static String RecipientsAlerts
        {
            get { return recipientsAlerts; }
        }

        public static String RecipientsOrders
        {
            get { return recipientEmails; }
        }

        public static String RecipientsContactUs
        {
            get { return recipientsContactUs; }
        }

        public static String ConnString
        {
            get { return connString; }
        }

        public static String EmailRemoteHost
        {
            get { return emailRemoteHost; }
        }
    }
}