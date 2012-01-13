using System;
using System.Web;

namespace Richter.ExternalServices.Core
{
    public class InMemoryCache : ICacheService
    {
        #region ICacheService Members

        public T Get<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                if (item != null) HttpContext.Current.Cache.Insert(cacheId, item);
            }
            return item;
        }

        public void Update(string cacheId, object item)
        {
            if (HttpContext.Current.Cache.Get(cacheId) != null) HttpContext.Current.Cache.Remove(cacheId);
            HttpContext.Current.Cache.Insert(cacheId, item);
        }

        #endregion
    }
}