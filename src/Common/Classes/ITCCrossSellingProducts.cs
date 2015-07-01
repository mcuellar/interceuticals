using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using OTC.Database;
using System.Text;


namespace Interceuticals.Common.Classes
{
    public class ITCCrossSellingProducts
    {
        private Boolean isBW;
        private OTCDatabase m_db = null;
        private StringBuilder _sb = new StringBuilder();
        private int siteID;
        private string _tableWidth = "0";
        private CellBackColorTypes _headerBackColor;
        private string _headerAlign = "";
        private string _headerFontColor = "black";
        

        public string TableWidth
        {
            set { this._tableWidth = value; }
            get { return (this._tableWidth); }
        }

        public CellBackColorTypes HeaderBackColor
        {
            set { this._headerBackColor = value; }
            get { return (this._headerBackColor); }

        }

        public string HeaderAlign
        {
            set { this._headerAlign = value; }
        }

        public string HeaderFontColor
        {
            set { this._headerFontColor = value; }
        }

        public ITCCrossSellingProducts(Boolean isBetterWoman)
        {
            isBW = isBetterWoman;

            siteID = isBW == false ? 21 : 22;

            try
            {
                m_db = new OTCDatabase();
                m_db.ConnectionString = Convert.ToString(ConfigurationManager.AppSettings["connection"]);
                m_db.Open();

                //buildProductTable();
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }

        }

        public void Close()
        {
            if (m_db != null)
                m_db.ReleaseConnection();
        }

        public void buildProductTable()
        {
            int count = 1;

            String sql = "SELECT ProductID, ProductName, ProdLink, ProductURL, OfferType, Benefits, Usage, ProductDescription, Price, Image, sku ";
            sql += "FROM vwGetCrossSellProducts ";
            sql += "WHERE Site = ";
            sql += Convert.ToString(siteID);

            addOpenTable();
            addHeaderRow();

            using (DataTable dt = m_db.GetDataset(sql).Tables[0])
            {
                int rowCount = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    addRow();

                    string prodID = Convert.ToString(dr["ProductID"]);
                    string productURL = Convert.ToString(dr["ProductURL"]);
                    string productLink = String.IsNullOrEmpty(Convert.ToString(dr["ProdLink"])) == true ? "" : Convert.ToString(dr["ProdLink"]);
                    string productName = "<a href='" + productURL + "' target='top'>" + productLink + "</a>";
                    string productDesc = Convert.ToString(dr["Benefits"]);
                    string productPrice = Convert.ToString(dr["Price"]);
                    string image = Convert.ToString(dr["Image"]);
                    string usage = String.IsNullOrEmpty(Convert.ToString(dr["Usage"])) == true ? "" : Convert.ToString(dr["Usage"]);
                    string offerType = String.IsNullOrEmpty(Convert.ToString(dr["OfferType"])) == true ? "" : Convert.ToString(dr["OfferType"]);

                    productPrice += "&nbsp;&nbsp;<input type='checkbox' id='chkOtherProducts' name='chkOtherProducts' value='";
                    productPrice += prodID + "'";
                    productPrice += ">";
                    
                    if (count%2 == 0)
                    {
                        addEmptyCell();
                        addEmptyCell();
                        addEmptyCell();
                    }
                    else
                    {
                        productName += "<br><img src='../Images/";
                        productName += image;
                        productName += "'/>";

                        addCenterJustifiedCell("<br>" + productName);
                        addCell("<p>" + productDesc + "</p>","center");
                        addCell(usage, "center");
                    }

                    addRightJustifiedCell(offerType + "-" + "$" + productPrice);
                    closeRow();

                    count++;
                }
            }

            addCloseTable();
        }

        private void addHeaderRow()
        {
            if (_headerAlign != "")
                _sb.Append("\t\t\t<tr align='" + _headerAlign + "' style='background-color:" + _headerBackColor + "'>");
            else
                _sb.Append("\t\t\t<tr  style='background-color:" + _headerBackColor + "'>");

            addCell("<font color='" + _headerFontColor + "'><b>Product Name</b></font>", "");
            addCell("<font color='" + _headerFontColor + "'><b>Main Benefits</b></font>", "");
            addCell("<font color='" + _headerFontColor + "'><b>Usage and Package</b></font>", "");
            addCell("<font color='" + _headerFontColor + "'><b>Add to my Cart</b></font>","","120");
            closeRow();
        }

        private void addEmptyCell()
        {
            _sb.Append("<td>&nbsp;</td>");

        }

        private void addOpenTable()
        {
            if (_tableWidth != "0")
            {
                _sb.Append("<table cellpadding='1' cellspacing='0' border='0' width='");
                _sb.Append(_tableWidth);
                _sb.Append("'");
                _sb.Append("style='border-right: #999999 1px solid;");
                _sb.Append(" border-left: #999999 1px solid;");
                _sb.Append(" border-top: #999999 1px solid;");
                _sb.Append(" border-bottom: #999999 1px solid'");
                _sb.Append(">\r\n");
            }
            else
            {
                _sb.Append("<table cellpadding='1' cellspacing='0' border='0'");
                _sb.Append("'");
                _sb.Append("style='border-right: #999999 1px solid;");
                _sb.Append(" border-left: #999999 1px solid;");
                _sb.Append(" border-top: #999999 1px solid;");
                _sb.Append(" border-bottom: #999999 1px solid'");
                _sb.Append(">\r\n");
            }
        }

        private void addCloseTable()
        {
            _sb.Append("\t\t\t</table>");
        }
        
        /*
         * Add new row with two tab escape characters
         */
        private void addRow()
        {
            _sb.Append("\t\t\t<tr>");
        }

        private void closeRow()
        {
            _sb.Append("</tr>\r\n");
        }

        private void addCell(string content, string valign)
        {
            if (valign != "")
            {
                _sb.Append("<td valign='" + valign + "'>");
                _sb.Append(content);
                _sb.Append("</td>");

            }
            else
            {
                _sb.Append("<td>");
                _sb.Append(content);
                _sb.Append("</td>");
            }
        }

        private void addRightJustifiedCell(string content)
        {
            _sb.Append("<td align='right'>");
            _sb.Append(content);
            _sb.Append("</td>");
        }

        private void addCenterJustifiedCell(string content)
        {
            _sb.Append("<td align='center'>");
            _sb.Append(content);
            _sb.Append("</td>");
        }

        private void addCell(string content, string valign, string cellWidth)
        {
            if (!String.IsNullOrEmpty(valign))
            {
                _sb.Append("<td width='" + cellWidth + "'");
                _sb.Append(" valign='" + valign + "'>");
                _sb.Append(content);
                _sb.Append("</td>");
            }
            else
            {
                _sb.Append("<td width='" + cellWidth + "'>");
                _sb.Append(content);
                _sb.Append("</td>");

            }

        }


        private void addCell(double content)
        {
            _sb.Append("<td>");
            _sb.Append(content.ToString());
            _sb.Append("</td>");
        }

        public string getCrossSellProducts()
        {
            if (_sb != null)
                return _sb.ToString();
            else
                return "Error Getting Other Products";
        }
    }
}
