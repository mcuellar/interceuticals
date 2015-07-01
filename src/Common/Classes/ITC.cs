using System;
using System.Web;
using System.Data;
using System.Configuration;
using OTC.Database;

namespace Interceuticals.Common.Classes
{
	public class ITC
	{
		public OTCDatabase db;
		private int m_siteId; 
		private HttpResponse Response = HttpContext.Current.Response;
		
		public int SiteId {get{return(this.m_siteId);}}	
		/// <summary>
		/// 
		/// </summary>
		public ITC()
		{
			this.db = new OTCDatabase();
			this.m_siteId = Convert.ToInt32(ConfigurationManager.AppSettings["applicationId"]);
		}
	}
}
