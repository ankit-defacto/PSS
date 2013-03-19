
namespace PSS.WebWithAuth.Caching
{
    using System;
    using System.Web.Caching;
    using System.Web;

    /// <summary>
    /// Cache manager class
    /// </summary>
    public class CacheManager
    {
        // using old httpcontext cache class (memory cache has bugs)
        private static Cache cache = HttpContext.Current.Cache;

        public static T Retrieve<T>(string key)
        {
            if (CacheConfig.CachingEnabled)
            {
                var cached1 = (T)cache[key];
                if (cached1 != null)
                {
                    return cached1;
                }
            }

            return default(T);
        }

        public static void Put<T>(string key, T item)
        {
            Insert(key, item, CacheConfig.ExpirationDate);
        }

        public static void Put<T>(string key, T item, DateTime expiration)
        {
            Insert(key, item, expiration);
        }

        public static void PutSliding<T>(string key, T item)
        {
            PutSliding<T>(key, item, CacheConfig.ExpirationDate);
        }

        public static void PutSliding<T>(string key, T item, DateTime expiration)
        {
            if (CacheConfig.SlidingExpirationTime <= 0 || CacheConfig.SlidingExpirationTime == int.MaxValue)
            {
                Put<T>(key, item);
            }
            else
            {
                Insert(key, item, expiration, new TimeSpan(0, 0, CacheConfig.SlidingExpirationTime));
            }
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        private static void Insert(string key, object item, DateTime expiration)
        {
            cache.Insert(key, item, null, expiration, Cache.NoSlidingExpiration);
        }

        private static void Insert(string key, object item, DateTime expiration, TimeSpan expirationSliding)
        {
            cache.Insert(key, item, null, expiration, expirationSliding);
        }
    }
}