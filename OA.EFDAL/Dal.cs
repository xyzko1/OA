using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EFDAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
    }
    public partial class OrderInfoDal : BaseDal<OrderInfo>, IOrderInfoDal
    {
    }
    public partial class ActionInfoDal : BaseDal<ActionInfo>, IActionInfoDal
    {
    }
    public partial class R_UserInfo_ActionInfoDal : BaseDal<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoDal
    {
    }
    public partial class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
    {
    }
    public partial class UserInfoEXtDal : BaseDal<UserInfoEXt>, IUserInfoEXtDal
    {
    }
    public partial class WF_InstanceDal : BaseDal<WF_Instance>, IWF_InstanceDal
    {
    }
    public partial class WF_StepDal : BaseDal<WF_Step>, IWF_StepDal
    {
    }
    public partial class WF_TempDal : BaseDal<WF_Temp>, IWF_TempDal
    {
    }
}
