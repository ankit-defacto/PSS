
namespace PSS.WebWithAuth.Caching
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Cache config class
    /// </summary>
    public static class CacheConfig
    {
        private static bool? _cachingEnabled;

        public static bool CachingEnabled
        {
            get
            {
                string keyStrVal = ConfigurationManager.AppSettings["CachingEnabled"] as string;
                if (!string.IsNullOrEmpty(keyStrVal))
                {
                    _cachingEnabled = keyStrVal.ToLower() == "true";
                }
                else
                {
                    _cachingEnabled = false;
                }
                
                return _cachingEnabled.GetValueOrDefault();
            }
            set
            {
                _cachingEnabled = value;
            }
        }

        private static int _slidingExpirationTime = 20;

        /// <summary>
        /// Sliding expiration time in seconds
        /// </summary>
        public static int SlidingExpirationTime
        {
            get
            {
                return _slidingExpirationTime;
            }
            set
            {
                _slidingExpirationTime = value;
            }
        }

        private static DateTime _expirationDate = DateTime.Now;

        public static DateTime ExpirationDate
        {
            get
            {
                if (DateTime.Compare(_expirationDate, DateTime.Now) <= 0)
                {
                    string keyStrVal = ConfigurationManager.AppSettings["CacheDuration"] as string;
                    if (!string.IsNullOrEmpty(keyStrVal))
                    {
                        double exdate = 0;
                        var b = double.TryParse(keyStrVal, out exdate);
                        if (exdate > 0)
                        {
                            _expirationDate = DateTime.Now.AddMinutes(double.Parse(keyStrVal));
                        }
                        else
                        {
                            _expirationDate = DateTime.Now.AddMinutes(10);
                        }
                    }
                }

                return _expirationDate;
            }

            set
            {
                _expirationDate = value;
            }
        }
    }
}