using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Configuration;

namespace Interceuticals.Cache
{
    public static class CacheManager
    {

        private static double cacheExpireMinutes = Convert.ToDouble(ConfigurationManager.AppSettings["cacheExpireMinutes"]);

        public static void AddToCache(string cacheKey, object cachedObject)
        {
            if (hasHttpContext())
            {
                if (!isCached(cacheKey))
                {
                    HttpContext.Current.Cache.Add(cacheKey,
                    cachedObject, null,
                    getExpirationTime(cacheExpireMinutes),
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    CacheItemPriority.Default, null);
                }

            }
            else
                throw new Exception("Error: Unable to add to Cache due to a NULL HttpContext.Current. Cache Key = " + cacheKey);
        }

        public static void RemoveFromCache(string cacheKey)
        {
            if (hasHttpContext())
            {
                if (HttpContext.Current.Cache[cacheKey] != null)
                    HttpContext.Current.Cache.Remove(cacheKey);
            }

        }

        private static bool isCached(string cacheKey)
        {
            if (hasHttpContext())
                return HttpContext.Current.Cache[cacheKey] != null ? true : false;
            else
                return false;
        }

        public static object GetFromCache(string cacheKey)
        {
            if (isCached(cacheKey))
                return HttpContext.Current.Cache[cacheKey];
            else
                return null;

        }

        private static bool hasHttpContext()
        {
            return HttpContext.Current != null ? true : false;
        }

        private static DateTime getExpirationTime(double minutes)
        {
            return DateTime.Now.AddMinutes(minutes);
        }
    }
}