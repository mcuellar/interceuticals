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
using Interceuticals.Common.Classes;
using System.Xml;
using System.Xml.XPath;
using Interceuticals.Common.Util;

namespace Interceuticals.BetterMan
{
    public class ShoppingContent : System.Web.UI.Page
    {
        public ITCPageBetterMan m_page = new ITCPageBetterMan();
        private string _htmlFile = "";
        private string _producImage = "";
        private string _productContent = "";
        private char CR = (char)10;
        private int m_shoppingCartId = 0;

        private int m_productID = -1;
        private string m_site = "";
        private string m_removeId;
        private string m_googleTrackingCode;
        private string thread = "";
        private string promotionKey = "";


        public string HtmlFile
        {
            get { return (this._htmlFile); }
        }

        public string ProductImage
        {
            get { return (this._producImage); }
        }

        public string ProductContent
        {
            get { return (this._productContent); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            m_removeId = Request.QueryString.ToString().IndexOf("remove") > -1 ? Request.QueryString["remove"] : "0";
            thread = Request.QueryString.ToString().IndexOf("thread") > -1 ? Request.QueryString["thread"] : "";
            promotionKey = Request.QueryString.ToString().IndexOf("PRID") > -1 ? Request.QueryString["PRID"] : "";
            this.m_shoppingCartId = Request.QueryString.ToString().IndexOf("SCID") > -1 ? Convert.ToInt32(Request.QueryString["SCID"]) : 0;

            m_productID = Convert.ToInt32(Request.QueryString["PID2"]);
            m_site = Request.QueryString["site"];
            _htmlFile = Request.QueryString.ToString().IndexOf("CTF") > -1 ? Request.QueryString["CTF"] : "";
            this.m_page.Title = "BettermanNOW";

            initXSellContent();

        }

        public void RenderHtmlContent()
        {
            if (_htmlFile.Length > 0)
            {
                try
                {
                    Server.Execute(_htmlFile + ".html");
                }
                catch (HttpException ex)
                {
                    Response.Write("Error in getting html file: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("Error in getting html file: " + ex.Message);
                }

            }
        }

        private void initXSellContent()
        {
            ITCCrossSellXMLReader xsellReader = null;
            try
            {
                xsellReader = new ITCCrossSellXMLReader("bm", _htmlFile);
                _producImage = xsellReader.GetProductImage();
                _productContent = xsellReader.GetProductContent();
            }
            catch (XmlException ex)
            {
                Response.Write("Error in loading XMlContent: " + ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error in loading XMLContent: " + ex.Message);
            }
            finally
            {
                if (xsellReader != null)
                    xsellReader.Close();
            }

        }

        private void redirectPage()
        {

            if (Request.ServerVariables["HTTP_HOST"].IndexOf("localhost") > -1 || Request.ServerVariables["HTTP_HOST"] == "cjeycjey.homedns.org:9001" || Request.ServerVariables["HTTP_HOST"] == "olympic.homedns.org:9001" || Request.ServerVariables["HTTP_HOST"] == "68.14.68.91:40401" || Request.ServerVariables["HTTP_HOST"] == "qa.interceuticals.com")
                Response.Redirect("../order/PreCheckOut.aspx?" + getQueryString());
            else if (AppLookup.ServerHttpHost == "interceuticals.serveronline.net")
                Response.Redirect("http://interceuticals.serveronline.net/interceuticals/order/PreCheckOut.aspx?" + getQueryString());
            else
                Response.Redirect("https://www.interceuticals.com/interceuticals/order/PreCheckOut.aspx?" + getQueryString());

        }

        private string getQueryString()
        {

            string qryString = "";

            foreach (string s in Request.QueryString.ToString().Split('&'))
            {
                if ((s != ("CTF=" + _htmlFile)) && (s != ("hide=W")))
                {
                    qryString += s + "&";
                }
            }

            return qryString.Trim('&');
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            ITCShoppingCartManager shoppingMgr = null;
            char[] splitter = { ',' };

            String[] prodList = Request.Form["chkProducts"].Split(splitter);

            if (prodList.Length > 0)
            {
                try
                {
                    string cartID = Session.SessionID;
                    shoppingMgr = new ITCShoppingCartManager(this.m_shoppingCartId);
                    shoppingMgr.addToShoppingCart(prodList);

                    redirectPage();
                }
                catch (Exception ex)
                {
                    Response.Write("Error in processing Order: " + ex.Message);
                }
                finally
                {
                    //prodList.Clear();
                    prodList = null;

                    if (shoppingMgr != null)
                    {
                        shoppingMgr.Close();
                        shoppingMgr = null;
                    }

                }
            }
        }

    }
}
