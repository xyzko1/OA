using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public partial interface IUserInfoDal : IBaseDal<UserInfo>
    {
    }
    public partial interface IOrderInfoDal: IBaseDal<OrderInfo>
    {
    }
    public partial interface IActionInfoDal : IBaseDal<ActionInfo>
    {
    }
    public partial interface IR_UserInfo_ActionInfoDal : IBaseDal<R_UserInfo_ActionInfo>
    {
    }
    public partial interface IRoleInfoDal : IBaseDal<RoleInfo>
    {
    }
    public partial interface IUserInfoEXtDal : IBaseDal<UserInfoEXt>
    {
    }
    public partial interface IWF_InstanceDal : IBaseDal<WF_Instance>
    {
    }
    public partial interface IWF_StepDal : IBaseDal<WF_Step>
    {
    }
    public partial interface IWF_TempDal : IBaseDal<WF_Temp>
    {
    }
}
