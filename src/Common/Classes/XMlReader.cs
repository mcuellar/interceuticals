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
    public class XMLReader
    {
        private XmlDocument _xmlDoc = null;
        private string _xmlPath = "";


        public XMLReader(string xmlFilePath)
        {
            try
            {
                if (_xmlDoc == null)
                {
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(xmlFilePath);
                    _xmlPath = xmlFilePath;
                }
            }
            catch (XmlException ex)
            {
                throw new XmlException(ex.Message);
            }

        }

        public void Close()
        {
            if (_xmlDoc != null)
                _xmlDoc = null;

        }

        public XmlNode GetSingleNode(string xPathNode)
        {
            XmlNode node = null;
            try
            {
                node = _xmlDoc.SelectSingleNode(xPathNode);
            }
            catch (XPathException ex)
            {
                throw new XPathException(ex.Message);
            }

            return node;
        }


        private XmlNodeList getNodelist(String xPathExpression)
        {
            XmlNodeList nodes = null;

            try
            {
                nodes = _xmlDoc.SelectNodes(xPathExpression);
            }
            catch (XPathException e)
            {
                throw new XPathException(e.Message);
            }

            return nodes;

        }

    }
}
