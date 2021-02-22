using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.IBLL;
using WCF.Model;

namespace WCF.BLL
{
    public class OrderInfoService : IOrderInfoService
    {
        public int Add(int a,int b)
        {
            return a+b;
        }

    }
}
