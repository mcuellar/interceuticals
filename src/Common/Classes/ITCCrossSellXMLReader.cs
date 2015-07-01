using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.XPath;

namespace Interceuticals.Common.Classes
{
    public class ITCCrossSellXMLReader
    {
        XMLReader _xmlReader = null;
        private char CR = (char)10;
        private string _xpathXSellProducts = "//products[@site='";
        string _siteName = "";
        string _htmlFile = "";
        private string _xmlDocPath = "../Common/Config/XML/CrossSellProducts.xml";

        HttpServerUtility Server = HttpContext.Current.Server;
        
        public ITCCrossSellXMLReader(string siteName, string htmlFile)
        {
            _siteName = siteName;
            _htmlFile = htmlFile;

            string xmlPath = Server.MapPath(_xmlDocPath);

            try
            {
                _xmlReader = new XMLReader(xmlPath);
            }
            catch (XmlException ex)
            {
                throw new Exception("Error in loading XML File: " + _xmlDocPath + "| ERROR: " + ex.Message);
            }

        }

        public string GetProductImage()
        {
            string xpath = _xpathXSellProducts;

            xpath += _siteName + "']";
            xpath += "/masterproduct[@htmlname='";
            xpath += _htmlFile;
            xpath += "']";

            XmlNode node = _xmlReader.GetSingleNode(xpath);

            string htmlContent = node.SelectSingleNode("imageTag").InnerText;

            return htmlContent;

        }

        public string GetProductContent()
        {
            string htmlContent = "";
            string xpath = _xpathXSellProducts;

            xpath += _siteName + "']";
            xpath += "/masterproduct[@htmlname='";
            xpath += _htmlFile;
            xpath += "']";

            XmlNode node = _xmlReader.GetSingleNode(xpath);

            foreach (XmlNode child in node.SelectNodes("product"))
            {
                string offer = child.SelectSingleNode("offer").InnerText;
                string productID = child.SelectSingleNode("productID").InnerText;

                htmlContent += "<input type='checkbox' id='chkProducts' name='chkProducts'";
                htmlContent += " value='";
                htmlContent += productID;
                htmlContent += "'>";
                htmlContent += offer + "<br>";
                htmlContent += CR;
                htmlContent += "\t\t";

            }

            return htmlContent;
        }

        public void Close()
        {
            if (_xmlReader != null)
                _xmlReader.Close();

        }
    }
}
