using OA.EFDAL;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
  public  class DbSession: IDbSession
    {
        public IUserInfoDal UserInfoDal {
            get {
                return StaticDALFactory.GetUserInfoDal();
            }
        }
        public IOrderInfoDal OrderInfoDal
        {
            get
            {
                return StaticDALFactory.GetOrderInfoDal();
            }
        }

        public IActionInfoDal ActionInfoDal
        {
            get
            {
                return StaticDALFactory.GetActionInfoDal();
            }
        }

        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
        {
            get
            {
                return StaticDALFactory.GetR_UserInfo_ActionInfoDal();
            }
}
public IRoleInfoDal RoleInfoDal
{
    get
    {
        return StaticDALFactory.GetRoleInfoDal();
    }
}

        public IUserInfoEXtDal UserInfoEXtDal
        {
            get
            {
                return StaticDALFactory.GetUserInfoEXtDal();
            }
        }

        public IWF_InstanceDal WF_InstanceDal
        {
            get
            {
                return StaticDALFactory.GetWF_InstanceDal();
            }
        }
        public IWF_StepDal WF_StepDal
        {
            get
            {
                return StaticDALFactory.GetWF_StepDal();
            }
        }
        public IWF_TempDal WF_TempDal
        {
            get
            {
                return StaticDALFactory.GetWF_TempDal();
            }
        }
        /// <summary>
        /// 拿到EF上下文，然后把修改实体进行一个整体提交
        /// </summary>
        /// <returns></returns>
        public int SaveChanges() {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
