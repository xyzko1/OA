using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MencacheDemo//通过客户端驱动实现集群
{
    class Program
    {
        static void Main(string[] args)
        {
                //string[] serverlist = { "192.168.0.110:11211" }; //服务器列表，可多个,局域网地址 
            string[] serverlist = { "127.0.0.1:11211" };//本机地址
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

            MemcachedClient mc = new MemcachedClient();//初始化一个客户端 
            mc.EnableCompression = false;

            mc.Add("key2","123");
        }
    }
}
