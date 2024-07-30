using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _02_Attribute
{
    public class People
    {
        /// <summary>
        /// 名字
        /// </summary>
        [StringLength(12)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(12)]
        public string Description { get; set; }
    }

    [DataContract]
    public class AnimalModel
    {
        [DataMember(Name = "name")]
        public string plName { get; set; }


        [DataMember(Name = "order_no")]
        public string orderNo { get; set; }
    }
}
