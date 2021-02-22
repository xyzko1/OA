using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
  public partial interface IDbSession
    {
         IUserInfoDal UserInfoDal {get;}
       
         IOrderInfoDal OrderInfoDal  { get; }

        IActionInfoDal ActionInfoDal { get; }

        IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; }

        IRoleInfoDal RoleInfoDal { get; }

        IUserInfoEXtDal UserInfoEXtDal { get; }

        IWF_InstanceDal WF_InstanceDal { get; }

        IWF_StepDal WF_StepDal { get; }

        IWF_TempDal WF_TempDal { get; }
        int SaveChanges();
    }
}
