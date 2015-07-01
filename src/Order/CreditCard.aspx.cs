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
	public class CreditCard : System.Web.UI.Page
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
		
		public int ProductQty				{get{return(this.m_productCount);}}
		public double ProductPrice			{get{return(this.m_productPrice);}}
		public OTCSalesOrder Order			{get{return(this.m_order);       }}
		public OTCSiteMember Member			{get{return(this.m_member);      }}
		public OTCCreditCard Card			{get{return(this.m_card);        }}
		public string Product				{get{return(this.m_product);     }}
		public string SiteString			{get{return(this.m_siteString);  }}
		public string SiteName				{get{return(this.m_siteName);    }}
		public string GoogleTrackingCode    {get{return(this.m_googleTrackingCode);}}


       	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string siteName = Request.QueryString.ToString().IndexOf("site") > - 1 ? Request.QueryString["site"] : "bm";
			OTCEncryption crypt = new OTCEncryption(7);
			int id = Convert.ToInt32(Request.QueryString["OID"]);
			this.m_order  = new OTCSalesOrder(id);
			this.m_member = new OTCSiteMember(this.m_order.OTCSiteMemberId);
			this.m_card   = new OTCCreditCard(this.m_order.OTCSalesOrderId,Session.SessionID);
			
			if(this.m_card.IISSessionId != Session.SessionID)
				Response.Redirect("/interceuticals/index.html");
				
			this.m_page   = new ITCPage();
			this.m_db.Open();
			this.m_dt	  = this.m_db.GetDataset("spGetOTCSalesOrderDetails_Verisign @OTCSalesOrderId = " + id).Tables[1];
				
			foreach(DataRow dr in this.m_dt.Rows)
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
			
			foreach(DataRow dr in dt.Rows)
			{
				int productId = Convert.ToInt32(dr["OTCProductId"]);
				OTCProduct p = new OTCProduct(productId);
				if(p.CategoryId == 21){	
					this.m_siteString += "UTM:T|" + Order.OTCSalesOrderId + "|" + this.SiteName + "|" + Order.TotalCost + "|" + Convert.ToDouble(ProductPrice * Order.SalesTax).ToString("c").Replace("$","") + "|" + Order.ShippingCost + "|" + Order.City + "|" + Order.State + "|" + Order.Country + "UTM:I|" + Order.OTCSalesOrderId + "|BM|BetterMan|Male|" + ProductPrice + "|" + ProductQty  + (char)10;//"|BM|BetterMan|Male|";
					//this.m_siteName   = "BetterManNow";
					//this.m_googleTrackingCode = "UA-1185020-2";
				} else {
					//this.m_siteString = "|BW|BetterWoman|Female|";
					this.m_siteString += "UTM:T|" + Order.OTCSalesOrderId + "|" + this.SiteName + "|" + Order.TotalCost + "|" + Convert.ToDouble(ProductPrice * Order.SalesTax).ToString("c").Replace("$","") + "|" + Order.ShippingCost + "|" + Order.City + "|" + Order.State + "|" + Order.Country + "UTM:I|" + Order.OTCSalesOrderId + "|BW|BetterWoman|Female|" + ProductPrice + "|" + ProductQty + (char)10;//"|BM|BetterMan|Male|";
					//this.m_siteName   = "BetterWomanNow";
					//this.m_googleTrackingCode = "UA-1185020-1";
				}
				m_productPrice = p.Price;
				Session["WantsMembership"] = true;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void WriteProductInformation()
		{
			double productCalculator = 0.0; //used for UI purposes only.
			DataTable dt = OTCSalesOrder.GetOrderItems(this.m_order.OTCSalesOrderId);
			Response.Write("<table width=\"100%\" class=\"tableWrapper\" border=\"0\" cellpadding=\"3\" cellspacing=\"0\">"
					+ CR + " <tr>"
					+ CR+  "  <td colspan=\"4\" class=\"formHeader\">Your Order Info</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td>Product Name</td>"
					+ CR + "  <td>&nbsp;</td>"
					+ CR + "  <td>Product Price</td>"
					+ CR + " </tr>"
					);
			
			foreach(DataRow dr in dt.Rows)
			{
				OTCProduct p = new OTCProduct((int)dr["OTCProductId"]);
				Response.Write(" <tr>"
						+ CR + "  <td>" + p.ProductName + "</td>"
						+ CR + "  <td class=\"" +(p.Price != Convert.ToDouble(dr["ItemPrice"]) ? "productInfoStrikeThrough" : "")+ "\">&nbsp;</td>"
						+ CR + "  <td>" + Convert.ToDouble(dr["ItemPrice"]).ToString("c") + "</td>"
						+ CR + " </tr>"
						);
				productCalculator += p.Price;
			}
			
			if(this.m_order.OTCPromotionId > 0)
			{
				Response.Write(" <tr height=\"5\"><td></td></tr>" + CR);
				OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(this.m_order.OTCPromotionId);
				if(!(p.HasProducts))
				{
					if(p.DiscountAmount > 0)
					{
						Response.Write(" <tr>"
								+ CR + "  <td>Special Promotion</td>"
								+ CR + "  <td></td>"
								+ CR + "  <td>(-" + p.DiscountAmount.ToString("c") + ")</td>" + CR
								+ CR + " </tr>" + CR
								);
					}
					else 
					{
						Response.Write(" <tr>"
								+ CR + "  <td>You're eligible for the following promotion -  " + p.PromotionName + " " + p.DiscountPercentage.ToString("p").Split('.')[0] + "% off.</td>"
								+ CR + "  <td></td>"
								+ CR + "  <td>(-" + (productCalculator * p.DiscountPercentage).ToString("c") + ")</td>" + CR
								+ CR + " </tr>" + CR
							);
					}
				}
				else 
				{
					Response.Write(" <tr>"
							+ CR + "  <td colspan=\"3\">You're eligible for the following promotion - " + p.PromotionName + ". Please see order price above.</td>"
							+ CR + " </tr>" + CR
							);
				}
					
				Response.Write(" <tr height=\"5\"><td></td></tr>" + CR);
				//Response.Write(" <tr><td>&nbsp;</td><td align=\"right\">Final Price:</td><td>" + this.m_order.OrderCost.ToString("c") + "</td></tr>");
			}
			
			Response.Write(" <tr>"
					+ CR + "  <td>&nbsp;</td>"
					+ CR + "  <td align=\"right\">S/H cost:</td>"
					+ CR + "  <td>" + this.m_order.ShippingCost.ToString("c") + "</td>"
					+ CR + " </tr>" + CR
					);
			
			//Response.Write(this.m_order.SalesTax);
				
			Response.Write(" <tr>"
					+ CR + "  <td>&nbsp;</td>"
					+ CR + "  <td align=\"right\">Sales Tax:</td>"
					+ CR + "  <td>" + (this.m_order.SalesTax * this.m_order.OrderCost).ToString("c") + "</td>"
					+ CR + " </tr>" + CR
					);

			Response.Write(" <tr>"
					+ CR + "  <td>&nbsp;</td>"
					+ CR + "  <td align=\"right\">Total Cost:</td>"
					+ CR + "  <td>" + this.m_order.TotalCost.ToString("c") + "</td>"
					+ CR + " </tr>" + CR
					);
				
			Response.Write("</table>");
			/*
			<table width="100%" border class="tableWrapper">
			<tr valign="top">
			<td width="15%">Total Cost: </td>
			<td><%=this.Product + " " + Order.TotalCost.ToString("c")%></td>
			</tr>
			<tr>
			<td width="15%">Shipping Cost: </td>
			<td><%=Order.ShippingCost.ToString("c")%></td>
			</tr>
			<%this.WritePromotionInformation();%>
			</table>
			*/
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void WritePromotionInformation()
		{
			if(this.m_order.OTCPromotionId > 0)
			{
				OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(this.m_order.OTCPromotionId);
				if(p.IsOrderBased)
				{
					
					Response.Write("<tr><td colspan=\"5\"><b>" + p.PromotionKey + " : " + p.PromotionName + "</td></tr>");
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
				
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
