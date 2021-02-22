using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Model
{
    //为网络传输，可序列化
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SName { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
