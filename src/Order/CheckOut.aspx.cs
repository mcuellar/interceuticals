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
	public class CheckOut : System.Web.UI.Page
	{
		public ITCPage m_page;
        public ITCCrossSellingProducts m_crosspage = null;
		private char   CR = (char)10;
		private int    m_shoppingCartId = 0;
		private double m_salesTax   = .00;
		private double m_orderTotal = .00;
		private string m_googleTrackingCode;
		private string m_promotionKey;
        private int m_productID = -1;
        private string m_site = "";
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtEmailAddress;
		protected System.Web.UI.WebControls.TextBox txtBillingStreet;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtZipPostalCode;
		protected System.Web.UI.WebControls.Button btn;
		protected System.Web.UI.WebControls.Button btnCheckout;
		protected System.Web.UI.WebControls.Label lblErroMessage;
		protected System.Web.UI.WebControls.TextBox txtShippingFirstName;
		protected System.Web.UI.WebControls.TextBox txtShippingLastName;
		protected System.Web.UI.WebControls.TextBox txtShippingEmailAddress;
		protected System.Web.UI.WebControls.TextBox txtShippingStateProvince;
        protected System.Web.UI.WebControls.TextBox txtStateProvince;
		protected System.Web.UI.WebControls.TextBox txtShippingZipPostalCode;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtShippingAddress;
		protected System.Web.UI.WebControls.TextBox txtShippingCity;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddCountry;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddState;
        protected OTC.Web.Controls.DropDown.OTCDropDown ddStateShip;
		protected OTC.Web.Controls.ListBox.OTCListBox ddShippingMethods;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddMonth;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddYear;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddCCType;
		protected System.Web.UI.WebControls.TextBox txtCardNumber;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator10;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator11;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator12;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator13;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator15;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtComments;
		//protected System.Web.UI.WebControls.TextBox txtCid;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator16;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator17;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator18;
		protected System.Web.UI.WebControls.TextBox txtShippingPhone;
		protected System.Web.UI.HtmlControls.HtmlForm f1;
		protected System.Web.UI.WebControls.TextBox txtHowDie;
		protected OTC.Web.Controls.DropDown.OTCDropDown ddShippingCountry;
		protected System.Web.UI.WebControls.Label lblErrorMessage2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtOrginialQueryString;
		private OTCDatabase m_db = new OTCDatabase();
        private String m_crossSellProducts = "";

	    public String Website;

        private bool isStateValid = false;
        
	
		public string GoogleTrackingCode {get{return(this.m_googleTrackingCode);}}

        private void Page_Load(object sender, System.EventArgs e)
        {
            this.m_page = new ITCPage();

            if (m_page.IsBetterWoman)
            {
                Website = "bw";
            }
            else Website = "bm";

            string removeId = Request.QueryString.ToString().IndexOf("remove") > -1 ? Request.QueryString["remove"] : "0";
            string thread = Request.QueryString.ToString().IndexOf("thread") > -1 ? Request.QueryString["thread"] : "";
            string promotionKey = Request.QueryString.ToString().IndexOf("PRID") > -1 ? Request.QueryString["PRID"] : "";
            this.m_shoppingCartId = Request.QueryString.ToString().IndexOf("SCID") > -1 ? Convert.ToInt32(Request.QueryString["SCID"]) : 0;
        

            m_productID = Convert.ToInt32(Request.QueryString["PID2"]);
            m_site = Request.QueryString["site"];

            if (Convert.ToInt32(removeId) > 0)
            {
                OTCShoppingCartItem i = new OTCShoppingCartItem(Convert.ToInt32(removeId));
                OTCShoppingCart c = new OTCShoppingCart(this.m_shoppingCartId);
                c.RemoveCartItem(i);
                string newQueryString = "";
                foreach (string s in Request.QueryString.ToString().Split('&'))
                {
                    Response.Write(s + "<br>" + CR);
                    if (s != ("remove=" + removeId))
                    {
                        newQueryString += s + "&";
                    }
                }
                Response.Redirect("Checkout.aspx?" + newQueryString.Trim('&'));
            }


            if (Convert.ToInt32(Session["SID"]) > 0)
            {
                this.resetForm();
            }
            
            if (!Page.IsPostBack && (thread != "reset"))
            {
                this.ddState.SQL = "spGetOTCState";
                this.ddState.TextField = "StateName";
                this.ddState.IdField = "StateAbbreviation";
                this.ddState.IntroText = "Please Select";
                this.ddState.Fill();

                bindStateShipControl();

                this.ddCountry.IntroText = "Please Select";
                this.ddCountry.SQL = "spGetOTCCountry";
                this.ddCountry.TextField = "CountryName";
                this.ddCountry.IdField = "OTCCountryId";
                this.ddCountry.Fill();

                int index1 = 0;
                int index2 = 0;

                foreach (ListItem i in this.ddCountry.Items)
                {
                    switch (i.Text)
                    {
                        case "United States":
                            i.Attributes.Add("style", "color:Red");
                            break;
                        case "Canada":
                            i.Attributes.Add("style", "color:Red");
                            break;
                        case "Cameroon":
                            index1 = ddCountry.Items.IndexOf(i);
                            break;
                        case "United Arab Emirates":
                            index2 = ddCountry.Items.IndexOf(i);
                            break;
                    }
                }

                //ddCountry.Items.Insert(index1 + 1, new ListItem("Canada", "126"));
                //ddCountry.Items.Insert(index2 + 2, new ListItem("United States", "222"));


                this.ddShippingCountry.IntroText = "Please Select";
                this.ddShippingCountry.SQL = "spGetOTCCountry";
                this.ddShippingCountry.TextField = "CountryName";
                this.ddShippingCountry.IdField = "OTCCountryId";
                this.ddShippingCountry.Fill();


                index1 = 0;
                index2 = 0;

                foreach (ListItem i in this.ddShippingCountry.Items)
                {
                    switch (i.Text)
                    {
                        case "United States":
                            i.Attributes.Add("style", "color:Red");
                            break;
                        case "Canada":
                            i.Attributes.Add("style", "color:Red");
                            break;
                        case "Cameroon":
                            index1 = ddShippingCountry.Items.IndexOf(i);
                            break;
                        case "United Arab Emirates":
                            index2 = ddShippingCountry.Items.IndexOf(i);
                            break;
                    }
                }

                ddShippingCountry.Items.Insert(index1 + 1, new ListItem("Canada", "126"));
                ddShippingCountry.Items.Insert(index2 + 2, new ListItem("United States", "222"));

                this.fillCCLists();
                this.fillShippingMethods();
            }
            
            this.fillShippingMethods();

            this.m_salesTax = this.ddStateShip.SelectedValue == "MA" ? .0625 : 00;

            if (Request.ServerVariables["HTTP_HOST"].ToString().IndexOf("localhost") > -1)
                if (!Page.IsPostBack)
                    this.setDevelopmentForm();
        }

        private void bindStateShipControl()
        {
            this.ddStateShip.SQL = "spGetOTCState";
            this.ddStateShip.TextField = "StateName";
            this.ddStateShip.IdField = "StateAbbreviation";
            this.ddStateShip.IntroText = "Please Select";
            this.ddStateShip.Fill();
        }

        protected String getSiteName()
        {
            String site = m_site == "bm" ? "BetterMAN" : "BetterWOMAN";
            return site;
        }

		/// <summary>
		/// 
		/// </summary>
		private void setDevelopmentForm()
		{
			this.txtAddress.Text = "5 Winstead Ave";
			//this.txtBillingStreet.Text = m.Address;
			this.txtCardNumber.Text = "41111111111111111";
			this.txtCity.Text = "Woburn";
			this.txtComments.Value = "TEST: Olympic Technology Test Form";
			this.txtEmailAddress.Text = "chris@olympictcs.com";
			this.txtFirstName.Text = "Chris";
			this.txtLastName.Text = "Jewer";
			this.txtPhone.Text = "781-999-9999";
			this.txtZipPostalCode.Text = "01801";
			this.txtShippingAddress.Text = "5 Winstead Ave";
			this.txtShippingCity.Text = "Woburn";
			this.txtShippingEmailAddress.Text = "chris@olympictcs.com";
			this.txtShippingFirstName.Text = "Chris";
			this.txtShippingLastName.Text = "Jewer";
			this.txtShippingPhone.Text = "781-222-2222";
			this.txtShippingEmailAddress.Text = "chris@olympictcs.com";
			//this.txtShippingStateProvince.Text = "MA";
			this.txtShippingZipPostalCode.Text = "01801";
			this.ddCountry.SelectedIndex = 1;
			this.ddShippingCountry.SelectedIndex = 1;
			this.ddMonth.SelectedIndex = 1;
			this.ddYear.SelectedIndex = 10;
			this.ddCCType.SelectedIndex = 1;
			this.ddState.SelectedIndex = 26;
          
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		private void resetForm()
		{
			int salesOrderId = Convert.ToInt32(Session["SID"]);
			OTCSalesOrder salesOrder = new OTCSalesOrder(salesOrderId);
			OTCShoppingCart cart = new OTCShoppingCart(Session.SessionID);
			Session["shoppingCartId"]   = cart.AddNew();
			cart = new OTCShoppingCart(Convert.ToInt32(Session["shoppingCartId"]));
			OTCShoppingCartItem item = new OTCShoppingCartItem();
			string sql = "SELECT * FROM OTCSalesOrderDetail WHERE OTCSalesOrderId = " + salesOrder.OTCSalesOrderId;
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset(sql).Tables[0];
			this.m_db.ReleaseConnection();
			foreach(DataRow dr in dt.Rows)
			{
				item.ProductID = Convert.ToInt32(dr["OTCProductId"]);
				item.ProductPrice = Convert.ToDouble(dr["ItemPrice"]);
				item.ItemCount = Convert.ToInt32(dr["ItemCount"]);
				OTCProduct p = new OTCProduct(item.ProductID);
				if(p.CategoryId == 21)
					Session["site"] = "bm";
				else 
					Session["site"] = "bw";
				cart.AddCartItem(item);
			}
			OTCSiteMember m = new OTCSiteMember(salesOrder.OTCSiteMemberId);
			OTCCreditCard c = new OTCCreditCard(salesOrder.OTCSalesOrderId);
			
			if(Page.IsPostBack)
				return;
			
			this.txtAddress.Text = m.Address;
			//this.txtBillingStreet.Text = m.Address;
			this.txtCardNumber.Text = c.CardNumber;
			this.txtCity.Text = m.City;
			this.txtComments.Value = salesOrder.Comments;
			this.txtEmailAddress.Text = m.EmailAddress;
			this.txtFirstName.Text = m.FirstName;
			this.txtLastName.Text = m.LastName;
			this.txtPhone.Text = salesOrder.Phone;
			this.txtZipPostalCode.Text = m.Zip;
			this.txtShippingAddress.Text = salesOrder.ShippingAddress;
			this.txtShippingCity.Text = salesOrder.City;
			this.txtShippingEmailAddress.Text = salesOrder.ShippingEmailAddress;
			this.txtShippingFirstName.Text = salesOrder.ShippingFirstName;
			this.txtShippingLastName.Text = salesOrder.LastName;
			this.txtShippingPhone.Text = salesOrder.Phone;
			this.txtShippingEmailAddress.Text = salesOrder.EmailAddress;
			this.txtShippingStateProvince.Text = salesOrder.ShippingState;
			this.txtShippingZipPostalCode.Text = salesOrder.ShippingZip;
			
			this.ddState.SQL         = "spGetOTCState";
			this.ddState.TextField   = "StateName";
			this.ddState.IdField     = "StateAbbreviation";
			this.ddState.IntroText   = "Please Select";
			this.ddState.Fill();



			foreach(ListItem i in this.ddState.Items){
				if(i.Text == salesOrder.State){
					i.Selected = true;
					break;
				}
			}

            bindStateShipControl();

            foreach (ListItem i in this.ddStateShip.Items)
            {
                if (i.Text == salesOrder.State)
                {
                    i.Selected = true;
                    break;
                }
            }
			
				
			this.ddCountry.IntroText = "Please Select";
            this.ddCountry.SQL       = "spGetOTCCountry";
			this.ddCountry.TextField = "CountryName";
			this.ddCountry.IdField   = "CountryAbbreviation";
			this.ddCountry.Fill();
			
			foreach(ListItem i in this.ddCountry.Items){
				if(i.Text == salesOrder.Country){
					i.Selected = true;
					break;
				}

                if (i.Value == "United States")
                    i.Attributes.Add("style", "color:Blue");

			}
						
			this.ddShippingCountry.IntroText = "Please Select";
			this.ddShippingCountry.SQL       = "spGetOTCCountry";
			this.ddShippingCountry.TextField = "CountryName";
			this.ddShippingCountry.IdField   = "OTCCountryId";
			this.ddShippingCountry.Fill();
			
			foreach(ListItem i in this.ddShippingCountry.Items){
				if(i.Text == salesOrder.Country){
					i.Selected = true;
					break;
				}
			}	
				
			this.fillCCLists();
			this.fillShippingMethods();
			
			foreach(ListItem i in this.ddCCType.Items){
				if(i.Text== c.CardType){
					i.Selected = true;
					break;
				}
			}
			
			foreach(ListItem i in this.ddMonth.Items){
				if(i.Value == c.ExpirationMonth){
					i.Selected = true;
					break;
				}
			}
			
			foreach(ListItem i in this.ddYear.Items){
				if(i.Value == c.ExpirationYear){
					i.Selected = true;
					break;
				}
			}
			
			double shippingRate = this.getShippingRate();
			this.ddShippingMethods.Items.Clear();
			ListItem it = new ListItem();
			it.Text  = "S/H in US - $" + shippingRate;
			if(salesOrder.ShippingMethod == it.Text)
				it.Selected = true;	
			it.Value = "10.99";
			this.ddShippingMethods.Items.Add(it);
			
			it = new ListItem();
			it.Text  = "Rush S/H in US - " + (shippingRate + 9.99).ToString();
			it.Value = "19.99";
			if(salesOrder.ShippingMethod == it.Text)
				it.Selected = true;
			this.ddShippingMethods.Items.Add(it);
			
			it= new ListItem();
            it.Text = "S/H to Canada - $" + (shippingRate + 5.00).ToString();
            it.Value = (shippingRate + 5.00).ToString();
			if(salesOrder.ShippingMethod == it.Text)
				it.Selected = true;
			this.ddShippingMethods.Items.Add(it);
			
			it = new ListItem();
			it.Text  = "S/H to other countries and the Carribean-$30.99";
			it.Value = "30.99";
			if(salesOrder.ShippingMethod == it.Text)
				it.Selected = true;
			this.ddShippingMethods.Items.Add(it);

		}
		
		/// <summary>
		/// 
		/// </summary>
		private void fillCCLists()
		{
			ListItem item;
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset("spGetOTCLookup @Subject = 'c'").Tables[0];
			this.m_db.ReleaseConnection();
			
			if(!Page.IsPostBack)
				this.ddCCType.Items.Add(new ListItem("Please Select",0.ToString()));
				
			foreach(DataRow dr in dt.Rows)
			{
				string textValue = "";
				item = new ListItem();
				switch(dr["Value"].ToString())
				{
					case "v": textValue = "Visa"; break;
					case "m": textValue = "Master Card"; break;
					case "d": textValue = "Discover"; break;
					case "a": textValue = "Amex"; break;
				}
				item.Text  = textValue;
				item.Value = dr["OTCLookupId"].ToString();
				this.ddCCType.Items.Add(item);
			}
			
			this.ddYear.Items.Add(new ListItem("",0.ToString()));
			int startYear = System.DateTime.Now.Year;
			int endYear   = System.DateTime.Now.Year + 20;
			for(int i=startYear;i<endYear;i++){
				item       = new ListItem();
				item.Text  = i.ToString();
				item.Value = i.ToString();
				this.ddYear.Items.Add(item);
			}
			
			this.ddMonth.Items.Add(new ListItem("",0.ToString()));
			for(int i=1;i<13;i++)
			{
				item       = new ListItem();
				item.Text  = this.getMonthName(i);
				item.Value = i.ToString();
				this.ddMonth.Items.Add(item);
			}
			//this.ddMonth.SelectedValue = System.DateTime.Now.Month.ToString();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="i"></param>
		private string getMonthName(int i)
		{
			string monthName = "";
			switch(i)
			{
				case 1:  monthName = "01"; break;
				case 2:  monthName = "02"; break;
				case 3:  monthName = "03"; break;
				case 4:  monthName = "04"; break;
				case 5:  monthName = "05"; break;
				case 6:  monthName = "06"; break;
				case 7:  monthName = "07"; break;
				case 8:  monthName = "08"; break;
				case 9:  monthName = "09"; break;
				case 10: monthName = "10"; break;
				case 11: monthName = "11"; break;
				case 12: monthName = "12"; break;
			}
			return (monthName);
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void fillShippingMethods()
		{
            int currentSelectedIndex = this.ddShippingMethods.SelectedIndex;
			this.ddShippingMethods.Items.Clear();
			double shippingRate = this.getShippingRate();

			ListItem item = new ListItem();
			item.Text  = "S/H in US - $" + shippingRate;
		    item.Value = "US";
            item.Attributes.Add("data-cost", (shippingRate).ToString());
            item.Attributes.Add("data-countryid", "222");
			this.ddShippingMethods.Items.Add(item);
			item = new ListItem();
			item.Text  = "Rush S/H in US - $" + (shippingRate + 9.99).ToString(); //" + $9.99";
            item.Attributes.Add("data-cost", (shippingRate + 9.99).ToString());
            item.Attributes.Add("data-countryid", "222");
		    item.Value = "USRUSH";
			this.ddShippingMethods.Items.Add(item);
			
            item = new ListItem();
			item.Text  = "S/H to Canada - $" + (shippingRate + 5.00).ToString();
		    item.Value = "CA";
            item.Attributes.Add("data-cost", (shippingRate + 5.00).ToString());
            item.Attributes.Add("data-countryid", "126");
			this.ddShippingMethods.Items.Add(item);
			
            item = new ListItem();
			item.Text  = "S/H to other countries and the Carribean - $30.99";
			item.Value = "IT";
            item.Attributes.Add("data-cost", "30.99");
            item.Attributes.Add("data-countryid", "0");
			this.ddShippingMethods.Items.Add(item);

            if (currentSelectedIndex != -1)
                ddShippingMethods.SelectedIndex = currentSelectedIndex;
            else
                ddShippingMethods.SelectedIndex = 0;
                

		}
		
		/// <summary>
		/// 
		/// </summary>
		public void DrawMemberQuestions()
		{
			ArrayList l = new ArrayList();
			ITC itc = new ITC();
			DataTable dt = OTCSiteMemberQuestion.GetSiteMemberQuestions(itc.SiteId);
			
			foreach(DataRow dr in dt.Rows){
				if(!(l.Contains(dr["QuestionText"].ToString())))
					l.Add(dr["QuestionText"].ToString());
			}
			
			Response.Write("<table border=\"0\">" 
					+ CR + " <tr>"
					+ CR + "  <td>How did you hear about us?</td>"
					+ CR + "  <td><input class=\"textbox\" type=\"textbox\" name=\"txtHowDidYouHear\" size=\"27\"></td>"
					+ CR + " </tr>"
					);
		
			for(int i=0;i<l.Count;i++){
				DataRow[] rows = dt.Select("QuestionText = '" + l[i].ToString() + "'");
				Response.Write(" <tr>"
						+ CR + "  <td>" + l[i].ToString() + "</td>"
						+ CR + "  <td>" + this.buildList(rows,rows[0]["OTCSiteMemberQuestionId"].ToString(),"Select One") + "</td>"
						+ CR + " </tr>"
						);
			}
			
			Response.Write(" <tr>"
					+ CR + "  <td>Please enter in your promotion code:<br><font size=\"1\">(only if applicable)</td>"
					+ CR + "  <td><input type=\"textbox\" class=\"textbox\" id=\"promotion\" name=\"promotion\" size=\"27\"></td>"
					+ CR + " </tr>"
					+ CR + "</table>" + CR
					);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="rows"></param>
		/// <returns></returns>
		private string buildList(DataRow[] rows, string id, string heading)
		{
			string s = "<select class=\"textbox\" id=\"mq_" + id + "\" name=\"mq_" + id + "\" style=\"width:197px;\">" + CR;
			if(heading != null)
				s += " <option value=\"0\">" + heading + CR;
			
			foreach(DataRow dr in rows)
				s += " <option value=\"" + dr["OTCSiteMemberAnswerId"].ToString() + "\">" + dr["AnswerText"].ToString() + CR;
				
			s += "</select>" + CR;
			return(s);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void buildStep1()
		{
            
					
			OTCShoppingCart cart = new OTCShoppingCart(this.m_shoppingCartId);
			OTC.Web.Promotion.OTCPromotion p = new OTC.Web.Promotion.OTCPromotion(cart.OTCPromotionId);
			
			if(cart.CartItems.Length == 0)
				this.btnCheckout.Enabled = false;

            if (cart.CartItems.Length == 0)
            {
                Response.Write("<br><br><div align=\"center\" class=\"no-items\"><font color=\"red\">You have no items in your bag!</font><br><a href=\"http://www.interceuticals.com/interceuticals/product/default.aspx" + (this.m_page.IsBetterWoman ? "?site=bw" : "") + "\"><font class=\"tableFont\">continue shopping</a></div>");
                Control form = this.Page.Controls[0];
                foreach (Control c in form.Controls)
                {
                    if (c.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                    {
                        System.Web.UI.WebControls.TextBox ctrl = (System.Web.UI.WebControls.TextBox)c;
                        ctrl.Enabled = false;
                    }
                }
            }
            else
            {
                Response.Write(CR + "<table width=\"100%\" cellpadding=\"3\" cellspacing=\"0\" border=\"0\" class=\"tableWrapper\">"

                    + CR + " <tr>"
                    + CR + "  <td class=\"rowWrapper\" width=\"50%\"><font class=\"tableFont\">You've Added The Item(s) Below To Your Cart</td>"
                    //+ CR + "  <td class=\"rowWrapper\"><font class=\"tableFont\">Quantity</td>"
                    + CR + "  <td class=\"rowWrapper\"><font class=\"tableFont\">Unit Price</td>"
                    + CR + "  <td class=\"rowWrapper\"><font class=\"tableFont\">Total Price</td>"
                    + CR + "  <td>&nbsp;</td>"
                    + CR + " </tr>" + CR
                    );

            }
			
			//Response.Write(cart.CartItems.Length > 0);
			//Response.Write(Request.QueryString.ToString());
			//return;
			
			if(cart.CartItems.Length > 0)
			{
				foreach(OTCShoppingCartItem item in cart.CartItems)
				{
					string memberShipString = "";
					OTCProduct prod = new OTCProduct(item.ProductID);
					if(item.ProductPrice * item.ItemCount != item.OrderPrice * item.ItemCount)
					{
						Response.Write("<tr><td>" + p.PromotionName + " " + p.PromotionDescription + "</td></tr>");
						Response.Write(" <tr>"
								+ CR + "  <td class=\"productInfo\">" + prod.ProductName + " " + memberShipString + "</td>"
								//+ CR + "  <td class=\"productInfo\">" + item.ItemCount + "</td>"
								+ CR + "  <td class=\"productInfoStrikeThrough\">" + item.ProductPrice.ToString("c") + "</td>"
								+ CR + "  <td class=\"productInfo\">" + (item.OrderPrice * item.ItemCount).ToString("c") + "</td>"
								+ CR + "  <td>[ <a href=\"CheckOut.aspx?" + Request.QueryString.ToString() + "&remove=" + item.ShoppingCartItemID + "\">remove</a> ]</td>"
								+ CR + " </tr>" + CR
								);
					}
					else 
					{
						Response.Write(" <tr>"
								+ CR + "  <td class=\"productInfo\">" + prod.ProductName + " " + memberShipString + "</td>"
								//+ CR + "  <td class=\"productInfo\">" + item.ItemCount + "</td>"
								+ CR + "  <td class=\"productInfo\">" + item.ProductPrice.ToString("c") + "</td>"
								+ CR + "  <td class=\"productInfo\">" + (item.ProductPrice * item.ItemCount).ToString("c") + "</td>"
								+ CR + "  <td>[ <a href=\"CheckOut.aspx?" + Request.QueryString.ToString() + "&remove=" + item.ShoppingCartItemID + "\">remove</a> ]</td>"
								+ CR + " </tr>" + CR
								);
					}
					try
					{
						if(prod.CategoryId == 21)
							this.m_googleTrackingCode = "UA-1185020-2";
						else 
							this.m_googleTrackingCode = "UA-1185020-1";
					}
					catch(Exception ex) {}
				}

                
			}

			Response.Write("</table>");

		}
		
		/// <summary>
		/// 
		/// </summary>
        /// 
        private void AddContinueShoppingLink()
        {
            string site =  m_site == "bm" ? "betterman" : "betterwoman";
            site = "/interceuticals/" + site + "/";

            Response.Write("<br><br><div align='center'>"
                + CR + "<a href='" + site + "content.aspx?CTF=otherproducts&a_menu=product&a_image=other&hide=W'>Continue Shopping</a>"
                + CR + "</div>" + CR);

        }

		public void BuildCartTotals()
		{	
			double promotionDiscount = 0.00;
			string promotionName     = "";
			
			if(Request.QueryString.ToString().IndexOf("PKY") > -1){
				OTCPromotion p = new OTCPromotion(Request.QueryString["PKY"]);
				promotionDiscount = p.PromotionDiscount;
				promotionName     = p.PromotionName;
			}
			
			OTCShoppingCart cart = new OTCShoppingCart(this.m_shoppingCartId);
			double transactionTotal = cart.CartTotal;// + Convert.ToDouble(this.ddShippingMethods.SelectedItem.Value));
			double discount         = transactionTotal * promotionDiscount;
			double productTotal     = discount> 0 ? (transactionTotal - discount) : transactionTotal;
			double shippingTotal    = getShippingCost(this.ddShippingMethods.SelectedItem.Value);
			double tax              = productTotal * this.m_salesTax;
			double total            = (productTotal + tax) + shippingTotal;
			
			Response.Write("<input type=\"hidden\" value=\"" + cart.CartTotal + "\" id=\"cartTotal\">"
					+ CR + "<table border=\"0\">"
					+ CR + " <tr>"
					+ CR + "  <td>SubTotal: </td>"
					+ CR + "  <td><b>" + cart.CartTotal.ToString("c") + "</td>"
					+ CR + " </tr>"
					+ CR + " <tr>"
					+ CR + "  <td>Shipping: </td>"
					+ CR + "  <td><b><span id=\"shippingTotal\">" + shippingTotal.ToString("c") + "</span></td>"
					+ CR + " </tr>"
					+ CR + " <tr class=\"tax\">"
					+ CR + "  <td>Tax: </td>"
					+ CR + "  <td>6.25% for MA Residents</td>"
					+ CR + " </tr>"
					);
			
			if(promotionDiscount > 0)
				Response.Write(" <tr>"
						+ CR + "  <td>Promotion Discount: </td>"
						+ CR + "  <td>" + promotionDiscount.ToString("p") + "</td>"
						+ CR + " </tr>"
						);
			
			this.m_orderTotal = total;
			
			Response.Write(" <tr>"
					+ CR + "  <td>Total: </td>"
					+ CR + "  <td><b><font color=\"red\"><span id=\"total\">" + total.ToString("c") + "</span></td>"
					+ CR + " </tr>"
					+ CR + "</table>" + CR
					);
		}
		
		
		/// <summary>
		///  Need to fix this
		/// </summary>
		/// <returns></returns>
		private double getOrderTotal()
		{
			double promotionDiscount = 0.0;
			string promotionName     = "";
			
			if(Request.QueryString.ToString().IndexOf("PKY") > -1){
				OTCPromotion p = new OTCPromotion(Request.QueryString["PKY"]);
				promotionDiscount = p.PromotionDiscount;
				promotionName     = p.PromotionName;
			}
			OTCShoppingCart cart = new OTCShoppingCart(this.m_shoppingCartId);
			double transactionTotal = cart.CartTotal;// + Convert.ToDouble(this.ddShippingMethods.SelectedItem.Value));
			double discount         = transactionTotal * promotionDiscount;
			double productTotal     = discount> 0 ? (transactionTotal - discount) : transactionTotal;
			double shippingTotal    = Convert.ToDouble(this.ddShippingMethods.SelectedItem.Value);
			double tax              = productTotal * this.m_salesTax;
			double total            = (productTotal + tax) + shippingTotal;
			return(total);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private double getShippingRate()
		{
			OTCShoppingCart cart = new OTCShoppingCart(this.m_shoppingCartId);
			//Response.Write(cart.CartTotal);
			double shippingRate = 0.00;
			double orderTotal   = cart.CartTotal;
			if(orderTotal < 50)
				shippingRate = 7.99;
			else if(orderTotal > 50 && orderTotal < 100)
				shippingRate = 10.99;
			else if(orderTotal > 100 && orderTotal < 200)
				shippingRate = 12.99;
			else
				shippingRate = 14.99;
			return(shippingRate);
		}

        private double getShippingCost(string shippingMethod)
        {
            double rate = getShippingRate();

            switch (shippingMethod)
            {
                case "US":
                    return rate;
                case "USRUSH":
                    return rate + 9.99;
                case "CA":
                    return rate + 5.00;
                case "IT":
                    return 30.99;
            }

            return 0.00;
        }
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string buildShippingOptions()
		{
			return "";
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
			this.ddShippingMethods.SelectedIndexChanged += new System.EventHandler(this.ddShippingMethods_SelectedIndexChanged);
            this.btnCheckout.Click +=new EventHandler(btnCheckout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// 
		/// </summary>
		private bool doValidate()
		{

            Boolean isValid = true;
            String msgHeader = "Please correct the following errors: <br>";
            String msgCountry = " * Select a country <br>";
            String msgShippingCountry = " * Select a shipping country <br>";
            String msgShippingMethod = " * Select a shipping method <br>";
            String msgCCType = " * Select a credit card type <br>";
            String msgCCMonth = " * Select a credit card year <br>";
            String msgCCYear = " * Select a credit card month <br>";
            String msgCCCorrectShipping = " * Select correct shipping method <br>";
            String msgCorrectState = " * Select correct state <br>";
            String msgCorrectShippingState = " * Select correct shipping state <br>";

            String msg = msgHeader;

            if (!Page.IsValid)
                msg += " * Personal and Shipping information fields missing values <br>";

			if(this.ddCountry.SelectedIndex == 0)
			{
                msg += msgCountry;
				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(this.ddShippingCountry.SelectedIndex == 0)
			{
                msg += msgShippingCountry;

				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(this.ddShippingMethods.SelectedIndex == -1)
			{
                msg += msgShippingMethod;

				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(this.ddCCType.SelectedIndex == 0)
			{
                msg += msgCCType;
				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(this.ddMonth.SelectedIndex == 0)
			{
                msg += msgCCMonth;
				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(this.ddYear.SelectedIndex == 0)
			{
                msg += msgCCYear;
				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;
			}
			
			if(!this.validateShipping())
			{
                msg += msgCCCorrectShipping;
				this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
				this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                this.lblErrorMessage.Focus();
                isValid = false;
			}

            if (!this.validateStateOrProvince())
            {
                msg += msgCorrectState;
                this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
                this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;

            }

            if (!this.validateShipStateOrProvince())
            {
                msg += msgCorrectShippingState;
                this.lblErrorMessage.Visible = true;
                this.lblErrorMessage.Text = msg;
                this.lblErrorMessage2.Visible = true;
                this.lblErrorMessage2.Text = msg;
                isValid = false;

            }

            msg += "<br>";
			return(isValid);
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool validateShipping()
		{
			int unitedStates = 222;
			int canada       = 126;
			if(this.ddShippingCountry.SelectedValue == unitedStates.ToString()){
				return (true);
			}
			
			if(this.ddShippingCountry.SelectedValue == canada.ToString()){
				if(this.ddShippingMethods.SelectedValue == "CA")
					return (true);
			}
			
			if((this.ddShippingCountry.SelectedValue != unitedStates.ToString()) && (this.ddShippingCountry.SelectedValue != canada.ToString())){
				if(this.ddShippingMethods.SelectedValue == "IT")
					return (true);
			}
			return(false);
		}

        private bool validateStateOrProvince()
        {
            bool isValid = true;

            if (this.ddCountry.SelectedValue == "United States")
                isValid = this.ddState.SelectedValue != "" ? true : false;

            return isValid;
        }

        private bool validateShipStateOrProvince()
        {
            bool isValid = true;

            if (this.ddShippingCountry.SelectedItem.Text == "United States")
                isValid = this.ddStateShip.SelectedValue != "" ? true : false;

            return isValid;
        }


		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// 

        private void updateShoppingCart()
        {
            this.m_db.Open();

            int newProdID = getCorrectProductID();

            String updateSQL = "UPDATE ShoppingCartItem SET ProductId = ";
            updateSQL += newProdID;
            updateSQL += " WHERE ShoppingCartId = ";
            updateSQL += m_shoppingCartId;
            updateSQL += " AND ProductId = ";
            updateSQL += m_productID;

            m_db.SendSQLUpdate(updateSQL);
            
            this.m_db.ReleaseConnection();
        }

        private void swapProduct(string type, int productID)
        {
            this.m_db.Open();

            int newProdID = getRegionProductID(type, productID);

            String updateSQL = "UPDATE ShoppingCartItem SET ProductId = ";
            updateSQL += newProdID;
            updateSQL += " WHERE ShoppingCartId = ";
            updateSQL += m_shoppingCartId;
            updateSQL += " AND ProductId = ";
            updateSQL += productID;

            m_db.SendSQLUpdate(updateSQL);

            this.m_db.ReleaseConnection();
        }

        private int getCorrectProductID()
        {
            int productID;
            string sql = "SELECT * FROM  OTCProductRelationship WHERE OTCParentProductId = " + m_productID;
            
            DataTable dt = this.m_db.GetDataset(sql).Tables[0];
            
            if (!(dt.Rows.Count > 0))
                return (m_productID);
            else
            {
                productID = Convert.ToInt32(dt.Rows[0]["OTCSubordinateProductID"]);
                return (productID);
            }
        }

        private int getRegionProductID(string type, int productID)
        {
            string sql = "SELECT * FROM  OTCProductRegionRelationship WHERE OTCParentProductId = " + productID;
            
            DataTable dt = this.m_db.GetDataset(sql).Tables[0];
            
            if (!(dt.Rows.Count > 0)) return (productID);
            else return Convert.ToInt32(dt.Rows[0]["OTC" + type + "ProductID"]);
            
        }

        private Boolean isInternationalAutoShip()
        {
            if ((ddShippingCountry.SelectedValue != "222" && ddShippingCountry.SelectedValue != "126")  && (Convert.ToBoolean(Session["wantsMembership"])))
                return true;
            else
                return false;
        }

        private Boolean isCanadianAutoShip()
        {
            if ((ddShippingCountry.SelectedValue == "126") && (Convert.ToBoolean(Session["wantsMembership"])))
                return true;
            else
                return false;
        }

        private string getShippingStateOrProvince()
        {
            string province = this.txtShippingStateProvince.Text;
            string state = this.ddStateShip.SelectedIndex > 0 ? this.ddStateShip.SelectedItem.Text : "";

            if (!String.IsNullOrEmpty(province))
                return province;
            else
                return state;

        }

        private string getBillingStateOrProvince()
        {
            string province = this.txtStateProvince.Text;
            string state = this.ddState.SelectedIndex > 0 ? this.ddState.SelectedItem.Text : "";

            if (!String.IsNullOrEmpty(province))
                return province;
            else
                return state;
        }


		protected void btnCheckout_Click(object sender, System.EventArgs e)
		{
			
			if(!(doValidate()))
				return;
				
            			
			int sessionOrderId = Convert.ToInt32(Session["SID"]);
			ITC itc = new ITC();	
			OTCShoppingCart cart	= new OTCShoppingCart(this.m_shoppingCartId);

            string promotionKey = Request.Form["promotion"].Length > 0 ? Request.Form["promotion"] : "";
            if (promotionKey.Length > 0)
            {
                //If we have a promotion, apply here & the next instance will recognize it. We could 
                //have a function that would reload the shopping cart? This is much easier for the sake of time.
                cart.ApplyPromotion(promotionKey, this.m_shoppingCartId);
            }

            //BG - Added swap product sku for international and canadian
		    string shippingType = String.Empty;
            if (isInternationalAutoShip()) shippingType = "International";
            else if (isCanadianAutoShip()) shippingType = "Canadian";

            if (!String.IsNullOrEmpty(shippingType))
            {
                foreach (var item in cart.CartItems) swapProduct(shippingType, item.ProductID);
            }

            //refresh cart
            cart = new OTCShoppingCart(this.m_shoppingCartId);


			OTCSalesOrder order		= new OTCSalesOrder();
			order.ShoppingCartId    = cart.ShoppingCartID;
			order.OTCPromotionId    = cart.OTCPromotionId;
			order.Address			= this.txtAddress.Text;
			order.City				= this.txtCity.Text;
			order.Country           = this.ddCountry.SelectedItem.Text;
			order.EmailAddress		= this.txtEmailAddress.Text;
			order.FirstName			= this.txtFirstName.Text;
			order.LastName			= this.txtLastName.Text;
			order.Phone             = this.txtPhone.Text;
			order.OrderCost			= cart.CartTotal;
			order.SalesTax          = this.m_salesTax;
			order.OTCSiteId			= itc.SiteId;
			order.ShippingAddress	= this.txtShippingAddress.Text;
			order.ShippingCity		= this.txtShippingCity.Text;
			order.ShippingCost		= getShippingCost(this.ddShippingMethods.SelectedItem.Value);
			order.ShippingFirstName = this.txtShippingFirstName.Text;
			order.ShippingLastName	= this.txtShippingLastName.Text;
			//order.ShippingState		= this.txtShippingStateProvince.Text;
            order.ShippingState     = this.getShippingStateOrProvince();
			order.ShippingZip		= this.txtShippingZipPostalCode.Text; //bug fix
			//order.State				= this.ddState.SelectedIndex > 0 ? this.ddState.SelectedItem.Text : "";
            order.State             = this.getBillingStateOrProvince();
			order.ShippingPhone     = this.txtShippingPhone.Text;
			order.Zip				= this.txtZipPostalCode.Text;
			order.ShippingCountryId = Convert.ToInt32(this.ddShippingCountry.SelectedValue);
			order.ShippingCountry   = this.ddShippingCountry.SelectedItem.Text;
			order.ShippingMethod    = this.ddShippingMethods.SelectedItem.Text;
			order.ShippingEmailAddress = this.txtShippingEmailAddress.Text;
			order.Comments			= this.txtComments.Value.Length > 0 ? this.txtComments.Value : "";
			int id = order.Add();
			OTCCreditCard cc        = new OTCCreditCard();
			cc.OTCSalesOrderId      = order.OTCSalesOrderId;
			cc.OTCSiteMemberId      = order.OTCSiteMemberId;
			cc.CardNumber           = this.txtCardNumber.Text;
			cc.CardType             = this.ddCCType.SelectedValue;
			cc.ExpirationMonth      = this.ddMonth.SelectedValue;
			cc.ExpirationYear       = this.ddYear.SelectedValue;
			cc.IISSessionId         = Session.SessionID;
			cc.Add();


			if(Convert.ToBoolean(Session["WantsMemberShip"]))
			{
				OTCPromotion.AddMemberPromotion(order.OTCSiteMemberId,1);
			}
			
			//if(this.txtComments.Value.Length > 0)
			//{
			//	OTCContact contact = new OTCContact();
			//	contact.SiteId = 7;
			//	contact.EmailAddress = this.txtEmailAddress.Text;
			//	contact.FirstName = this.txtFirstName.Text;
			//	contact.LastName = this.txtLastName.Text;
			//	contact.Comment1 = this.txtComments.Value;
			//	contact.Add();
			//}
			
			try
			{
				string sql = "";
				this.m_db.Open();
				string howDidYouHear = Request.Form["txtHowDidYouHear"];
				
				if(howDidYouHear.Length > 0)
				{
					sql = "spInsertOTCSiteMemberQuestionAnswerAffiliation "
						+ "@OTCSiteMemberId = " + order.OTCSiteMemberId + ","
						+ "@OTCSiteMemberQuestionId = 1,"
						+ "@OTCSiteMemberAnswerID = 1,"
						+ "@AnswerText = " + OTCDatabase.SqlFormat(howDidYouHear)
						;
					this.m_db.SendSQLUpdate(sql);
				}
				
				foreach(string s in Request.Form.ToString().Split('&')){
					if(s.IndexOf("mq_") > -1){
						int questionId = Convert.ToInt32(s.Split('=')[0].Replace("mq_",""));
						int answerId   = Convert.ToInt32(s.Split('=')[1]);
						sql = "spInsertOTCSiteMemberQuestionAnswerAffiliation "
							+ "@OTCSiteMemberId = " + order.OTCSiteMemberId + ","
							+ "@OTCSiteMemberQuestionId = " + questionId + ","
							+ "@OTCSiteMemberAnswerID = " + answerId
							;
						this.m_db.SendSQLUpdate(sql);
					}
				}


			    sql = "spUpdateCartAbandonmentOrderID @sessionId = " + OTCDatabase.SqlFormat(Session.SessionID);
			    sql += ",@cartId = " + cart.ShoppingCartID;
			    sql += ",@OrderId = " + order.OTCSalesOrderId;
                this.m_db.SendSQLUpdate(sql);

				this.m_db.ReleaseConnection();
			}
			
			catch(Exception ex) {/*do nothing*/}
			OTCEncryption crypt = new OTCEncryption(7);
			cart = new OTCShoppingCart(Session.SessionID);	
			Session["shoppingCartId"]   = cart.AddNew();
            
            
			Session["SID"] = 0;

            if (Page.IsValid)
            {
                Session["SessionID"] = Session.SessionID;
                Response.Redirect("../order/creditcardpost.aspx?OID=" + id.ToString() + "&_ga=" + Request.QueryString["_ga"] + "&site=" + Request.QueryString["site"]);

            }

		}


		private void ddShippingMethods_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

        protected void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            //HttpCookie aCookie = new HttpCookie("userInfo");
            //aCookie.Values["userFirstName"] = this.txtFirstName.Text;
            //aCookie.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Add(aCookie);
        }

	    protected void Country_Changed(object sender, System.EventArgs e)
	    {
	        ddState.Visible = false;
	    }
	}
}
