using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Model;

namespace WCF.IBLL
{
    //WCF服务契约
    [ServiceContract]
    public interface IOrderInfoService
    {
        //操作契约
        [OperationContract]
        int Add(int a,int b);
    }
}
