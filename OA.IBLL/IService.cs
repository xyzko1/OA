using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public partial interface IUserInfoService : IBaseService<UserInfo>
    {
    }

    public partial interface IOrderInfoService : IBaseService<OrderInfo>
    {

    }
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        bool SetRole(int actionID, List<int> roleIDs);
    }
    public partial interface IR_UserInfo_ActionInfoService : IBaseService<R_UserInfo_ActionInfo>
    {

    }
    public partial interface IRoleInfoService : IBaseService<RoleInfo>
    {

    }
    public partial interface IUserInfoEXtService : IBaseService<UserInfoEXt>
    {

    }
    public partial interface IWF_InstanceService : IBaseService<WF_Instance>
    {

    }
    public partial interface IWF_StepService : IBaseService<WF_Step>
    {

    }
    public partial interface IWF_TempService : IBaseService<WF_Temp>
    {

    }
}
