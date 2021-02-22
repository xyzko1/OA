using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{
   public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext() {
            //一次请求共用一个实例,使用DbContext上下文可以切换
            //return new DataModelContainer();
            DbContext db= CallContext.GetData("DbContext") as DbContext;//保证数据线程唯一的数据槽
            if (db==null)
            {
                db= new DataModelContainer();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
