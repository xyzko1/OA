//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Model
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class WF_Temp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WF_Temp()
        {
            this.WF_Instance = new HashSet<WF_Instance>();
        }
    
        public int ID { get; set; }
        public string TempName { get; set; }
        public string Description { get; set; }
        public string TempForm { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Remark { get; set; }
        public int DelFlag { get; set; }
        public string ActivityType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WF_Instance> WF_Instance { get; set; }
    }
}
