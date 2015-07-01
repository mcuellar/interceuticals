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
using OTC.Database;
using OTC.Web.Product;
using OTC.Web.ShoppingCart;
using Interceuticals.Common.Classes;

namespace Interceuticals.Admin
{
	/// <summary>
	/// Summary description for PromotionTest.
	/// </summary>
	public class PromotionTest : System.Web.UI.Page
	{
		ITCPage m_page;
		OTCDatabase m_db = new OTCDatabase();
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstProducts;
		protected System.Web.UI.WebControls.DropDownList ddPromotions;
		protected System.Web.UI.WebControls.TextBox txtProductPrice;
		protected System.Web.UI.WebControls.TextBox txtPromotionPrice;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			if(!Page.IsPostBack)
			{
				string sql = "SELECT * FROM OTCPromotion";
				this.m_db.Open();
				DataTable dt = this.m_db.GetDataset(sql).Tables[0];
				foreach(DataRow dr in dt.Rows){
					ListItem i = new ListItem(dr["PromotionKey"].ToString(),dr["OTCPromotionId"].ToString());
					this.ddPromotions.Items.Add(i);
				}
				
				sql = "SELECT * FROM OTCProduct";
				dt = this.m_db.GetDataset(sql).Tables[0];
				foreach(DataRow dr in dt.Rows){
					ListItem i = new ListItem(dr["ProductName"].ToString() + " - " + Convert.ToDouble(dr["Price"]).ToString("c") ,dr["OTCProductId"].ToString());
					this.lstProducts.Items.Add(i);
				}
				this.m_db.ReleaseConnection();
				
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(Convert.ToInt32(this.ddPromotions.SelectedValue));
			OTCProduct pd  = new OTCProduct(Convert.ToInt32(this.lstProducts.SelectedValue));
			OTCShoppingCart c = new OTCShoppingCart(this.m_page.ShoppingCartId);
			OTCShoppingCartItem i = new OTCShoppingCartItem();
			i.ProductID = pd.ProductId;
			i.ProductPrice = pd.Price;
			i.ItemCount = 1;
			c.AddCartItem(i);
			c.ApplyPromotion(this.ddPromotions.SelectedItem.Text,c.ShoppingCartID);
			c = null;
			c = new OTCShoppingCart(this.m_page.ShoppingCartId);
			this.txtProductPrice.Text = c.CartTotal.ToString("c");
			Response.Write(this.m_page.ShoppingCartId);
			p.AddPromotionUsage(1,999999);
			
			/*
			OTCProduct pd  = new OTCProduct(Convert.ToInt32(this.lstProducts.SelectedValue));
			if(p.DiscountAmount > 0)
			{
				string displayPrice = Convert.ToDouble(pd.Price - p.DiscountAmount).ToString("c");
				this.txtProductPrice.Text = pd.Price.ToString("c");
				this.txtPromotionPrice.Text = displayPrice;
			}
			
			if(p.DiscountPercentage > 0)
			{
				string displayPrice = Convert.ToDouble(pd.Price - (pd.Price * p.DiscountPercentage)).ToString("c");
				this.txtProductPrice.Text = pd.Price.ToString("c");
				this.txtPromotionPrice.Text = displayPrice;
			}
			*/
		}
	}
}
