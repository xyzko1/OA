using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringAOP
{
   public interface IUserInfoService
    {
        int Add(int a,int b);

        int DoubleAdd( int b);
    }
}
