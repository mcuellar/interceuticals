using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Interceuticals.Common.Classes;
using OTC.Database;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using Interceuticals.Common.Util;

namespace Interceuticals.Product
{
	/// <summary>
	/// Summary description for SetCart.
	/// </summary>
	public class SetCart : System.Web.UI.Page
	{
		public ITCPage m_page;
		private OTCDatabase m_db = new OTCDatabase();
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.m_page = new ITCPage();
				OTCShoppingCart cart = new OTCShoppingCart(Session.SessionID);
				Session["wantsMembership"] = Convert.ToBoolean(Request.QueryString["wantsMembership"]);
				int productId = getCorrectProductId(Convert.ToInt32(Request.QueryString["PID"]));
				bool addedItems = false;
				string f = Request.Form.ToString();
				cart = new OTCShoppingCart(this.m_page.ShoppingCartId);
				//cart.RemoveAllItems(this.m_page.ShoppingCartId); 
				OTCShoppingCartItem item = new OTCShoppingCartItem();
				OTCProduct product = new OTCProduct(Convert.ToInt32(productId));
				item.ProductID = Convert.ToInt32(productId);
				item.ProductPrice = product.Price;
				item.ItemCount = 1;
				cart.AddCartItem(item);
				string key = "";

                string host = Request.ServerVariables["HTTP_HOST"];

                if (AppLookup.ServerHttpHost.IndexOf("localhost") > -1 || Request.ServerVariables["HTTP_HOST"] == "cjeycjey.homedns.org:9001" || Request.ServerVariables["HTTP_HOST"] == "68.14.68.91:40401")
					Response.Redirect("/interceuticals/order/precheckout.aspx?" + Request.QueryString.ToString() + "&PID2=" + productId + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
                else if (AppLookup.ServerHttpHost == "interceuticals.serveronline.net")
                    Response.Redirect("http://interceuticals.serveronline.net/interceuticals/order/precheckOut.aspx?" + Request.QueryString.ToString() + "&PID2=" + productId + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
                else
                    Response.Redirect("https://www.interceuticals.com/interceuticals/order/precheckout.aspx?" + Request.QueryString.ToString() + "&PID2=" + productId + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
			}
			catch(System.Web.HttpUnhandledException ex)
			{
				string mailBody = Request.QueryString.ToString();

                EmailSender mail = new EmailSender();

                String subject = "Site Error : " + Request.QueryString["PID"];
                String notifyEmails = AppLookup.RecipientsAlerts;

                mail.AddEmailAddresses(notifyEmails);
                mail.SendEmail(subject, mailBody + (char)10 + ex.Message);

				Response.Write("There was an error in our process. We apologize for the inconvenience. We have notified the web master and the problem will be addressed shortly.");
			}
		}
		
		
		private int getCorrectProductId(int productId)
		{
			if(!Convert.ToBoolean(Session["wantsMembership"]))
				return (productId);
			else
			{
				string sql = "SELECT * FROM  OTCProductRelationship WHERE OTCParentProductId = " + productId;
				this.m_db.Open();
				DataTable dt = this.m_db.GetDataset(sql).Tables[0];
				this.m_db.ReleaseConnection();
				if(!(dt.Rows.Count > 0))
					return (productId);
				else 
				{
					productId = Convert.ToInt32(dt.Rows[0]["OTCSubordinateProductID"]);
					return(productId);
				}
			}
		}
		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
