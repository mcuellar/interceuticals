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

namespace Interceuticals.Admin
{
	public class Promotion : System.Web.UI.Page
	{
		public ITCPage m_page;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnDeletePromotion;
		protected System.Web.UI.WebControls.CheckBox chkInfinate;
		protected System.Web.UI.WebControls.TextBox txtNumberOfUses;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDiscountRate;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtPromotionKey;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPromotionName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddPromotion;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtPromotionDescription;
		private OTCDatabase m_db = new OTCDatabase();
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			this.m_page.HideWest = true;
			if(!Page.IsPostBack)
				this.fillPromotionList();
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void fillPromotionList()
		{
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset("spGetOTCPromotion").Tables[0];
			this.m_db.ReleaseConnection();
			
			if(!(dt.Rows.Count > 0)){
				ListItem item = new ListItem("No Promotions Available","0");
				this.ddPromotion.Items.Add(item);
			} else {
				this.ddPromotion.Items.Add( new ListItem("Please Select","0"));
			}
			
			foreach(DataRow dr in dt.Rows){
				ListItem item = new ListItem(dr["PromotionName"].ToString(),dr["OTCPromotionId"].ToString());
				this.ddPromotion.Items.Add(item);
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
			this.ddPromotion.SelectedIndexChanged += new System.EventHandler(this.ddPromotion_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			OTCPromotion promotion = new OTCPromotion();
			promotion.IsMultyUse = this.chkInfinate.Checked || Convert.ToInt32(this.txtNumberOfUses.Text) > 1;
			promotion.PromotionDesc = this.txtPromotionDescription.Value;
			promotion.PromotionDiscount = Convert.ToDouble("." + this.txtDiscountRate.Text);
			promotion.PromotionKey = this.txtPromotionKey.Text;
			promotion.PromotionName = this.txtPromotionName.Text;
			
			if(this.ddPromotion.SelectedIndex > 0)
				promotion.Save();
			else 
				promotion.Add();
		}
		
		
		/// <summary>
		/// Pull in promotion that PeiPei is looking for. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ddPromotion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int promotionId = Convert.ToInt32(this.ddPromotion.SelectedValue);
			OTCPromotion promotion = new OTCPromotion(promotionId);
			this.txtPromotionDescription.Value = promotion.PromotionDesc;
			this.txtPromotionKey.Text = promotion.PromotionKey;
			this.txtPromotionName.Text = promotion.PromotionName;
			this.txtNumberOfUses.Text = promotion.UsageCount.ToString();
			this.txtDiscountRate.Text =  promotion.PromotionDiscount.ToString();
		}
	}
}
