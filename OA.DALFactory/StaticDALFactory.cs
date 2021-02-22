using OA.EFDAL;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
    public class StaticDALFactory
    {
        public static IUserInfoDal GetUserInfoDal() {
            //return new UserInfoDal();//确认返回值
            //把new去掉改为通过更改配置就能创建变更的实例
            string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssembly"];
         return   Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;//抽象工厂
        }
        public static IOrderInfoDal GetOrderInfoDal()
        {
            return new OrderInfoDal(); //简单工厂
        }
        public static IActionInfoDal GetActionInfoDal()
        {
            return new ActionInfoDal(); //简单工厂
        }
        public static IR_UserInfo_ActionInfoDal GetR_UserInfo_ActionInfoDal()
        {
            return new R_UserInfo_ActionInfoDal(); //简单工厂
        }
        public static IRoleInfoDal GetRoleInfoDal()
        {
            return new RoleInfoDal(); //简单工厂
        }
        public static IUserInfoEXtDal GetUserInfoEXtDal()
        {
            return new UserInfoEXtDal(); //简单工厂
        }
        public static IWF_InstanceDal GetWF_InstanceDal()
        {
            return new WF_InstanceDal(); //简单工厂
        }
        public static IWF_StepDal GetWF_StepDal()
        {
            return new WF_StepDal(); //简单工厂
        }
        public static IWF_TempDal GetWF_TempDal()
        {
            return new WF_TempDal(); //简单工厂
        }
    }
}
