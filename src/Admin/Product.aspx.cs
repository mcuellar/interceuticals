using System;
using System.IO;
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
	/// <summary>
	/// Summary description for Product.
	/// </summary>
	public class Product : System.Web.UI.Page
	{
		private   int m_productId;
		private   string m_imageTag;
		private   string m_sortChar;
		public    ITCPage m_page;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddCategory;
		protected System.Web.UI.WebControls.TextBox txtProductName;
		protected System.Web.UI.WebControls.TextBox txtPrice;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePhoto;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtProductId;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtDescription;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSortChar;
		protected System.Web.UI.WebControls.TextBox txtSku;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		private OTCDatabase m_db = new OTCDatabase();
		
		public int ProductId {get{return(this.m_productId);}}
		public string ImageTag {get{return(this.m_imageTag);}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			//if(!(this.m_page.CheckLogin()))
			//	Response.Redirect("interceuticals/admin/login.aspx");
			
			this.m_productId = Request.QueryString.ToString().IndexOf("PID") > - 1 ? Convert.ToInt32(Request.QueryString["PID"]) : 0;
			
			if(Page.IsPostBack)
				this.m_sortChar = this.txtSortChar.Value;
			else
			{
				this.m_sortChar = Request.QueryString.ToString().IndexOf("sort") > - 1 ? Request.QueryString["char"] : "A";
				this.txtSortChar.Value = this.m_sortChar;
				this.fillListBoxes();
				if(this.m_productId > 0)
					this.fillForm(sender,e);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void BuildAlphabet()
		{
			for(int i=65;i<91;i++)
				Response.Write("[<a href=\"product.aspx?thread=sort&char=" + (char)i + "\">" + (char)i + "</a>]&nbsp;");
			
			Response.Write("[<a href=\"customer.aspx?thread=sort&char=all\">all</a>]&nbsp;");
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void fillForm(object sender, System.EventArgs e)
		{
			OTCProduct product = new OTCProduct(this.m_productId);
			this.txtDescription.Value = product.ProductDescription;
			//this.txtDiscount.Text = 0.00;//product.Discount.ToString();
			this.txtPrice.Text = product.Price.ToString("c").Replace("$","");
			this.txtProductId.Value = product.ProductId.ToString();
			this.txtProductName.Text = product.ProductName;
			//this.txtShippingCosts.Text = product.ShippingPrice.ToString();
			//this.txtShippingDetails.Value = product.ShippingDetails;
			this.ddCategory.SetActiveItem(product.CategoryId);
			this.txtSku.Text = product.SKU;
			//ddCategory_SelectedIndexChanged(sender,e);
			//this.ddSubCategory.SetActiveItem(product.SubCategoryId);
			//this.ddVendors.SetActiveItem(product.VendorId);
			//this.chkActive.Checked = product.IsActive;
			//this.chkFeaturedItem.Checked = product.IsFeatured;
			
			//foreach(ListItem item in this.lstColors.Items)
			//	if(product.ProductHasFeature(Convert.ToInt32(item.Value)))
			//		item.Selected = true;
			
			//foreach(ListItem item in this.lstSizes.Items)
			//	if(product.ProductHasFeature(Convert.ToInt32(item.Value)))
			//		item.Selected = true;
			
			string savePath = Request.PhysicalApplicationPath + "images\\product\\" + product.ImageName;
			
			if(File.Exists(savePath))
				this.m_imageTag = "<img src=\"/Interceuticals/images/product/" + product.ImageName + "\" width=\"250\" height=\"250\">";
			else
				this.m_imageTag  = "";
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void fillListBoxes()
		{
			ITC dz = new ITC();
			//this.ddVendors.SQL       = "spGetOTCVendorBySiteId @OTCSiteId = " + dz.SiteId;
			//this.ddVendors.TextField = "OTCVendorName";
			//this.ddVendors.IdField   = "NO_DISPLAY_OTCVendorId";
			//this.ddVendors.IntroText = "<select vendor>";
			//this.ddVendors.Fill();
			
			this.ddCategory.SQL       = "spGetOTCProductCategoryBySiteId @OTCSiteId = " + dz.SiteId;
			this.ddCategory.TextField = "NO_DISPLAY_ProductCategoryDescription";
			this.ddCategory.IdField   = "NO_DISPLAY_ProductCategoryId";//This procedure is also used with data grid.	
			this.ddCategory.IntroText = "<select category>";
			this.ddCategory.Fill();
			
			//if(ddCategory.SelectedIndex > 0)
			//{
			//	this.ddSubCategory.SQL       = "spGetOTCProductSubCategoryByCategoryBySiteId @OTCSiteId = " + dz.SiteId + ",@OTCProductId = " + this.ddCategory.SelectedValue;
			//	this.ddSubCategory.TextField = "ProductSubCategoryDescription";
			//	this.ddSubCategory.IdField   = "OTCProductSubCategoryId";//This procedure is also used with data grid.	
			//	this.ddSubCategory.IntroText = "<select sub category>";
			//	this.ddSubCategory.Fill();
			//}
			
			//this.lstColors.SQL       = "spGetOTCProductFeatureByFeatureType @OTCProductFeatureTypeId = 1";
			//this.lstColors.TextField = "FeatureLongDescription";
			//this.lstColors.IdField   = "OTCProductFeatureId";
			//this.lstColors.Fill();  
			
			//this.lstSizes.SQL       = "spGetOTCProductFeatureByFeatureType @OTCProductFeatureTypeId = 2";
			//this.lstSizes.TextField = "FeatureLongDescription";
			//this.lstSizes.IdField   = "OTCProductFeatureId";
			//this.lstSizes.Fill();  
		}
		
		//============================
		//
		//============================
		public void DrawProducts()
		{
			OTCGrid grid;
			ITC dz = new ITC();
			DataTable dt   = OTCProduct.GetProducts(dz.SiteId);
			DataRow[] rows = dt.Select("NO_DISPLAY_ProductName LIKE '" + this.m_sortChar.ToString() + "*'");
			
			if(rows.Length > 0)
				grid = new OTCGrid(OTCGrid.GetDataTableFromArray(rows));
			else 
				grid = new OTCGrid(dt);
				
			grid.Draw();
		}
		
		//============================
		//
		//============================
		//private void ddCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		//{
		//	ITC dz = new ITC();
		//	this.ddSubCategory.Items.Clear();
		//	this.ddSubCategory.SQL       = "spGetOTCProductSubCategoryByCategoryBySiteId @OTCSiteId = " + dz.SiteId + ",@OTCProductCategoryId = " + this.ddCategory.SelectedValue;
		//	this.ddSubCategory.TextField = "ProductSubCategoryDescription";
		//	this.ddSubCategory.IdField   = "OTCProductSubCategoryId";//This procedure is also used with data grid.	
		//	this.ddSubCategory.IntroText = "<select sub category>";
		//	this.ddSubCategory.Fill();
		//}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			//this.ddCategory.SelectedIndexChanged += new System.EventHandler(this.ddCategory_SelectedIndexChanged);
			InitializeComponent();
			base.OnInit(e);
			
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.txtDescription.ServerChange += new System.EventHandler(this.txtDescription_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(this.txtProductId.Value) > 0)
			{
				OTCProduct product = new OTCProduct(Convert.ToInt32(this.txtProductId.Value));
				product.Delete();
				Response.Redirect("product.aspx");
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//if(this.ddVendors.SelectedIndex == 0 || this.ddSubCategory.SelectedIndex == 0 || this.ddCategory.SelectedIndex == 0)
			//	return;
				
			ITC dz                = new ITC();
			HttpPostedFile file   = filePhoto.PostedFile;
			//HttpPostedFile thumb  = ""; //thumbNail.PostedFile;
			string savePath       = Request.PhysicalApplicationPath + "images\\product\\";
			string thumbPath	  = Request.PhysicalApplicationPath + "images\\product\\ThumbNail\\";
			OTCProduct product    = Convert.ToInt32(this.txtProductId.Value) > 0 ? new OTCProduct(Convert.ToInt32(this.txtProductId.Value)) : new OTCProduct();
			product.OTCSiteId	  = dz.SiteId;
			product.CategoryId    = Convert.ToInt32(this.ddCategory.SelectedValue);
			product.IsActive      = true; //this.chkActive.Checked;
			product.IsFeatured    = false; //this.chkFeaturedItem.Checked;
			product.ShippingDetails = ""; //this.txtShippingDetails.Value;
			product.Price         = Convert.ToDouble(this.txtPrice.Text);
			product.Discount	  = 0.0; //Convert.ToDouble(this.txtDiscount.Text);
			product.ProductDescription = this.txtDescription.Value;
			product.ProductName   = this.txtProductName.Text;
			product.ShippingPrice = 0.00;//Convert.ToDouble(this.txtShippingCosts.Text);
			product.SubCategoryId = 0;//Convert.ToInt32(this.ddSubCategory.SelectedValue);
			product.VendorId      = 89; //Convert.ToInt32(this.ddVendors.SelectedValue);
			product.SKU           = this.txtSku.Text;
			
			if(product.ProductId > 0)
			{
				product.Save();
				if(file.FileName.Length > 0)
				{
					int extensionStart = file.FileName.LastIndexOf(".");
					int extensionEnd   = file.FileName.Length - extensionStart;
					string extension   = file.FileName.Substring(extensionStart,extensionEnd);
					product.ImageName  = product.ProductId + extension;
					product.Save();
					file.SaveAs(savePath + product.ProductId + extension);
				}
			}
			else
			{
				if(!(file.FileName.Length > 0))
				{
					product.ImageName = ".jpeg";
					product.Add();
				}
				else
				{
					int extensionStart = file.FileName.LastIndexOf(".");
					int extensionEnd   = file.FileName.Length - extensionStart;
					string extension   = file.FileName.Substring(extensionStart,extensionEnd);
					product.ImageName = extension;	
					int productId = product.Add();
					file.SaveAs(savePath + productId + extension);
				}
			}
			
			//
			//if(thumb.FileName.Length > 0)
			//{
			//	int extensionStart = thumb.FileName.LastIndexOf(".");
			//	int extensionEnd   = thumb.FileName.Length - extensionStart;
			//	string extension   = thumb.FileName.Substring(extensionStart,extensionEnd);
			//	thumb.SaveAs(thumbPath + product.ProductId + extension);
			//}
			
			
			product.DeleteProductFeatures(); //remove all features and add them again.
			
			//foreach(ListItem item in this.lstColors.Items){
			//	if(item.Selected)
			//		product.AddProductFeature(Convert.ToInt32(item.Value));
			//}
			
			//foreach(ListItem item in this.lstSizes.Items){
			//	if(item.Selected)
			//		product.AddProductFeature(Convert.ToInt32(item.Value));
			//}
			
			Response.Redirect("Product.aspx?PID=" + product.ProductId + "&sort=1&char=" + this.txtSortChar.Value);
		}

		private void txtDescription_ServerChange(object sender, System.EventArgs e)
		{
		
		}
	}
}
