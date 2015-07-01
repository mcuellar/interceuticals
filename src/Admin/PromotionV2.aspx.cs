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
using OTC.Web;
using OTC.Web.Controls;
using OTC.Database;
using OTC.Web.Product;
using OTC.Web.Promotion;

namespace Interceuticals.Admin
{
	public class PromotionV2 : System.Web.UI.Page
	{
		private int m_promotionId;
		public ITCPage m_page;
		protected System.Web.UI.WebControls.TextBox txtPromotionName;
		protected System.Web.UI.WebControls.TextBox txtPromotionKey;
		protected System.Web.UI.WebControls.TextBox txtNumberOfUses;
		protected System.Web.UI.WebControls.TextBox txtMinimumPurchaseAmount;
		protected System.Web.UI.WebControls.CheckBox chkDiscountPercentage;
		protected System.Web.UI.WebControls.TextBox txtDiscountPercentage;
		protected System.Web.UI.WebControls.CheckBox chkDiscountAmount;
		protected System.Web.UI.WebControls.TextBox txtDiscountAmount;
		protected System.Web.UI.WebControls.CheckBox chkActivateImmedietly;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtPromotionDescription;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Calendar cldStartDate;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Calendar cldEndDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.ListBox lstProducts;
		private OTCDatabase m_db = new OTCDatabase();
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPromotionId;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		private OTC.Web.Promotion.OTCPromotion m_promotion;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			
			if(!(this.m_page.CheckLogin()))
				Response.Redirect("Login.aspx");
			
			this.m_page.HideWest = true;
			this.m_promotionId = Request.QueryString.ToString().IndexOf("PID") > - 1 ? Convert.ToInt32(Request.QueryString["PID"]) : 0;
			this.m_promotion   = new OTC.Web.Promotion.OTCPromotion(this.m_promotionId);
			if(!Page.IsPostBack)
			{
				if(!(this.m_promotionId > 0))
				{
					this.cldStartDate.SelectedDate = this.cldStartDate.VisibleDate = System.DateTime.Now;
					this.cldEndDate.SelectedDate = this.cldEndDate.VisibleDate = System.DateTime.Now;
					this.txtStartDate.Text = this.cldStartDate.SelectedDate.ToShortDateString();
					this.txtEndDate.Text = this.cldEndDate.SelectedDate.ToShortDateString();
					this.loadProductList();
				}
				else
				{
					OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(this.m_promotionId);
					this.txtPromotionId.Value = p.OTCPromotionId.ToString();
					this.txtStartDate.Text = p.StartDate.ToShortDateString();
					this.cldStartDate.SelectedDate = this.cldStartDate.VisibleDate = p.StartDate;
					this.txtPromotionName.Text = p.PromotionName;
					this.txtPromotionKey.Text = p.PromotionKey;
					this.txtPromotionDescription.Value = p.PromotionDescription;
					this.txtMinimumPurchaseAmount.Text = p.MinimumPurchaseAmount.ToString();
					this.txtEndDate.Text = p.EndDate == Convert.ToDateTime("1/1/1900") ? "" : p.EndDate.ToShortDateString();
					this.cldEndDate.SelectedDate = this.cldEndDate.VisibleDate = (p.EndDate == Convert.ToDateTime("1/1/1900") ? System.DateTime.Now : p.EndDate);
					this.txtNumberOfUses.Text = p.UsageCount.ToString();
					this.txtDiscountPercentage.Text = (p.DiscountPercentage * 100).ToString();
					this.txtDiscountPercentage.Enabled = p.DiscountPercentage > 0 ? true : false;
					this.chkActivateImmedietly.Checked = p.IsActive;
					this.chkDiscountAmount.Checked = p.DiscountAmount > 0;
					this.txtDiscountAmount.Text = Convert.ToDouble(p.DiscountAmount).ToString("c").Replace("$","");
					this.txtDiscountAmount.Enabled = p.DiscountAmount > 0 ? true : false;
					this.chkDiscountPercentage.Checked = p.DiscountPercentage > 0;
					this.loadProductList(true);
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void loadProductList()
		{
			string sql = "SELECT * FROM OTCProduct";
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset(sql).Tables[0];
			this.m_db.ReleaseConnection();
			ListItem defaultItem = new ListItem("All Sku's",0.ToString());
			defaultItem.Selected = true;
			this.lstProducts.Items.Add(defaultItem);
			foreach(DataRow dr in dt.Rows)
			{
				ListItem i = new ListItem(dr["sku"].ToString() + " : " + dr["ProductName"].ToString(),dr["OTCProductId"].ToString());
				this.lstProducts.Items.Add(i);
			}
		}
		private void loadProductList(object o)
		{
			string sql = "SELECT * FROM OTCProduct";
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset(sql).Tables[0];
			this.m_db.ReleaseConnection();
			ListItem defaultItem = new ListItem("All Sku's",0.ToString());
			
			if(!(this.m_promotion.HasProducts))
				defaultItem.Selected = true;
			
			this.lstProducts.Items.Add(defaultItem);
			
			foreach(DataRow dr in dt.Rows){
				ListItem i = new ListItem(dr["sku"].ToString() + " : " + dr["ProductName"].ToString(),dr["OTCProductId"].ToString());
				if(this.m_promotion.HasProductAffiliation((int)dr["OTCProductId"]))
					i.Selected = true;
				this.lstProducts.Items.Add(i);
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
			this.cldStartDate.SelectionChanged += new System.EventHandler(this.cldStartDate_SelectionChanged);
			this.cldEndDate.SelectionChanged += new System.EventHandler(this.cldEndDate_SelectionChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cldStartDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.txtStartDate.Text = this.cldStartDate.SelectedDate.ToShortDateString();
		}

		private void cldEndDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.txtEndDate.Text = this.cldEndDate.SelectedDate.ToShortDateString();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//try
			//{
				this.lblErrorMessage.Visible = false;
				OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion();
				p.OTCPromotionId = Convert.ToInt32(this.txtPromotionId.Value) > 0 ? Convert.ToInt32(this.txtPromotionId.Value)  : 0;
				p.PromotionName = this.txtPromotionName.Text;
				p.PromotionKey = this.txtPromotionKey.Text;
				p.PromotionDescription = this.txtPromotionDescription.Value;
				p.StartDate = Convert.ToDateTime(this.txtStartDate.Text);
				p.EndDate = this.txtEndDate.Text.Length > 0 ? Convert.ToDateTime(this.txtEndDate.Text) : System.DateTime.MinValue;
				p.UsageCount = this.txtNumberOfUses.Text.Length > 0 ? Convert.ToInt32(this.txtNumberOfUses.Text) : 0;
				p.MinimumPurchaseAmount = this.txtMinimumPurchaseAmount.Text.Length > 0 ? Convert.ToDouble(this.txtMinimumPurchaseAmount.Text) : 0.00;
				p.DiscountAmount = this.chkDiscountAmount.Checked ? Convert.ToDouble(this.txtDiscountAmount.Text) : 0.00;
				p.DiscountPercentage = this.chkDiscountPercentage.Checked ? (Convert.ToDouble(this.txtDiscountPercentage.Text) * .01) : .00;
				p.IsActive = this.chkActivateImmedietly.Checked;
				
				if(Convert.ToInt32(this.txtPromotionId.Value) > 0)
					p.RemoveProductAffiliation();
				
				foreach(ListItem i in this.lstProducts.Items){
					if(i.Selected)
						p.AddProductId(Convert.ToInt32(i.Value));
				}
				
				if(!(Convert.ToInt32(this.txtPromotionId.Value) > 0))
					p.Add();
				else
					p.Save(); 
					
				//reset ui
				this.txtDiscountAmount.Enabled = this.chkDiscountAmount.Checked = p.DiscountAmount > 0;
				this.txtDiscountPercentage.Enabled = this.chkDiscountPercentage.Checked = p.DiscountPercentage > 0;
			//}
			//catch(System.FormatException ex)
			//{
			//	this.lblErrorMessage.Visible = true;
			//	this.lblErrorMessage.Text    = "Please check your entry's. There is in error in one of your fields. " + ex.Message;	
			//}
		}
	}
}
