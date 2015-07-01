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
using OTC.Web;
using OTC.Web.Controls;

namespace Interceuticals.Admin.Reports
{
	public class Orders : System.Web.UI.Page
	{
		OTCDatabase m_db = new OTCDatabase();
		private DateTime m_startDate;
		private DateTime m_endDate;
		protected System.Web.UI.WebControls.Calendar cldStartDate;
		protected System.Web.UI.WebControls.Calendar cldEndDate;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button btnOrderId;
        protected System.Web.UI.WebControls.Label lblVoidMessage;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		public ITCPage m_page;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.m_page = new ITCPage();
			this.m_page.HideWest = true;
            lblVoidMessage.Text = "";

            if (!Page.IsPostBack)
            {

                //this.m_startDate = cldStartDate.SelectedDate = cldStartDate.VisibleDate = System.DateTime.Now;
                //this.m_endDate = cldEndDate.SelectedDate = cldEndDate.VisibleDate = System.DateTime.Now.AddDays(1);

                //if (Request.QueryString.ToString().IndexOf("EDT") > -1)
                //    this.m_endDate = Convert.ToDateTime(Request.QueryString["EDT"]);

                //if (Request.QueryString.ToString().IndexOf("STD") > -1)
                //    this.m_startDate = Convert.ToDateTime(Request.QueryString["STD"]);


                //TODO: To be deployed for VOID functionality - MC

                if (Request.QueryString.ToString().IndexOf("EDT") > -1)
                    this.m_endDate = Convert.ToDateTime(Request.QueryString["EDT"]);

                if (Request.QueryString.ToString().IndexOf("STD") > -1)
                    this.m_startDate = Convert.ToDateTime(Request.QueryString["STD"]);

                // Mark order transaction as void
                if ((Request.QueryString.ToString().IndexOf("ISVOID") > -1) && (Request.QueryString.ToString().IndexOf("VID") > -1))
                    ProcessVoid();
            }

            //Todo: To Be Deployed for Void functionality - MC

            if (Session["StartDate"] == null)
                this.m_startDate = cldStartDate.SelectedDate = cldStartDate.VisibleDate = System.DateTime.Now;
            else
                this.m_startDate = Convert.ToDateTime(Session["StartDate"]);


            if (Session["EndDate"] == null)
            {
                this.m_endDate = cldEndDate.SelectedDate = cldEndDate.VisibleDate = System.DateTime.Now.AddDays(1);
                initSessionVariables();
            }
            else
                this.m_endDate = Convert.ToDateTime(Session["EndDate"]);


            
		}

        private void ProcessVoid()
        {
            int orderID = Convert.ToInt32(Request.QueryString["OID"]);
            string isVoid = Request.QueryString["ISVOID"].ToString() == "Yes" ? "1" : "0";
            string verisignID = Request.QueryString["VID"].ToString();


            if (!IsSRSProcessed(orderID))
                UpdateSalesOrder(orderID, verisignID, isVoid);
            else
            {
                lblVoidMessage.ForeColor = Color.Red;
                lblVoidMessage.Text = "Cannot change void status. Order " + orderID.ToString() + " has already been sent out to fullfillment company.";
            }
        }
		
		/// <summary>	
		/// 
		/// </summary>
		public void ShowOrders()
		{
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset("spGetOTCSalesOrders @startDate = '" + this.m_startDate.ToShortDateString() + "', @endDate = '" + this.m_endDate.ToShortDateString() + "'").Tables[0];
			//this.m_db.ReleaseConnection();
			OTCGrid grid = new OTCGrid(dt);
			grid.HyperLink = "STD=" + this.m_startDate.ToShortDateString() + "&EDT=" + this.m_endDate.ToShortDateString();
			OTCGridLink link = new OTCGridLink();
			link.LinkKey = "OID";
			link.ColumnName = "Dogz Togz Order Id";
			link.LinkText = "Interceuticals Order Id";
			link.LinkHref = "order.aspx";
			grid.AddLinkColumn(link);
			
			link = new OTCGridLink();
			link.LinkKey = "OID";
			link.ColumnName = "Verisign Order Id";
			link.LinkText = "Verisign Order Id";
			link.LinkHref = "order.aspx";
            grid.AddLinkColumn(link);

            grid.DisplayRecordCount = true;
            grid.Draw();

		}

        private void UpdateSalesOrder(int orderID, string verisignID, string isVoid)
        {
            try
            {
                this.m_db.Open();
                this.m_db.SendSQLUpdate("spUpdateVoidStatus  @salesOrderID = " + orderID + ", @veriSignID = '" + verisignID + "', @isVoid = '" + isVoid + "'");
                this.m_db.ReleaseConnection();
            }
            catch (Exception ex)
            {
                Response.Write("Error in UpdateSalesOrder(): " + ex.Message);
            }

        }

        private void initSessionVariables()
        {
            Session["StartDate"] =  this.m_startDate;
            Session["EndDate"] = this.m_endDate;
        }

        private bool IsSRSProcessed(int orderID)
        {
            string sql = "SELECT SRSDate, SRSProcessed from OTCSalesOrder WHERE OTCSalesOrderID = " + orderID;
            bool result = false;
            string SRSDate;
            string isProcessed = "0";
            

            try
            {
                this.m_db.Open();
                DataTable dt = this.m_db.GetDataset(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    SRSDate = Convert.ToString(dt.Rows[0]["SRSDate"]);
                    isProcessed = Convert.ToString(dt.Rows[0]["SRSProcessed"]);

                    if (isProcessed == "1")
                        result = true;

                }

                this.m_db.ReleaseConnection();

            }
            catch (Exception ex)
            {
                Response.Write("Error in IsSRSProcessed(): " + ex.Message);
            }

            return result;
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
			this.cldStartDate.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.setFirstDayOfMonth);
			this.cldStartDate.SelectionChanged += new System.EventHandler(this.cldStartDate_SelectionChanged);
			this.cldEndDate.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.setFirstDayForMonth);
			this.cldEndDate.SelectionChanged += new System.EventHandler(this.cldEndDate_SelectionChanged);
			this.btnOrderId.Click += new System.EventHandler(this.btnOrderId_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cldStartDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.m_startDate = this.cldStartDate.SelectedDate;
			//this.m_endDate   = this.cldEndDate.SelectedDate;

            //TODO: For Void functionality.  Comment out this.m_endDate.
            initSessionVariables();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cldEndDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.m_startDate = this.cldStartDate.SelectedDate;
			this.m_endDate   = this.cldEndDate.SelectedDate;
            
            //TODO: For VOID functionality
            initSessionVariables();
		}

		private void btnOrderId_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("order.aspx?OID=" + this.TextBox1.Text);
		}

		private void setFirstDayOfMonth(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
		{
			this.m_startDate = this.cldStartDate.SelectedDate;
			this.m_endDate   = this.cldEndDate.SelectedDate;
		}

		private void setFirstDayForMonth(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
		{
			this.m_startDate = this.cldStartDate.SelectedDate;
			this.m_endDate   = this.cldEndDate.SelectedDate;
		}
	}
}
