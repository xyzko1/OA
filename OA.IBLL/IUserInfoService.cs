using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public partial interface IUserInfoService: IBaseService<UserInfo>
    {
        IQueryable<UserInfo> GetConditionPageGetData(Model.Param.UserQueryParam userQueryParam);
        bool SetRole(int userID,List<int> roleIDs);
        bool SetAction(int userID, List<int> roleIDs);
    }
}
