using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;


public partial class interceuticals_WebContent_iContact : System.Web.UI.Page
{

    public static string baseUrl = "https://app.icontact.com/icp/a/";
    public static string AppId = "MoKlTj4OV8nAQUGiodxz2AgIaVb2ZD3f";
    public static string Username = "betterwoman@interceuticals.com";
    public static string Password = "interceuticalsfreereport";
    public static string AccountId = "1370618";
    public static string ClientFolderId = "6049";


    public class Rootobject
    {
        public Contact[] contacts { get; set; }
    }

    public class Contact
    {
        public string contactId { get; set; }
        public string prefix { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string business { get; set; }
        public string email { get; set; }
        public string createDate { get; set; }
        public string bounceCount { get; set; }
        public string status { get; set; }
        public object besttimetocall { get; set; }
        public object bladdertest { get; set; }
        public object contactus { get; set; }
        public object dateentered { get; set; }
        public object freereport { get; set; }
        public object lastorder { get; set; }
        public object message { get; set; }
        public object numberofbotlles { get; set; }
        public object opened { get; set; }
        public object source { get; set; }
        public object testgroup { get; set; }
        public object win3 { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        string email = Request.Form["email"] ?? "";
        string firstname = Request.Form["fname"] ?? "";
        string lastname = Request.Form["lname"] ?? "";
        string prefix = Request.Form["prefix"] ?? "";
        string street = Request.Form["street"] ?? "";
        string city = Request.Form["city"] ?? "";
        string state = Request.Form["state"] ?? "";
        string zip = Request.Form["zip"] ?? "";
        string phone = Request.Form["phone"] ?? "";
        string source = Request.Form["source"] ?? "";
        string interest = Request.Form["interest"] ?? "";

        if (Request["fname"] != null)
        {
            Response.Write(Subscribe(email, firstname, lastname, prefix, street, city, state, zip, phone, source, interest).ToString());
        }

    }

    public string Subscribe(string email, string firstname, string lastname, string prefix, string street, string city, string state, string zip, string phone, string source, string interest)
    {
        bool success = false;

        string _output = "-1";
        try
        {
            Uri uri = new Uri(baseUrl + AccountId + "/c/" + ClientFolderId + "/contacts/");
            Contact2 c = new Contact2();
            c.email = email;
            c.status = "normal";
            c.firstName = firstname;
            c.lastName = lastname;
            c.prefix = prefix;
            c.state = state;
            c.street = street;
            c.postalCode = zip;
            c.phone = phone;
            c.city = city;
            c.source = source;

            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            string json = jsonSerializer.Serialize(c);

            json = "[" + json + "]";

            // Create a new request to the above mentioned URL.   

            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(uri);

            r.Method = "POST";
            r.Accept = "application/json";
            r.Headers.Add("Api-Version", "2.0");
            r.Headers.Add("Api-AppId", AppId);
            r.Headers.Add("Api-Username", Username);
            r.Headers.Add("Api-Password", Password);
            // r.Headers.Add("Accept", "application/json");
            r.ContentType = "application/json";

            string data = json;
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            r.ContentLength = dataStream.Length;
            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.

            Stream s = r.GetRequestStream();
            // Send the data.
            s.Write(dataStream, 0, dataStream.Length);
            s.Close();

            HttpWebResponse resp = (HttpWebResponse)r.GetResponse();
            System.IO.StreamReader sr = null;
            string sResponse = null;
            sResponse = "";
            sr = new StreamReader(resp.GetResponseStream());
            sResponse = sr.ReadToEnd();

            _output = sResponse;
            success = true;
        }
        catch
        {
            success = false;
        }

        string _parsed = "";
        Rootobject peoples = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Rootobject>(_output);


       List<string> mailList = new List<string>();

        if (interest == "BetterMan") {
		    mailList.Add("32692");	 // BetterMan Free Report
	    } else if (interest == "BetterWoman")
	    {
	        mailList.Add("32693"); // BetterWoman Free Report
	    }
	    else
	    {
	         mailList.Add("32692");	 // BetterMan Free Report
             mailList.Add("32693"); // BetterWoman Free Report
	    }




        foreach (var item in peoples.contacts)
        {
            _parsed = String.Format("Name: {0}, ID: {1}", item.firstName, item.contactId);

            foreach (string list in mailList)
            {
                AddToList(item.contactId, list, "normal");
            }
            
        }

        return _parsed;
    }



    public string AddToList(string contactId, string listId, string status)
    {
        bool success = false;

        string _output = "-1";
        try
        {
            Uri uri = new Uri(baseUrl + AccountId + "/c/" + ClientFolderId + "/subscriptions/");
            MailList ml = new MailList();
            ml.contactId = contactId;
            ml.listId = listId;
            ml.status = status;
           

            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            string json = jsonSerializer.Serialize(ml);

            json = "[" + json + "]";

            // Create a new request to the above mentioned URL.   

            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(uri);

            r.Method = "POST";
            r.Accept = "application/json";
            r.Headers.Add("Api-Version", "2.0");
            r.Headers.Add("Api-AppId", AppId);
            r.Headers.Add("Api-Username", Username);
            r.Headers.Add("Api-Password", Password);
            // r.Headers.Add("Accept", "application/json");
            r.ContentType = "application/json";

            string data = json;
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            r.ContentLength = dataStream.Length;
            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.

            Stream s = r.GetRequestStream();
            // Send the data.
            s.Write(dataStream, 0, dataStream.Length);
            s.Close();

            HttpWebResponse resp = (HttpWebResponse)r.GetResponse();
            System.IO.StreamReader sr = null;
            string sResponse = null;
            sResponse = "";
            sr = new StreamReader(resp.GetResponseStream());
            sResponse = sr.ReadToEnd();

            _output = sResponse;
            success = true;
        }
        catch
        {
            success = false;
        }

        return "true";
    }



    [Serializable]
    public class Contact2
    {
        #region "Private Fields"

        private string _email;
        private string _prefix;
        private string _firstName;
        private string _lastName;
        private string _suffix;
        private string _street;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _phone;
        private string _business;
        private string _status;
        private string _source;

        #endregion

        #region "Public Properties"

        public string source
        {
            get { return (_source ?? string.Empty); }
            set { _source = (value != null ? value.Trim() : value); }
        }

        public string email
        {
            get { return (_email ?? string.Empty); }
            set { _email = (value != null ? value.Trim() : value); }
        }
        public string prefix
        {
            get { return (_prefix ?? string.Empty); }
            set { _prefix = (value != null ? value.Trim() : value); }
        }
        public string firstName
        {
            get { return (_firstName ?? string.Empty); }
            set { _firstName = (value != null ? value.Trim() : value); }
        }
        public string lastName
        {
            get { return (_lastName ?? string.Empty); }
            set { _lastName = (value != null ? value.Trim() : value); }
        }
        public string suffix
        {
            get { return (_suffix ?? string.Empty); }
            set { _suffix = (value != null ? value.Trim() : value); }
        }
        public string street
        {
            get { return (_street ?? string.Empty); }
            set { _street = (value != null ? value.Trim() : value); }
        }
        public string city
        {
            get { return (_city ?? string.Empty); }
            set { _city = (value != null ? value.Trim() : value); }
        }

        public string state
        {
            get { return (_state ?? string.Empty); }
            set { _state = (value != null ? value.Trim() : value); }
        }
        public string postalCode
        {
            get { return (_postalCode ?? string.Empty); }
            set { _postalCode = (value != null ? value.Trim() : value); }
        }
        public string phone
        {
            get { return (_phone ?? string.Empty); }
            set { _phone = (value != null ? value.Trim() : value); }
        }
        public string business
        {
            get { return (_business ?? string.Empty); }
            set { _business = (value != null ? value.Trim() : value); }
        }
        public string status
        {
            get { return (_status ?? string.Empty); }
            set { _status = (value != null ? value.Trim() : value); }
        }

        #endregion
    }

    [Serializable]
    public class MailList
    {
        #region "Private Fields"

        private string _status;
        private string _listId;
        private string _contactId;
       

        #endregion

        #region "Public Fields"

        public string status
        {
            get { return (_status ?? string.Empty); }
            set { _status = (value != null ? value.Trim() : value); }
        }

        public string listId
        {
            get { return (_listId ?? string.Empty); }
            set { _listId = (value != null ? value.Trim() : value); }
        }
        public string contactId
        {
            get { return (_contactId ?? string.Empty); }
            set { _contactId = (value != null ? value.Trim() : value); }
        }


        #endregion

    }

}