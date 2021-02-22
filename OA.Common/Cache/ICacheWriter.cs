using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common.Cache
{
    public interface ICacheWriter
    {
        void AddCache(string key, object value, DateTime expdate);
        void AddCache(string key, object value);
        object GetCache(string key);
        T GetCache<T>(string key);
        void SetCache(string key, object value, DateTime expdate);
        void SetCache(string key, object value);

    }
}
