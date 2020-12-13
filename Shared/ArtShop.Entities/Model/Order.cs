using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ArtShop.Entities.Model
{
    [Serializable]
    public partial class Order:IdentityBase
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public int OrderNumber { get; set; }
        [DataMember]
        public int ItemCount { get; set; }
    }
}
