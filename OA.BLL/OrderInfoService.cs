using OA.DALFactory;
using OA.EFDAL;
using OA.IBLL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    //模块内高内聚，模块间低耦合
    //变化点：1、跨数据库
    //    2、数据库访问驱动层驱动变化
    public partial class OrderInfoService : BaseService<OrderInfo>, IOrderInfoService
    {
        //UserInfoDal userInfoDal = new UserInfoDal();//一般New对象
        //IUserInfoDal userInfoDal = new UserInfoDal();//简单工厂，依赖接口编程,需更改New后实例
        //private IOrderInfoDal orderInfoDal = StaticDALFactory.GetOrderInfoDal();
        public OrderInfoService()
        {

        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.OrderInfoDal;
        }
    }
}
