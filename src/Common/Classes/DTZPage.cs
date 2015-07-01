using System;
using System.Web;
using System.Data;
using OTC.Database;
using OTC.Web.Page;

namespace DogzTogz.Common.Classes
{
	public class DTZPage : OTCPage
	{
		public enum PageBuild
		{
			HideWest = 1 << 0,
			HideNavTracker = 1 << 2,
			HideMenu = 1 << 3,
			HideSoftNavigation = 1 << 4,
			HideBottomMenu = 1 << 5,
			HideMetaFooter = 1 << 6,
			HideDivWrapper = 1 << 7
		}
		
		private int    m_flags;
		private int    m_shoppingCartId;
		private string m_westWidth = "277";
		private DTZMember m_member;
		
		//public prooperties
		public int ShoppingCartId {get{return(this.m_shoppingCartId);} set{this.m_shoppingCartId = value;}}
		public DTZMember Member   {get{return(this.m_member);}         set{this.m_member = value;}}
		
		/// <summary>
		/// 
		/// </summary>
		public DTZPage()
		{
			base.BodyWidth = "950px";
			this.m_shoppingCartId = Convert.ToInt32(HttpContext.Current.Session["shoppingCartId"]);
			this.m_member  = (DTZMember)HttpContext.Current.Session["member"];
		}
		public DTZPage(int flags)
		{
			this.m_flags = flags;
			base.BodyWidth = "950px";
			this.m_shoppingCartId = Convert.ToInt32(HttpContext.Current.Session["shoppingCartId"]);
			this.m_member  = (DTZMember)HttpContext.Current.Session["member"];
		}
		public DTZPage(PageBuild flags)
		{
			this.m_flags = (int)flags;
			base.BodyWidth = "950px";
			this.m_shoppingCartId = Convert.ToInt32(HttpContext.Current.Session["shoppingCartId"]);
			this.m_member  = (DTZMember)HttpContext.Current.Session["member"];
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void Start()
		{
			Response.Write(""
					+ CR + "<div align=\"center\">" 
					+ CR + "<table width=\"" + base.BodyWidth + "\" cellpadding=\"50\" cellspacing=\"0\" class=\"" + (!((this.m_flags & (int)PageBuild.HideDivWrapper) > 0) ? "divwrapper" : "") + "\" border=\"0\">"
					+ CR + " <tr>"
					+ CR + "  <td>" 
					);
					
			this.buildSiteHeader();
			
			if(!((this.m_flags & (int)PageBuild.HideMenu) > 0))
				this.buildSiteMenu();
			
			Response.Write("<table border=\"0\" width=\"100%\">"
					+ CR + " <tr valign=\"top\">" + CR
					);	
			
			if(!((this.m_flags & (int)PageBuild.HideWest) > 0))
				this.buildWest();
			
			Response.Write("  <td> " 
					+ CR + "   <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\"><tr><td align=\"center\">" + (!((this.m_flags & (int)PageBuild.HideMenu) > 0) ? "<img src=\"/dogztogz/images/top_menu_line.gif\">" : "") + "</td></tr></table>" + CR
					);
			
			if(!((this.m_flags & (int)PageBuild.HideNavTracker) > 0))
				this.buildNavTracker();
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		private void buildNavTracker()
		{
			bool isAdmin = Request.Url.ToString().ToLower().IndexOf("admin") > -1;
			Response.Write("<table width=\"100%\">"
					+ CR + " <tr>" 
					+ CR + "  <td>"
					+ CR + "   <table>"
					+ CR + "    <tr>" + CR
					);
			
			if(Request.QueryString.ToString().IndexOf("PCID") > -1 && !(isAdmin))
			{
				int productCategoryId = Convert.ToInt32(Request.QueryString["PCID"]);
				DTZProductCategory cat = new DTZProductCategory(productCategoryId);
				Response.Write("<td class=\"tableNote\" nowrap><a href=\"/dogztogz/category/default.aspx?PCID=" + productCategoryId + "\">" + cat.ProductCategoryDescription + "</a>");
				if(Request.QueryString.ToString().IndexOf("PSCID") > -1)
					Response.Write(" | ");
				Response.Write("</td>" + CR);
			}
			
			if(Request.QueryString.ToString().IndexOf("PSCID") > -1  && !(isAdmin))
			{
				int productCategoryId = Convert.ToInt32(Request.QueryString["PSCID"]);
				DTZProductSubCategory subCat = new DTZProductSubCategory(productCategoryId);
				Response.Write("<td class=\"tableNote\" nowrap><a href=\"/dogztogz/category/subcategory.aspx?PCID=" + Request.QueryString["PCID"] + "&PSCID=" + Request.QueryString["PSCID"] + "\">" + subCat.ProductSubCategoryDescription + "</a>");
				if(Request.QueryString.ToString().IndexOf("PID") > -1)
					Response.Write(" | ");
				Response.Write("</td>" + CR);
			}
			
			if(Request.QueryString.ToString().IndexOf("PID") > -1  && !(isAdmin))
			{
				int productId = Convert.ToInt32(Request.QueryString["PID"]);
				DTZProduct product = new DTZProduct(productId);
				Response.Write("<td class=\"tableNote\" nowrap><a href=\"javascript:history.back(false)\">Continue Shopping</a>");
				Response.Write("</td>" + CR);
			}
			
			Response.Write("    </tr>"
					+ CR + "   </td>"
					+ CR + "  </table>"
					+ CR + " </td>" + CR);
			
			//if(Request.RawUrl.IndexOf("/product/") > -1 && Request.QueryString.ToString().IndexOf("PID") > -1)
			//{
			//	Response.Write("<td class=\"tableNote\" align=\"right\">[<a href=\"javascript:history.back()\">continue shopping</a>]</td>");
			//}
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>"
					); 
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildWest()
		{
			Response.Write("  <td width=\"" + this.m_westWidth + "\" class=\"westColor\" valign=\"top\">"
					+ CR + "   <table width=\"100%\">"
					+ CR + "    <tr>"
					+ CR + "     <td class=\"leftMenuItem\" align=\"center\"><br>Galleria Collection<br><br></td>"
					+ CR + "    </tr>"
					);
			
			if(!(Request.QueryString.ToString().IndexOf("PCID") > -1))
			{
				OTCDatabase db = new OTCDatabase();
				db.Open();
				DataTable dt = db.GetDataset("spGetOTCProductCategoriesMenu").Tables[0];
				db.ReleaseConnection();
				
				foreach(DataRow dr in dt.Rows)
				{
					Response.Write(" <tr height=\"30\">"
							+ CR + "  <td class=\"leftMenuItem\" height=\"30\" onclick=\"window.location='/dogztogz/category/default.aspx?PCID=" + dr["OTCProductCategoryId"].ToString() + "'\" class=\"topMenuItem\">" + dr["ProductCategoryDescription"].ToString() + "</td>"
							+ CR + " </tr>"
							);
				}
			}
			else
			{
				OTCDatabase db = new OTCDatabase();
				db.Open();
				DataTable dt = db.GetDataset("spGetOTCProductSubCategoriesMenu @OTCproductCategoryId = " + Request.QueryString["PCID"]).Tables[0];
				db.ReleaseConnection();
				
				foreach(DataRow dr in dt.Rows)
				{
					Response.Write(" <tr height=\"30\">"
							+ CR + "  <td class=\"leftMenuItem\" height=\"30\" onclick=\"window.location='/dogztogz/category/subcategory.aspx?PCID=" + dr["OTCProductCategoryId"].ToString() + "&PSCID=" + dr["OTCProductSubCategoryId"].ToString() + "'\" class=\"topMenuItem\">" + dr["ProductSubCategoryDescription"].ToString() + "</td>"
							+ CR + " </tr>"
							);
				}
			}
			
			Response.Write(" <tr>"
					+ CR + "  <td><img src=\"/dogztogz/images/left_menu_line.gif\"></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td height=\"30\"><a href=\"/dogztogz/content/about.aspx\"><font class=\"leftMenuItem\">About Us</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td class=\"leftMenuItem\" height=\"30\"><a href=\"/dogztogz/content/contact.aspx\"><font class=\"leftMenuItem\">Contact Us</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td class=\"leftMenuItem\" height=\"30\"><a href=\"/dogztogz/content/sizingguide.aspx\"><font class=\"leftMenuItem\">Sizing Guide</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td class=\"leftMenuItem\" height=\"30\"><a href=\"/dogztogz/content/helpcenter.aspx\"><font class=\"leftMenuItem\">Help Center</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><img src=\"/dogztogz/images/left_menu_line.gif\"></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td class=\"leftMenuItem\" height=\"30\"><a href=\"javascript:window.external.AddFavorite('http://www.dogztogzgalleria.com','Dogz Togz Galleria')\"><font class=\"leftMenuItem\">Bookmark Us</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td class=\"leftMenuItem\" height=\"30\"><a href=\"mailto:?subject=DogzTogz.com&body=I love this web site Dogz Togz Galleria. Check out all they have to offer. http://www.dogztogzgalleria.com\"><font class=\"leftMenuItem\">Tell A Friend</a></td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td><img src=\"/dogztogz/images/left_menu_line.gif\"></td>"
					+ CR + " </tr>"
					);
			
			if(Request.QueryString.ToString().IndexOf("PSCID") > - 1)
			{
				DTZProductSubCategory cat = new DTZProductSubCategory(Convert.ToInt32(Request.QueryString["PSCID"]));
				
				Response.Write(" <tr>"
						+ CR + "  <td class=\"leftMenuItem\" align=\"center\"><br><br>" + cat.ProductSubCategoryDescription + "</td>"
						+ CR + " </tr>"
						+ CR + " <tr>"
						+ CR + "  <td align=\"center\"><br><img src=\"/dogztogz/images/product/subcategory/" + Request.QueryString["PSCID"] + ".jpg\" width=\"150\" width=\"150\"></td>"
						+ CR + " </tr>"
						);
			}
			else if(Request.QueryString.ToString().IndexOf("PCID") > - 1)
			{
				DTZProductCategory cat = new DTZProductCategory(Convert.ToInt32(Request.QueryString["PCID"]));
				Response.Write(" <tr>"
						+ CR + "  <td class=\"leftMenuItem\" align=\"center\"><br><br>" + cat.ProductCategoryDescription + "</td>"
						+ CR + " </tr>"
						+ CR + " <tr>"
						+ CR + "  <td align=\"center\"><br><img src=\"/dogztogz/images/product/category/" + Request.QueryString["PCID"] + ".jpg\" width=\"150\" width=\"150\"></td>"
						+ CR + " </tr>"
						);
			}
			
			
			
			Response.Write("   </table>"
					+ CR + "  </td>" + CR 
					);
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildSiteMenu()
		{
			if(Request.Url.ToString().ToLower().IndexOf("admin") > -1)
			{
				Response.Write("<div align=\"center\"><table border=\"0\">"
						+ CR + " <tr>"
						+ CR + "  <a href=\"/DogzTogz/Admin/customer.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Customer</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/product.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Product</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/category.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Category</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/vendor.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Vendor</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/content.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Content</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/link.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Link To Us</td></a>"
						+ CR + "  <a href=\"/DogzTogz/Admin/reporting.aspx\"><td class=\"topMenuItem\" width=\"12.5%\" align=\"center\">Reporting</td></a>"
						+ CR + " </tr>"
						+ CR + "</table></div>" + CR
						);
			}
			else 
			{	
				int width = 0;
				OTCDatabase db = new OTCDatabase();
				db.Open();
				DataTable   dt = db.GetDataset("spGetOTCProductCategoriesMenu").Tables[0];
				db.ReleaseConnection();
				width = dt.Rows.Count / 100;
				Response.Write("<div align=\"center\">"
						+ CR + "<table width=\"90%\">"
						+ CR + " <tr>" + CR
						);
				foreach(DataRow dr in dt.Rows){
					Response.Write("<td onclick=\"window.location='/dogztogz/category/default.aspx?PCID=" + dr["OTCProductCategoryId"].ToString() + "'\" class=\"topMenuItem\" width=\"" + width + "\" align=\"center\">" + dr["ProductCategoryDescription"].ToString() + "</td>" + CR);
				} 
				
				Response.Write(" </tr>"
						+ CR + "</table>"
						+ CR + "</div>" + CR
						);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void buildSiteHeader()
		{
			Response.Write("<table width=\"" + base.BodyWidth + "\" border=\"0\">"
					+ CR + " <tr>"
					+ CR + "  <td><a href=\"/dogztogz/default.aspx\"><img src=\"/dogztogz/images/header_logo.jpg\" border=\"0\"></a></td>"
					+ CR + "  <td align=\"right\">"
					);
			
			if(!((this.m_flags & (int)PageBuild.HideSoftNavigation) > 0))
				this.buildSoftNavigation();
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>"
					);
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		private void buildSoftNavigation()
		{
			Response.Write("<table border=\"0\">"
					+ CR + " <tr>"
					+ CR + "  <td class=\"menuItem\"><a href=\"/dogztogz/default.aspx\">Home</a> | </td>"
					+ CR + "  <td class=\"menuItem\"><a href=\"http://dogztogzgalleria.blogspot.com\" target=\"_blank\">Dogz Togz Blogz</a> | </td>"
					+ CR + "  <td class=\"menuItem\"><table cellpadding=\"0\" cellspacing=\"0\"><tr><td><img src=\"/dogztogz/images/bag.gif\"></td><td class=\"menuItem\">&nbsp;<a href=\"/dogztogz/member/cart.aspx\">Galleria Bag</a> | </td></tr></table></td>"
					+ CR + "  <td class=\"menuItem\"><a href=\"/dogztogz/member/checkout.aspx\">Checkout</a></td>"
					+ CR + " </tr>"
					//+ CR + " <tr>"
					//+ CR + "  <td colspan=\"3\" class=\"menuItemHeader\"><i><font class=\"menuItemHeaderFree\">Free</font> Shipping on all products ...</td>"
					//+ CR + " </tr>"
					+ CR + "</table>" + CR 
					);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override void End()
		{
			
			int width = 0;
			OTCDatabase db = new OTCDatabase();
			db.Open();
			DataTable   dt = db.GetDataset("spGetOTCProductCategoriesMenu").Tables[0];
			db.ReleaseConnection();
			width = dt.Rows.Count / 100;
			
			if(!(Request.Url.ToString().ToLower().IndexOf("admin") > -1))
				if(!((this.m_flags & (int)PageBuild.HideMenu) > 0))
				{
					string bottomMenu = "";
					Response.Write("<br><div align=\"center\">"
							+ CR + "<table width=\"90%\">"
							+ CR + " <tr>" 
							+ CR + "  <td align=\"center\">" + CR
							);
					
					if(!((this.m_flags & (int)PageBuild.HideBottomMenu) > 0))
						foreach(DataRow dr in dt.Rows)
							bottomMenu += "&nbsp;<a href=\"/dogztogz/category/default.aspx?PCID=" + dr["OTCProductCategoryId"].ToString() + "\"  width=\"" + width + "\" align=\"center\" nowrap><font class=\"bottomMenuItem\">" + dr["ProductCategoryDescription"].ToString() + "</font></a>&nbsp; |";
						
					Response.Write(bottomMenu.TrimEnd('|'));
					
					
					Response.Write("  </td>"
							+ CR + " </tr>" + CR
							);
					
					if(!((this.m_flags & (int)PageBuild.HideBottomMenu) > 0))
						Response.Write(" <tr>"
								+ CR + "  <td align=\"center\"><img src=\"/dogztogz/images/top_menu_line.gif\"></td>"
								+ CR + " </tr>"
								);
					
					Response.Write(" <tr>"
							+ CR + "  <td align=\"center\">"
							+ CR + "   <br><br>"
							+ CR + "   <table>"
							+ CR + "    <tr valign=\"top\">"
							+ CR + "     <td class=\"menuItem\"><a href=\"/dogztogz/default.aspx\">Home</a> | </td>"
							+ CR + "     <td class=\"menuItem\"><table cellpadding=\"0\" cellspacing=\"0\"><tr><td><a href=\"/dogztogz/member/cart.aspx\"><img src=\"/dogztogz/images/bag.gif\" border=\"0\"></a></td><td class=\"menuItem\">&nbsp;<a href=\"/dogztogz/member/cart.aspx\">Galleria Bag</a>  | </td></tr></table></td>"
							+ CR + "     <td class=\"menuItem\"><a href=\"/dogztogz/member/checkout.aspx\">Checkout</a> | </td>"
							+ CR + "     <td class=\"menuItem\"><a href=\"/dogztogz/content/termsandconditions.aspx\">Terms & Conditions</a> | </td>"
							+ CR + "     <td class=\"menuItem\"><a href=\"/dogztogz/content/privacypolicy.aspx\">Privacy Policy</a> | </td>"
							+ CR + "     <td class=\"menuItem\"><a href=\"/dogztogz/content/helpcenter.aspx\">Help Center</a></td>"
							+ CR + "    </tr>"
							+ CR + "    <tr>"
							+ CR + "     <td colspan=\"6\" align=\"center\" class=\"menuItem\"><a href=\"/dogztogz/linktous.aspx\">Link To Us</a> | <a href=\"/dogztogz/links.aspx\">Links</a></td>"
							+ CR + "    </tr>"
							+ CR + "   </table>"
							+ CR + "  </td>"
							+ CR + " </tr>"
							+ CR + " <tr>"
							+ CR + "  <td align=\"center\">"
							+ CR + "   <br><br>"
							+ CR + "   <table>"
							+ CR + "    <tr>"
							+ CR + "     <td class=\"tableNote\">Copyright <a href=\"/dogztogz/admin/reporting.aspx\" style=\"TEXT-DECORATION: none;\">&copy;&nbsp;</a>" + System.DateTime.Now.Year + " Dogz Togz Galleria</td>"
							+ CR + "     <td class=\"tableNote\"><img src=\"/dogztogz/images/verisign.gif\"></td>"
							+ CR + "    </tr>"
							+ CR + "    <tr>"
							+ CR + "     <td align=\"center\" colspan=\"2\"><br><br><a href=\"http://www.olympictcs.com\" target=\"_blank\"><img src=\"/dogztogz/images/olympic_footer.jpg\" border=\"0\"></a></td>"
							+ CR + "    </tr>"
							+ CR + "   </table>"
							+ CR + "  </td>"
							+ CR + " </tr>"
							+ CR + "</table>"
							+ CR + "</div>" + CR
							);	
				}
			
			Response.Write("      </td>"
					+ CR + "     </tr>"
					+ CR + "    </table>" + CR
					);
			
			Response.Write("  </td>"
					+ CR + " </tr>"
					+ CR + "</table>"
					+ CR + (!((this.m_flags & (int)PageBuild.HideMetaFooter) > 0) ? OTCPage.BuildMetaFooter() : "")
					+ CR + "</div>" 
					+ CR + "</body>"
					+ CR + "</html>" + CR
					);
			
		}
	}
}
