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
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
    }
    public partial class OrderInfoService : BaseService<OrderInfo>, IOrderInfoService
    {
    }
    
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public ActionInfoService()
        {

        }
        public IQueryable<ActionInfo> GetConditionPageGetData(ActionQueryParam actionQueryParam)
        {
            short normalFlag = (short)OA.Model.Enum.DelflagEnum.Normal;
            var temp = DbSession.ActionInfoDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(actionQueryParam.SchName))
            {
                temp = temp.Where(u => u.ActionName.Contains(actionQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(actionQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(actionQueryParam.SchRemark)).AsQueryable();
            }
            actionQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.ID)
                .Skip(actionQueryParam.PageSize * (actionQueryParam.PageIndex - 1))
                .Take(actionQueryParam.PageSize).AsQueryable();
        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.ActionInfoDal;
        }

        #region 设置角色
        public bool SetRole(int actionID, List<int> roleIDs)
        {
            var user = DbSession.ActionInfoDal.GetEntities(u => u.ID == actionID).FirstOrDefault();
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
    }
    public partial class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService
    {
        public R_UserInfo_ActionInfoService()
        {

        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.R_UserInfo_ActionInfoDal;
        }
    }
    public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
        public RoleInfoService()
        {

        }
        public IQueryable<RoleInfo> GetConditionPageGetData(RoleQueryParam roleQueryParam)
        {
            short normalFlag = (short)OA.Model.Enum.DelflagEnum.Normal;
            var temp = DbSession.RoleInfoDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(roleQueryParam.SchName))
            {
                temp = temp.Where(u => u.RoleName.Contains(roleQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(roleQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(roleQueryParam.SchRemark)).AsQueryable();
            }
            roleQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.ID)
                .Skip(roleQueryParam.PageSize * (roleQueryParam.PageIndex - 1))
                .Take(roleQueryParam.PageSize).AsQueryable();
        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.RoleInfoDal;
        }
    }
    public partial class UserInfoEXtService : BaseService<UserInfoEXt>, IUserInfoEXtService
    {
        public UserInfoEXtService()
        {

        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserInfoEXtDal;
        }
    }
    public partial class WF_InstanceService : BaseService<WF_Instance>, IWF_InstanceService
    {
        public WF_InstanceService()
        {

        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.WF_InstanceDal;
        }
    }
    public partial class WF_StepService : BaseService<WF_Step>, IWF_StepService
    {
        public WF_StepService()
        {

        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.WF_StepDal;
        }
    }
    public partial class WF_TempService : BaseService<WF_Temp>, IWF_TempService
    {
        public WF_TempService()
        {
            
        }
        public IQueryable<WF_Temp> GetConditionPageGetData(TempQueryParam tempQueryParam)
        {
            short normalFlag = (short)OA.Model.Enum.DelflagEnum.Normal;
            var temp = DbSession.WF_TempDal.GetEntities(u => u.DelFlag == normalFlag);
            //过滤
            if (!string.IsNullOrEmpty(tempQueryParam.SchName))
            {
                temp = temp.Where(u => u.TempName.Contains(tempQueryParam.SchName)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(tempQueryParam.SchRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(tempQueryParam.SchRemark)).AsQueryable();
            }
            tempQueryParam.Total = temp.Count();
            //分页
            return temp.OrderBy(u => u.ID)
                .Skip(tempQueryParam.PageSize * (tempQueryParam.PageIndex - 1))
                .Take(tempQueryParam.PageSize).AsQueryable();
        }
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.WF_TempDal;
        }
    }
}
