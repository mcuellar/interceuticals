using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Interceuticals.Common.Util;
using OTC;
using OTC.Database;
using OTC.Web;
using OTC.Web.Marketing;
using OTC.Web.SalesOrder;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using Interceuticals.Common.Classes;
using Interceuticals.Cache;

namespace Interceuticals.Order
{
	public class AbandonmentInterval : System.Web.UI.Page
	{
        private OTCDatabase m_db = new OTCDatabase();
        

        private void Page_Load(object sender, System.EventArgs e)
        {
            string sql = "";
			this.m_db.Open();
		
         
            sql = "EXEC spGetAbandonedCartsAtInterval";
            DataTable dt = this.m_db.GetDataset(sql).Tables[0];
            this.m_db.ReleaseConnection();

            var sb = new StringBuilder();
            foreach (DataRow dr in dt.Select())
            {
                sb.Append("Abandon Cart Entry" + System.Environment.NewLine);
                sb.Append("========================================" + System.Environment.NewLine);
                foreach (DataColumn dc in dt.Columns)
                {
                    string columnData = "";
                    switch (dc.DataType.Name)
                    {
                        case "DateTime":
                            columnData = Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString() != "1/1/1900"
                                             ? Convert.ToDateTime(dr[dc.ColumnName]).ToShortDateString()
                                             : "NEVER";
                            break;
                        case "String":
                            columnData = dr[dc.ColumnName].ToString();
                            break;
                        default:
                            columnData = dr[dc.ColumnName].ToString();
                            break;
                    }

                    sb.Append(dc.ColumnName + ": " + columnData + System.Environment.NewLine);


                }
                sb.Append("========================================" + System.Environment.NewLine +
                          System.Environment.NewLine);
            }

            var body = sb.ToString();

            if (!String.IsNullOrEmpty(body))
            {
                var emailSender = new EmailSender();
                emailSender.AddEmailAddresses("customerservice@interceuticals.com");
                emailSender.SendEmail("Abandon Cart Alert", body);
            }

 
        }

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            
            this.Load += new System.EventHandler(this.Page_Load);

        }
       
	}
}
