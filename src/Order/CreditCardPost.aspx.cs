using System;
using System.IO;
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
using OTC;
using OTC.Database;
using OTC.Web;
using OTC.Web.Marketing;
using OTC.Web.SalesOrder;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using Interceuticals.Common.Classes;

namespace Interceuticals.Order
{
    public class CreditCardPost : System.Web.UI.Page
    {
        private char CR = (char)10;
        private OTCDatabase m_db = new OTCDatabase();
        protected System.Web.UI.WebControls.Button Button1;
        public ITCPage m_page;
        private string m_product;
        private string m_siteString;
        private string m_siteName; //used specifically for google analytics
        private string m_googleTrackingCode;
        private double m_productPrice;
        private int m_productCount = 1;
        private OTCSalesOrder m_order;
        private OTCSiteMember m_member;
        private OTCCreditCard m_card;
        private DataTable m_dt;
        

        private string m_orderMessage = "";
        private string m_currentSession = "";

        public int ProductQty { get { return (this.m_productCount); } }
        public double ProductPrice { get { return (this.m_productPrice); } }
        public OTCSalesOrder Order { get { return (this.m_order); } }
        public OTCSiteMember Member { get { return (this.m_member); } }
        public OTCCreditCard Card { get { return (this.m_card); } }
        public string Product { get { return (this.m_product); } }
        public string SiteString { get { return (this.m_siteString); } }
        public string SiteName { get { return (this.m_siteName); } }
        public string GoogleTrackingCode { get { return (this.m_googleTrackingCode); } }
        

        public string OrderMessage
        { 
            get { return (this.m_orderMessage);} 
        }

        public string CurrentSession
        {
            get { return (this.m_currentSession); }
        }

     
        protected void Page_Load(object sender, EventArgs e)
        {
            //Expire the page to avoid users from clicking the back button.
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");

            m_currentSession = Session["SessionID"] != null ? Session["SessionID"].ToString() : "";

            if (m_currentSession == "")
                m_orderMessage = "You're order has already been processed. <br>";
            else
                m_orderMessage = "Thank you - Please wait and do not click the back button, your order is processing...";

            string siteName = Request.QueryString.ToString().IndexOf("site") > -1 ? Request.QueryString["site"] : "bm";

            if (!Page.IsPostBack)
            {
                if (m_currentSession != "")
                {
                    OTCEncryption crypt = new OTCEncryption(7);
                    int id = Convert.ToInt32(Request.QueryString["OID"]);
                    this.m_order = new OTCSalesOrder(id);
                    this.m_member = new OTCSiteMember(this.m_order.OTCSiteMemberId);
                    this.m_card = new OTCCreditCard(this.m_order.OTCSalesOrderId, Session.SessionID);


                    if (this.m_card.IISSessionId != Session.SessionID)
                    {
                        if (Request.ServerVariables["HTTP_HOST"].IndexOf("localhost") > -1)
                            Response.Redirect("/interceuticals/default.aspx");
                        else
                            Response.Redirect("http://www.interceuticals.com");
                    }

                    this.m_page = new ITCPage();
                    this.m_db.Open();
                    this.m_dt = this.m_db.GetDataset("spGetOTCSalesOrderDetails_Verisign @OTCSalesOrderId = " + id).Tables[1];

                    foreach (DataRow dr in this.m_dt.Rows)
                    {
                        this.m_product += dr["ProductName"].ToString();
                    }

                    this.m_db.ReleaseConnection();

                    //hack to finish and get deployed.
                    string sql = "SELECT * FROM OTCSalesOrderDetail WHERE OTCSalesOrderId = " + this.m_order.OTCSalesOrderId;
                    OTCDatabase db = new OTCDatabase();
                    db.Open();
                    DataTable dt = db.GetDataset(sql).Tables[0];
                    db.ReleaseConnection();

                    //this.m_siteString = "|BM|BetterMan|Male|";
                    //UTM:T|<%=Order.OTCSalesOrderId%>|<%=this.SiteName%>|<%=Order.TotalCost%>|<%=Convert.ToDouble(ProductPrice * Order.SalesTax).ToString("c").Replace("$","")%>|<%=Order.ShippingCost%>|<%=Order.City%>|<%=Order.State%>|<%=Order.Country%> UTM:I|<%=Order.OTCSalesOrderId%><%=this.SiteString%><%=ProductPrice%>|<%=ProductQty%>
                    this.m_siteName = siteName == "bm" ? "BetterManNow" : "BetterWomanNow";
                    //this.m_googleTrackingCode	= this.m_page.AnalyticsTracking;

                    foreach (DataRow dr in dt.Rows)
                    {
                        int productId = Convert.ToInt32(dr["OTCProductId"]);
                        OTCProduct p = new OTCProduct(productId);
                        if (p.CategoryId == 21)
                        {
                            this.m_siteString += "UTM:T|" + Order.OTCSalesOrderId + "|" + this.SiteName + "|" + Order.TotalCost + "|" + Convert.ToDouble(ProductPrice * Order.SalesTax).ToString("c").Replace("$", "") + "|" + Order.ShippingCost + "|" + Order.City + "|" + Order.State + "|" + Order.Country + "UTM:I|" + Order.OTCSalesOrderId + "|BM|BetterMan|Male|" + ProductPrice + "|" + ProductQty + (char)10;//"|BM|BetterMan|Male|";
                            //this.m_siteName   = "BetterManNow";
                            //this.m_googleTrackingCode = "UA-1185020-2";
                        }
                        else
                        {
                            //this.m_siteString = "|BW|BetterWoman|Female|";
                            this.m_siteString += "UTM:T|" + Order.OTCSalesOrderId + "|" + this.SiteName + "|" + Order.TotalCost + "|" + Convert.ToDouble(ProductPrice * Order.SalesTax).ToString("c").Replace("$", "") + "|" + Order.ShippingCost + "|" + Order.City + "|" + Order.State + "|" + Order.Country + "UTM:I|" + Order.OTCSalesOrderId + "|BW|BetterWoman|Female|" + ProductPrice + "|" + ProductQty + (char)10;//"|BM|BetterMan|Male|";
                            //this.m_siteName   = "BetterWomanNow";
                            //this.m_googleTrackingCode = "UA-1185020-1";
                        }
                        m_productPrice = p.Price;
                        Session["WantsMembership"] = true;

                    }

                    //Do this to avoid duplicate order post to paypal.
                    Session.Clear();
                    Session.Abandon();

                }
                else
                    Response.Redirect("PostedMessage.aspx");

  

            }



        }
    }
}
