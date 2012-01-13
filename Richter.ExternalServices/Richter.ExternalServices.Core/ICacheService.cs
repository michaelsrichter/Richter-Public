using System;

namespace Richter.ExternalServices.Core
{
    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback) where T : class;
        void Update(string cacheId, object item);
    }
}