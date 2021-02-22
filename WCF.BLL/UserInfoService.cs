using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.IBLL;
using WCF.Model;

namespace WCF.BLL
{
    public class UserInfoService : IUserInfoService
    {
        public string GetName(int id)
        {
            return DateTime.Now.ToString();
        }

        public UserInfo GetUserById(int id)
        {
            return new UserInfo() {Id=id,Age=18,SName= DateTime.Now.ToString() };
        }
    }
}
