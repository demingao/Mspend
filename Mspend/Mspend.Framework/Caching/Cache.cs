/* =======================================================================
* create by kikao
* 2016/4/16 15:19:38
* @version 1.0
* =======================================================================*/

using System;
using System.Collections.Concurrent;

namespace Mspend.Framework.Caching
{
    public class Cache<TKey, TResult> : ICache<TKey, TResult>
    {
        private readonly ConcurrentDictionary<TKey, TResult> _caches;

        public Cache()
        {
            _caches = new ConcurrentDictionary<TKey, TResult>();
        }

        public TResult Get(TKey key, Func<TKey, TResult> func, TimeSpan? expiredTime = null)
        {
            var result = _caches.GetOrAdd(key, func);
            return result;
        }


        public TResult Remove(TKey key)
        {
            TResult result;
            if (_caches.TryRemove(key, out result))
                return result;
            return default(TResult);
        }
    }
}
