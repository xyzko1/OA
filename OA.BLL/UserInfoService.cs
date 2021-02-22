using OA.DALFactory;
using OA.EFDAL;
using OA.IBLL;
using OA.IDAL;
using OA.Model;
using OA.Model.Param;
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
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        public IQueryable<UserInfo> GetConditionPageGetData(UserQueryParam userQueryParam)
        {
            short normalFlag = (short)OA.Model.Enum.DelflagEnum.Normal;
            var temp = DbSession.UserInfoDal.GetEntities(u=>u.DelFlag== normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(userQueryParam.SchName))
            {
                temp = temp.Where(u => u.UName.Contains(userQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(userQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(userQueryParam.SchRemark)).AsQueryable();
            }
            userQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.ID)
                .Skip(userQueryParam.PageSize * (userQueryParam.PageIndex - 1))
                .Take(userQueryParam.PageSize).AsQueryable();
        }

        //UserInfoDal userInfoDal = new UserInfoDal();//一般New对象
        //IUserInfoDal userInfoDal = new UserInfoDal();//简单工厂，依赖接口编程,需更改New后实例
        //private IUserInfoDal userInfoDal = StaticDALFactory.GetUserInfoDal();//抽象工厂
        //DbSession dbSession = new DbSession();//层与层之间通过接口
        //IDbSession dbSession = new DbSession(); 
        //private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();

        //public UserInfo Add(UserInfo userInfo) {//UnitWork单元工作模式
        //    //return userInfoDal.Add(userInfo);
        //    dbSession.UserInfoDal.Add(userInfo);
        //    dbSession.SaveChanges();//数据提交的权利从数据库访问层提到了业务逻辑层
        //    return userInfo;
        //}
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserInfoDal;
        }
        #region 设置角色
        public bool SetRole(int userID, List<int> roleIDs)
        {
            var user = DbSession.UserInfoDal.GetEntities(u=>u.ID== userID).FirstOrDefault();
            user.RoleInfo.Clear();//先去除该User的关联

            var allRoles = DbSession.RoleInfoDal.GetEntities(r => roleIDs.Contains(r.ID));
            foreach (var roleInfo in allRoles)
            {
                user.RoleInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();//加最新的角色
            return true;
        }
        #endregion
        #region 设置特殊权限
        public bool SetAction(int userID, List<int> roleIDs)
        {
            //var user = DbSession.UserInfoDal.GetEntities(u => u.ID == userID).FirstOrDefault();
            //user.RoleInfo.Clear();//先去除该User的关联

            //var allRoles = DbSession.ActionInfoDal.GetEntities(r => roleIDs.Contains(r.ID));
            //foreach (var roleInfo in allRoles)
            //{
            //    user.RoleInfo.Add(roleInfo);
            //}
            //DbSession.SaveChanges();//加最新的角色
            return true;
        }
        #endregion
    }
}
