using System;
using System.Data;
using System.Collections;
using OTC.Database;

namespace Interceuticals.Common.Classes
{
	public class ITCPromotion
	{
		private int		 m_otcPromotionId;
		private int		 m_usageCount;
		private bool	 m_isActive;
		private bool	 m_isMultyUse;
		private bool     m_hasProducts;
		private double   m_discountAmount;
		private double	 m_discountPercentage;
		private double	 m_minimumPurchaseAmount;
		private string	 m_promotionName;
		private string 	 m_promotionDescription;
		private string	 m_promotionKey;
		private DateTime m_startDate;
		private DateTime m_endDate;
		private DateTime m_createdDttm;
		private ArrayList   m_products = new ArrayList();
		private OTCDatabase m_db    = new OTCDatabase();
		
		public int		OTCPromotionId			{get{return(this.m_otcPromotionId );}		 set{this.m_otcPromotionId = value;}}
		public int		UsageCount				{get{return(this.m_usageCount );}			 set{this.m_usageCount = value;}}
		public bool		IsActive				{get{return(this.m_isActive );}				 set{this.m_isActive = value;}}
		public bool		IsMultyUse				{get{return(this.m_isMultyUse );}			 set{this.m_isMultyUse = value;}}
		public bool		HasProducts				{get{return(this.m_hasProducts );}}
		public double	DiscountAmount			{get{return(this.m_discountAmount );}		 set{this.m_discountAmount = value;}}
		public double	DiscountPercentage		{get{return(this.m_discountPercentage );}	 set{this.m_discountPercentage = value;}}
		public double	MinimumPurchaseAmount	{get{return(this.m_minimumPurchaseAmount );} set{this.m_minimumPurchaseAmount = value;}}
		public string	PromotionName			{get{return(this.m_promotionName );}		 set{this.m_promotionName = value;}}
		public string 	PromotionDescription	{get{return(this.m_promotionDescription );}  set{this.m_promotionDescription = value;}}
		public string	PromotionKey			{get{return(this.m_promotionKey );}			 set{this.m_promotionKey = value;}}
		public DateTime StartDate				{get{return(this.m_startDate );}			 set{this.m_startDate = value;}}
		public DateTime EndDate					{get{return(this.m_endDate );}				 set{this.m_endDate = value;}}
		public DateTime CreatedDttm				{get{return(this.m_createdDttm );}			 set{this.m_createdDttm = value;}}
		
		/// <summary>
		/// 
		/// </summary>
		public ITCPromotion()
		{
		
		}
		public ITCPromotion(int otcPromotionId)
		{
			this.m_otcPromotionId = otcPromotionId;
			string sql = "spGetOTCPromotion @OTCPromotionId = " + this.m_otcPromotionId;
			this.m_db.Open();
			DataTable dt = this.m_db.GetDataset(sql).Tables[0];
			DataTable dtProducts = this.m_db.GetDataset("spGetOTCProductByPromotion @OTCPromotionID = " + otcPromotionId).Tables[0];
			this.m_db.ReleaseConnection();	
			if(dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				this.m_otcPromotionId		 = (int)dr["OTCPromotionId"];
				this.m_usageCount			 = (int)dr["UsageCount"];
				this.m_discountAmount		 = Convert.ToDouble(dr["DiscountAmount"]);
				this.m_isActive				 = Convert.ToBoolean(dr["IsActive"]);
				this.m_isMultyUse			 = Convert.ToBoolean(dr["IsMultyUse"]);
				this.m_discountPercentage	 = Convert.ToDouble(dr["DiscountPercentage"]);
				this.m_minimumPurchaseAmount = Convert.ToDouble(dr["MinimumPurchaseAmount"]);
				this.m_promotionName		 = dr["PromotionName"].ToString();
				this.m_promotionDescription  = dr["PromotionDescription"].ToString();
				this.m_promotionKey			 = dr["PromotionKey"].ToString();
				this.m_startDate			 = Convert.ToDateTime(dr["StartDate"]);
				this.m_endDate				 = Convert.ToDateTime(dr["EndDate"]);
				this.m_createdDttm			 = Convert.ToDateTime(dr["CreatedDttm"]);
			}
			
			this.m_hasProducts = dtProducts.Rows.Count > 0;
			foreach(DataRow dr in dtProducts.Rows){
				if(!(this.m_products.Contains((int)dr["OTCProductId"]))){
					this.m_products.Add((int)dr["OTCProductId"]);
				}
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static DataTable GetProductAssociation(int otcPromotionId)
		{
			DataTable dt   = new DataTable();
			OTCDatabase db = new OTCDatabase();
			db.Open();
			dt = db.GetDataset("spGetOTCProductByPromotion @OTCPromotionID = " + otcPromotionId).Tables[0];
			db.ReleaseConnection();
			return(dt);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int Add()
		{
			return(this.doAdd());
		}
		private int doAdd()
		{
			string sql  = "spInsertOTCPromotion "
					    + "@PromotionName = " + OTCDatabase.SqlFormat(this.m_promotionName) + ", "
					    + "@PromotionDescription = " + OTCDatabase.SqlFormat(this.m_promotionDescription) + ", "
						+ "@PromotionKey = " + OTCDatabase.SqlFormat(this.m_promotionKey) + ", "
						+ "@UsageCount = " + this.m_usageCount + ", "
						+ "@DiscountPercentage = " + this.m_discountPercentage + ", "
						+ "@DiscountAmount = " + this.m_discountAmount + ", "
						+ "@IsActive = " + OTCDatabase.SqlFormat(this.m_isActive) + ", "
						+ "@isMultyUse = " + OTCDatabase.SqlFormat(this.m_isMultyUse) + ", "
						+ "@minimumPurchaseAmount = " + this.m_minimumPurchaseAmount + ", "
						+ "@StartDate = " + OTCDatabase.SqlFormat(this.m_startDate.ToShortDateString()) + ", "
						+ "@EndDate = " + OTCDatabase.SqlFormat(this.m_endDate.ToShortDateString())
						;
			this.m_db.Open();
			int id = this.m_db.IndentityInsert(sql);
			
			for(int i=0;i<this.m_products.Count;i++)
			{
				sql = "spInsertOTCPromotionProductAffiliation "
					+ "@OTCPromotionId = " + id + ","
					+ "@OTCProductId = " + Convert.ToInt32(this.m_products[i])
					;
				this.m_db.SendSQLUpdate(sql);
			}
			this.m_db.ReleaseConnection();
			
			return(id);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public void Save()
		{
			this.doSave();
		}
		private void doSave()
		{
			string sql  = "spInsertOTCPromotion "
						+ "@OTCPromotionId = " + this.m_otcPromotionId + "," 
						+ "@PromotionName = " + OTCDatabase.SqlFormat(this.m_promotionName) + ", "
						+ "@PromotionDescription = " + OTCDatabase.SqlFormat(this.m_promotionDescription) + ", "
						+ "@PromotionKey = " + OTCDatabase.SqlFormat(this.m_promotionKey) + ", "
						+ "@UsageCount = " + this.m_usageCount + ", "
						+ "@DiscountPercentage = " + this.m_discountPercentage + ", "
						+ "@DiscountAmount = " + this.m_discountAmount + ", "
						+ "@IsActive = " + OTCDatabase.SqlFormat(this.m_isActive) + ", "
						+ "@isMultyUse = " + OTCDatabase.SqlFormat(this.m_isMultyUse) + ", "
						+ "@minimumPurchaseAmount = " + this.m_minimumPurchaseAmount + ", "
						+ "@StartDate = " + OTCDatabase.SqlFormat(this.m_startDate.ToShortDateString()) + ", "
						+ "@EndDate = " + OTCDatabase.SqlFormat(this.m_endDate.ToShortDateString())
						;
			this.m_db.Open();
			this.m_db.SendSQLUpdate(sql);
			for(int i=0;i<this.m_products.Count;i++){
				sql = "spInsertOTCPromotionProductAffiliation "
					+ "@OTCPromotionId = " + this.m_otcPromotionId + ","
					+ "@OTCProductId = " + Convert.ToInt32(this.m_products[i])
					;
				this.m_db.SendSQLUpdate(sql);
			}
			this.m_db.ReleaseConnection();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Delete()
		{
			return(this.doDelete());
		}
		private bool doDelete()
		{
			string sql = "spDeleteOTCPromotion @OTCPromotionId = " + this.m_otcPromotionId;
			this.m_db.Open();
			int i = Convert.ToInt32(this.m_db.ExecuteScalar(sql));
			this.m_db.ReleaseConnection();
			return(i>0);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void AddProductId(int productId)
		{
			if(!(this.m_products.Contains(productId)))
				if(productId > 0)
					this.m_products.Add(productId);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public bool HasProductAffiliation(int productId)
		{
			return(this.m_products.Contains(productId));
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void RemoveProductAffiliation()
		{
			this.m_db.Open();
			this.m_db.SendSQLUpdate("spDeleteOTCPromotionProductAffiliation @OTCPromotionId = " + this.m_otcPromotionId);
			this.m_db.ReleaseConnection();
			this.m_products.Clear();
		}
	}
}
