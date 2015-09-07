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
using OTC.Database;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;
using OTC.Web.Page;
using Interceuticals.Common.Util;
using log4net;
using System.Reflection;

namespace Interceuticals.Product
{
	public class _Default : System.Web.UI.Page
	{
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private DataTable m_dt;
		private int m_preselectedProduct = 0;
		private int m_selectedProduct = 0;
		private string m_site = "";
		private string m_hiddenDivs;
		private string m_membershipHTML;
		private string m_googleTrackingCode;
		private string m_thread;
		private bool m_showMembershipLink;
		private OTCDatabase m_db = new OTCDatabase();
		char CR = (char)10;
		protected System.Web.UI.WebControls.Button btnAddToCart;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.TextBox txtPromotionCode;
		protected System.Web.UI.WebControls.DropDownList ddProducts;
		protected System.Web.UI.WebControls.CheckBox chkAutoship;
        protected System.Web.UI.WebControls.CheckBox chkNotAutoship;
		public ITCPage m_page;
		
		public string Site				 {get{return(this.m_site);					}}
		public string MemberShipHTML     {get{return(this.m_membershipHTML);		}}
		public string HiddenDIV          {get{return(this.m_hiddenDivs);			}}
		public string GoogleTrackingCode {get{return(this.m_googleTrackingCode);	}}
		public bool HasMemberShip		 {get{return(Convert.ToBoolean(Session["WantsMemberShip"]));}}
		public bool ShowMembershipLink   {get{return(this.m_showMembershipLink);	}}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
            //loadJavaScript();
            
            
			Session["site"] = this.m_site = Request.QueryString.ToString().IndexOf("site") > - 1 ? Request.QueryString["site"] : "bm";
			this.m_googleTrackingCode = (this.m_site == "bm" ? "UA-1185020-2" : "UA-1185020-1");
			this.m_preselectedProduct = Request.QueryString.ToString().IndexOf("PID")  > - 1 ? Convert.ToInt32(Request.QueryString["PID"]) : 0;
			this.m_thread = Request.QueryString.ToString().IndexOf("thread") > - 1 ? Request.QueryString["thread"] : "";
			this.m_page = new ITCPage();
            
            this.chkAutoship.Attributes.Add("onClick", "changeAutoShipState()");
            //this.chkNotAutoship.Attributes.Add("onClick", "changeNotAutoShipState()");
            
			Log.InfoFormat("Starting order for product id: {0}", m_preselectedProduct.ToString());
		
			if(!Page.IsPostBack)
			{	
				if(this.m_thread == "test")
					this.txtPromotionCode.Text = Request.QueryString["PKEY"];
					
				OTCDatabase db = new OTCDatabase();
				string categoryId = this.m_site == "bm" ? "21" : "22";
				db.Open();
				this.m_dt = db.GetDataset("spGetINT_VisibleProducts " + categoryId).Tables[0];
				db.ReleaseConnection();
				
				OTCShoppingCart cart = new OTCShoppingCart(Session.SessionID);
				
				bool haveSelection = false;
				
				foreach(DataRow dr in this.m_dt.Rows)
				{
					ListItem item = new ListItem(dr["DisplayText"].ToString(),dr["OTCProductId"].ToString());
					if(cart.CartContainsProduct(Convert.ToInt32(item.Value)) || cart.CartContainsProduct(Convert.ToInt32(dr["OTCSubordinateProductId"]))){
						if(!haveSelection)
							item.Selected = true;
						haveSelection = true;
					}
                    if(!ddProducts.Items.Contains(item))
                        this.ddProducts.Items.Add(item);
				}
				
				if(Convert.ToBoolean(Session["wantsMembership"]))
					this.chkAutoship.Checked = true;
				
				string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Product\\MembershipHTML\\" + this.ddProducts.SelectedValue + ".htm";
				OTCHtmlReader reader = new OTCHtmlReader(file);
				this.m_membershipHTML = reader.HTML;
				
				DirectoryInfo dInfo = new DirectoryInfo(Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Product\\MembershipHTML\\");
				
				foreach(FileInfo f in dInfo.GetFiles())
				{
					reader = new OTCHtmlReader(f.FullName);
					this.m_hiddenDivs += "<div id=\"div" + f.Name.Replace(".htm","") + "\" class=\"hidden\">" + reader.HTML + "</div>" + CR;
				}
			}
		}

        private void loadJavaScript()
        {
            
            HtmlGenericControl js = new HtmlGenericControl("script");
            js.Attributes.Add("type", "javascript");
            js.Attributes.Add("src", "/Interceuticals/Product/Default.js");
            this.Page.Header.Controls.Add(js);  
 
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
			this.ddProducts.SelectedIndexChanged += new System.EventHandler(this.ddProducts_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
					productId = Convert.ToInt32(dt.Rows[0]["subordinateOTCProductId"]);
					return(productId);
				}
			}
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddToCart_Click(object sender, System.EventArgs e)
		{
			OTCShoppingCart cart = new OTCShoppingCart(Session.SessionID); //?what am i doing here ?
			int productId = this.getCorrectProductId(Convert.ToInt32(this.ddProducts.SelectedValue));
			bool addedItems = false;
			string f = Request.Form.ToString();
			cart = new OTCShoppingCart(this.m_page.ShoppingCartId);
			cart.RemoveAllItems(this.m_page.ShoppingCartId);
			OTCShoppingCartItem item = new OTCShoppingCartItem();
			OTCProduct product = new OTCProduct(Convert.ToInt32(this.ddProducts.SelectedValue));
			item.ProductID = Convert.ToInt32(productId);
			item.ProductPrice = product.Price;
			item.ItemCount = 1;
			cart.AddCartItem(item);
			string key = "";
			string howie = "?__utma=1.1914565456.1179433560.1179515921.1179867123.5&__utmb=1&__utmc=1&__utmx=-&__utmz=1.1179433560.1.1.utmccn%3D(direct)%7Cutmcsr%3D(direct)%7Cutmcmd%3D(none)&__utmv=-&__utmk=233877919";
			
			//if(this.txtPromotionCode.Text.Length > 0)
			//	if(OTCPromotion.PromotionKeyExists(this.txtPromotionCode.Text))
			//		key = this.txtPromotionCode.Text;


            if ((Request.ServerVariables["HTTP_HOST"] == "localhost:1047") || (Request.ServerVariables["HTTP_HOST"] == "MVCDesktop"))
                Response.Redirect("../order/PreCheckOut.aspx" + howie + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : "") + Request.QueryString);
            else if ((Request.ServerVariables["HTTP_HOST"] == "interceuticals.serveronline.net"))
                Response.Redirect("http://interceuticals.serveronline.net/interceuticals/order/PreCheckOut.aspx" + howie + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
            else
                Response.Redirect("https://www.interceuticals.com/interceuticals/order/PreCheckOut.aspx" + howie + "&SCID=" + this.m_page.ShoppingCartId + "&site=" + Session["site"] + "&" + (key.Length > 0 ? "?PKY=" + key : ""));
			
		}

		private void ddProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string categoryId = Session["site"] == "bm" ? "21" : "22";
			string file = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Product\\MembershipHTML\\" + this.ddProducts.SelectedValue + ".htm";
			OTCHtmlReader reader = new OTCHtmlReader(file);
			this.m_membershipHTML = reader.HTML;
			this.m_db.Open();
			this.m_dt = this.m_db.GetDataset("spGetINT_VisibleProducts " + categoryId).Tables[0];
			this.m_db.ReleaseConnection();
			DataRow[] rows = this.m_dt.Select("OTCProductId = " + this.ddProducts.SelectedValue);
			
			if(rows.Length > 0){
				if(!(Convert.ToInt32(rows[0]["OTCSubordinateProductId"]) > 0))
				{
					this.chkAutoship.Enabled = false;
					this.chkAutoship.Text    = "Autoship Unavailable";
				}
				else
				{ 
					this.chkAutoship.Enabled = true;
                    this.chkAutoship.Checked = true;
                    this.chkAutoship.Text = "Uncheck this box if you do not wish to be enrolled into the program.";
				}
			}
			else
			{
				this.chkAutoship.Visible = true;
				//this.chkAutoship.Checked = Convert.ToBoolean(Session["wantsMembership"]);
			}
		}

	}
}
