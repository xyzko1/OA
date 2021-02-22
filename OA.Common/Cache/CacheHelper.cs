using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common.Cache
{
   public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static  CacheHelper()
        {
            //通过容器创建一个对象
            IApplicationContext ctx = ContextRegistry.GetContext();
            CacheHelper.CacheWriter = ctx.GetObject("cacheWriter") as ICacheWriter;
        }
        public static void AddCache(string key, object value, DateTime expdate)
        {
            CacheWriter.AddCache(key, value, expdate);
        }
        public static void AddCache(string key, object value) {
            CacheWriter.AddCache(key, value);
        }
        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }
        public static void SetCache(string key, object value, DateTime expdate)
        {
            CacheWriter.SetCache(key, value, expdate);
        }
        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }
    }
}
