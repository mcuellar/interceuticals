using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using OTC;
using OTC.Database;
using OTC.Web;
using OTC.Web.Marketing;
using OTC.Web.SalesOrder;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using Interceuticals.Common.Classes;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Interceuticals.Common.Util;

namespace Interceuticals.Order
{
    public class PreCheckOut : System.Web.UI.Page
    {
        public ITCPage m_page;
        private char CR = (char)10;
        public ITCCrossSellingProducts m_crosspage;
        private string crossSellProducts = "";
        private int m_shoppingCartId = 0;
        private int m_productID = -1;
        private string m_site = "";
        private string m_removeId;
        private string m_googleTrackingCode;
        private string thread = "";
        private string promotionKey = "";

        private string _xpathXSellProducts = "//products[@site='";
        private string _xsellContent = "";
        private string _xsellMessage = "";

        private XMLReader _xmlReader = null;
        private string _xmlDocPath = "../Common/Config/XML/CrossSellProducts.xml";

        protected System.Web.UI.WebControls.LinkButton btnCheckout;


        public string GoogleTrackingCode 
        { 
          get {return (this.m_googleTrackingCode);} 
        }

        public string CurrentSite
        {
            get { return (this.m_site); }
        }

        public string CrossSellContent
        {
            get { return (this._xsellContent); }
        }

        public string CrossSellMessage
        {
            get { return (this._xsellMessage); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.m_page = new ITCPage();

            m_removeId = Request.QueryString.ToString().IndexOf("remove") > -1 ? Request.QueryString["remove"] : "0";
            thread = Request.QueryString.ToString().IndexOf("thread") > -1 ? Request.QueryString["thread"] : "";
            promotionKey = Request.QueryString.ToString().IndexOf("PRID") > -1 ? Request.QueryString["PRID"] : "";
            //this.m_shoppingCartId = Request.QueryString.ToString().IndexOf("SCID") > -1 ? Convert.ToInt32(Request.QueryString["SCID"]) : 0;
            this.m_shoppingCartId = Convert.ToInt32(Request.QueryString["SCID"]);

            m_productID = Convert.ToInt32(Request.QueryString["PID2"]);
            m_site = Request.QueryString["site"];

            initCrossSellContent();

            reloadShoppingCart();
             
        }

        private void reloadPage()
        {
            string key = "";

            if (Request.ServerVariables["HTTP_HOST"] == "localhost" || Request.ServerVariables["HTTP_HOST"] == "cjeycjey.homedns.org:9001" || Request.ServerVariables["HTTP_HOST"] == "olympic.homedns.org:9001" || Request.ServerVariables["HTTP_HOST"] == "localhost:2535" || Request.ServerVariables["HTTP_HOST"] == "68.14.68.91:40401")
                Response.Redirect("/interceuticals/order/PreCheckOut.aspx?" + Request.QueryString.ToString() + "&PID2=" + m_productID + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
            else if (AppLookup.ServerHttpHost == "interceuticals.serveronline.net")
                Response.Redirect("http://interceuticals.serveronline.net/interceuticals/order/Precheckout.aspx?" + Request.QueryString.ToString() + "&PID2=" + m_productID + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
            else
                Response.Redirect("https://www.interceuticals.com/interceuticals/order/PreCheckOut.aspx?" + Request.QueryString.ToString() + "&PID2=" + m_productID + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));

        }

        private void initCrossSellContent()
        {
            loadXMLDoc();
            _xsellContent = getCrossSellImageHtml();

        }
 
        private void loadXMLDoc()
        {
            string xmlFile = Server.MapPath(_xmlDocPath);
            
            try
            {
                 _xmlReader = new XMLReader(xmlFile);
            }
            catch (XmlException ex)
            {
                Response.Write("Error in loading XML File: " + xmlFile + "| ERROR: " + ex.Message);
            }

        }

        protected string getCrossSellImageHtml()
        {
            string htmlContent = "";

            string site = this.m_site == "bm" ? "bm" : "bw";
            
            _xpathXSellProducts += site + "']";
            
            XmlNode node = _xmlReader.GetSingleNode(_xpathXSellProducts);

            if (node.HasChildNodes)
            {
                _xsellMessage = getCrossSellMessage();     

                foreach (XmlNode child in node.SelectNodes("masterproduct"))
                {
                    string imgSrc = child.SelectSingleNode("image").Attributes["path"].Value.ToString(); ;
                    string linkTo = child.SelectSingleNode("image").InnerText;
                    string msg = child.SelectSingleNode("message").InnerText;

                    htmlContent += msg + "<br>";
                    htmlContent += "<a href='";
                    htmlContent += linkTo + "&" + Request.QueryString.ToString().Trim('&') + "'>";
                    htmlContent += "<img src='";
                    htmlContent += imgSrc + "'";
                    htmlContent += " border='0' style='margin-bottom:2px;'";
                    htmlContent += "></a><br><br><br><br>";
                    htmlContent += CR;
                }

                if (_xmlReader != null)
                    _xmlReader.Close();
            }

            return htmlContent;

        }

        private string getCrossSellMessage()
        {
            if (m_site == "bm")
                return "<h3><b>Do you know we also have BetterWoman for woman?</b></h3>";
            else
                return "<h3><b>Do you know we also have BetterMAN for men?</b></h3>";
           

        }

        private void reloadShoppingCart()
        {
            if (Convert.ToInt32(m_removeId) > 0)
            {
                OTCShoppingCartItem i = new OTCShoppingCartItem(Convert.ToInt32(m_removeId));
                OTCShoppingCart c = new OTCShoppingCart(this.m_shoppingCartId);
                c.RemoveCartItem(i);
                string newQueryString = "";
                foreach (string s in Request.QueryString.ToString().Split('&'))
                {
                    Response.Write(s + "<br>" + CR);
                    if (s != ("remove=" + m_removeId))
                    {
                        newQueryString += s + "&";
                    }
                }
                Response.Redirect("PreCheckout.aspx?" + newQueryString.Trim('&'));
            }

        }

        protected string getCrossSellImages()
        {

            crossSellProducts = m_crosspage.getCrossSellProducts();
            m_crosspage.Close();

            return crossSellProducts;
        }

        protected string getCrossSellProducts()
        {
            crossSellProducts = m_crosspage.getCrossSellProducts();
            m_crosspage.Close();

            return crossSellProducts;
        }

        protected string getSiteName()
        {
            String site = m_site == "bm" ? "BetterMAN" : "BetterWOMAN";
            return site;
        }

        
        private void AddContinueShoppingLink()
        {
            string site = m_site == "bm" ? "betterman" : "betterwoman";
            site = "/interceuticals/" + site + "/";

            Response.Write("<br><br><div align='center'>"
                + CR + "<a href='" + site + "content.aspx?CTF=otherproducts&a_menu=product&a_image=other&hide=W'>Continue Shopping</a>"
                + CR + "</div><br>" + CR);

        }

        public void buildStep1()
        {
            //Note: Using HTML5 in MasterPage.  Table attribute only supports border "" or 1.
            Response.Write("<div align=\"center\">"
                    + CR + "<table width=\"100%\" cellpadding=\"3\" cellspacing=\"2\" border=\"0\" class=\"tableWrapper\">"
                    + CR + " <tr>"
                    + CR + "  <td colspan=\"4\" align=\"left\" class=\"formHeader\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\"><tr><td><font face=\"arial\" size='4'><b>Your order info: </b></td><td align=\"right\"></td></tr></table></td>"
                    + CR + " </tr>"
                    + CR + " <tr>"
                    + CR + "  <td class=\"rowWrapper\" align=\"left\" width=\"50%\"><font class=\"productHeader\">Product</td>"
                //+ CR + "  <td class=\"rowWrapper\"><font class=\"tableFont\">Quantity</td>"
                    + CR + "  <td class=\"rowWrapper\" align=\"left\"><font class=\"productHeader\">Unit Price</td>"
                    + CR + "  <td class=\"rowWrapper\" align=\"left\"><font class=\"productHeader\">Total Price</td>"
                    + CR + "  <td>&nbsp;</td>"
                    + CR + " </tr><tr><td colspan='4'>&nbsp;</td><tr>" + CR
                    );

            OTCShoppingCart cart = new OTCShoppingCart(this.m_shoppingCartId);
            OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(cart.OTCPromotionId);

            if (cart.CartItems.Length == 0)
                this.btnCheckout.Enabled = false;

            if (cart.CartItems.Length == 0)
            {
                string baseUrl = "http://www.interceuticals.com/interceuticals/product/default.aspx";

                if (AppLookup.ServerHttpHost.IndexOf("localhost") > -1)
                    baseUrl = "/interceuticals/product/default.aspx";
 
                Response.Write("<br><br><div align=\"center\" class=\"tableFont\"><font color=\"red\">You have no items in your bag!</font><br><a href=\"" + baseUrl + (this.m_page.IsBetterWoman ? "?site=bw" : "") + "\"><font class=\"tableFont\">continue shopping</a></div><br><br>");
                Control form = this.Page.Controls[0];
                foreach (Control c in form.Controls)
                {
                    if (c.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                    {
                        System.Web.UI.WebControls.TextBox ctrl = (System.Web.UI.WebControls.TextBox)c;
                        ctrl.Enabled = false;
                    }
                }
            }


            if (cart.CartItems.Length > 0)
            {
                foreach (OTCShoppingCartItem item in cart.CartItems)
                {
                    string memberShipString = "";
                    OTCProduct prod = new OTCProduct(item.ProductID);
                    if (item.ProductPrice * item.ItemCount != item.OrderPrice * item.ItemCount)
                    {
                        Response.Write("<tr><td>" + p.PromotionName + " " + p.PromotionDescription + "</td></tr>");
                        Response.Write(" <tr>"
                                + CR + "  <td align=\"left\" class=\"productInfo\">" + prod.ProductName + " " + memberShipString + "</td>"
                            //+ CR + "  <td class=\"productInfo\">" + item.ItemCount + "</td>"
                                + CR + "  <td align=\"left\" class=\"productInfoStrikeThrough\">" + item.ProductPrice.ToString("c") + "</td>"
                                + CR + "  <td align=\"left\" class=\"productInfo\">" + (item.OrderPrice * item.ItemCount).ToString("c") + "</td>"
                                + CR + "  <td>[ <a href=\"PreCheckOut.aspx?" + Request.QueryString.ToString() + "&remove=" + item.ShoppingCartItemID + "\">remove</a> ]</td>"
                                + CR + " </tr>" + CR
                                );
                    }
                    else
                    {
                        Response.Write(" <tr>"
                                + CR + "  <td align=\"left\" class=\"productInfo\">" + prod.ProductName + " " + memberShipString + "</td>"
                            //+ CR + "  <td class=\"productInfo\">" + item.ItemCount + "</td>"
                                + CR + "  <td align=\"left\" class=\"productInfo\">" + item.ProductPrice.ToString("c") + "</td>"
                                + CR + "  <td align=\"left\" class=\"productInfo\">" + (item.ProductPrice * item.ItemCount).ToString("c") + "</td>"
                                + CR + "  <td>[ <a href=\"PreCheckOut.aspx?" + Request.QueryString.ToString() + "&remove=" + item.ShoppingCartItemID + "\">remove</a> ]</td>"
                                + CR + " </tr>" + CR
                                );
                    }
                    try
                    {
                        if (prod.CategoryId == 21)
                            this.m_googleTrackingCode = "UA-1185020-2";
                        else
                            this.m_googleTrackingCode = "UA-1185020-1";
                    }
                    catch (Exception ex) { }
                }


            }

            Response.Write("<tr><td colspan='4'>&nbsp;</td><tr></table>"
                    + CR + "</div>" + CR
                    );

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx?" + Request.QueryString.ToString());

        }
    }
}
