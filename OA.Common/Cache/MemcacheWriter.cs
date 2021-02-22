using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common.Cache
{
    public class MemcacheWriter : ICacheWriter
    {
        private MemcachedClient memcachedClient;
        public MemcacheWriter()
        {
            //string[] serverlist = { "192.168.0.110:11211" }; //服务器列表，可多个，写到配置文件         
            string[] serverlist = System.Configuration.ConfigurationManager.AppSettings["MemcacheServerList"].Split(',');
            SockIOPool pool = SockIOPool.GetInstance();

            //根据实际情况修改下面参数
            pool.SetServers(serverlist);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize(); // initialize the pool for memcache servers           

            memcachedClient = new MemcachedClient();//初始化一个客户端 
            memcachedClient.EnableCompression = false;

        }
        public void AddCache(string key, object value, DateTime expdate)
        {
            memcachedClient.Add(key, value, expdate);
        }

        public void AddCache(string key, object value)
        {
            memcachedClient.Add(key, value);
        }

        public object GetCache(string key)
        {
         return   memcachedClient.Get(key);
        }

        public T GetCache<T>(string key)
        {
            return (T)memcachedClient.Get(key);
        }

        public void SetCache(string key, object value, DateTime expdate)
        {
            memcachedClient.Set(key, value, expdate);
        }

        public void SetCache(string key, object value)
        {
            memcachedClient.Set(key, value);
        }
    }
}
