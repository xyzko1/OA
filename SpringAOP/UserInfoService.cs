using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringAOP
{
    public class UserInfoService : IUserInfoService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int DoubleAdd(int b)
        {
            return b + b;
        }
    }
}
