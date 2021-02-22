using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OA.Common.Cache
{
    public class HttpRuntimeCacheWriter : ICacheWriter
    {
        public void AddCache(string key, object value, DateTime expdate)
        {
            HttpRuntime.Cache.Insert(key, value, null,expdate,TimeSpan.Zero);
        }
        public void AddCache(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public object GetCache(string key)
        {
            return HttpRuntime.Cache[key];
        }

        public T GetCache<T>(string key)
        {
            return  (T)HttpRuntime.Cache[key];
        }

        public void SetCache(string key, object value, DateTime expdate)
        {
            HttpRuntime.Cache.Remove(key);
            AddCache(key, value, expdate);
        }

        public void SetCache(string key, object value)
        {

            HttpRuntime.Cache.Remove(key);
            AddCache(key, value);
        }
    }
}
